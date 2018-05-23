using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Realms;
using System.Linq;
using WaiterHelper.Helpers;

namespace WaiterHelper.Services
{
    public class CacheProviderBase
    {
        protected readonly ILog Log;

        private static readonly JsonSerializerSettings serializeSettings;
        private static readonly Lazy<Realm> realmLazy = new Lazy<Realm>(() => Realm.GetInstance());

        protected static Realm SharedRealm => realmLazy.Value;

        public CacheProviderBase(ILog log)
        {
            this.Log = log;
        }

        static CacheProviderBase()
        {
            RealmConfiguration.DefaultConfiguration.ShouldDeleteIfMigrationNeeded = true;
            serializeSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateParseHandling = DateParseHandling.None,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
        }

        protected IQueryable<T> SaveRange<T>(IEnumerable<T> collection, bool clearBefore = false)
            where T : RealmObject
        {
            try
            {
                SharedRealm.Write(() =>
                {
                    if (clearBefore)
                        SharedRealm.RemoveRange<T>(SharedRealm.All<T>());
                    foreach (var item in collection)
                        SharedRealm.Add(item, true);
                });

                return SharedRealm.All<T>();
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
                throw;
            }
        }

        protected IQueryable<T> UpdateRange<T>(IEnumerable<T> collection)
          where T : RealmObject
        {
            try
            {
                SharedRealm.Write(() =>
                {
                    foreach (var item in collection)
                        SharedRealm.Add(item, true);
                });

                return SharedRealm.All<T>();
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
                throw;
            }
        }

        protected void SaveItem<T>(T item, bool update = true)
            where T : RealmObject
        {
            try
            {
                SharedRealm.Write(() => SharedRealm.Add(item, update));
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
                throw;
            }
        }
    }
}