﻿using System;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using WaiterHelper.Services;
using System.Threading;
using System.Linq;
namespace WaiterHelper.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly IRecognizerService recognizerService;

        public byte[] SignatureBytes { get; set; }

        public string ResultText { get; set; }
        public IMvxCommand SearchCommand { get; set; }

        public SearchViewModel(IRecognizerService recognizerService)
        {
            this.recognizerService = recognizerService;
            SearchCommand = new MvxAsyncCommand(GetResultText);
        }

        private async Task GetResultText()
        {
            var locationResult = await recognizerService.RecognizeHandWrittenText(SignatureBytes);
            Thread.Sleep(5000);
            var textresult = await recognizerService.GetResult(locationResult);
            ResultText = textresult.RecognitionResult.Lines.FirstOrDefault()?.Text;
        }
    }
}
