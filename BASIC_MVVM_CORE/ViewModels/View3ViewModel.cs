﻿using BASIC_MVVM_CORE.PrismEvent;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BASIC_MVVM_CORE.ViewModels
{
    public class View3ViewModel : ViewModelBase, IView3ViewModel
    {
        private readonly Random _rand = new Random();
        private bool _isRunning;
        private ICommand _passStringCmd;
        private int _percentCompleate;
        private string _statusText;
        private string _stringToPass = "A Buck.";
        private CancellationToken _ct;


        public View3ViewModel()
        {
            var tokenSource2 = new CancellationTokenSource();
            _ct = tokenSource2.Token;

            RegisterPrismEvents();
            ResetCommands();
        }

        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                SetProperty(ref _isRunning, value);
                AppServices.EventAggregator.GetEvent<IsRunningStateChangedPrismEvent>()
                    .Publish(new KeyValuePair<object, bool>(this, IsRunning));
            }
        }

        public ICommand PassStringCmd
        {
            get { return _passStringCmd; }
            set { SetProperty(ref _passStringCmd, value); }
        }

        public int PercentCompleate
        {
            get { return _percentCompleate; }
            set
            {
                SetProperty(ref _percentCompleate, value);
                AppServices.EventAggregator.GetEvent<RunningPercentChangedPrismEvent>()
                    .Publish(new KeyValuePair<object, int>(this, PercentCompleate));
            }
        }

        public string StatusText
        {
            get { return _statusText; }
            set { SetProperty(ref _statusText, value); }
        }

        public string StringToPass
        {
            get { return _stringToPass; }
            set { SetProperty(ref _stringToPass, value); }
        }
        

      

        public async Task<bool> StartProccesAsync()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                
                _ct = new CancellationToken(false);

                for (int i = 0; i < 100; i++)
                {
                    if (!IsRunning)
                    {
                        break;
                    }
                    PercentCompleate = i;
                    await Task.Delay(TimeSpan.FromSeconds(_rand.Next(1, 5)), _ct);
                }
                IsRunning = false;
            }
            return IsRunning;
        }

        public void StopProcces()
        {
            _ct.ThrowIfCancellationRequested();
            _ct = new CancellationToken(true);
            IsRunning = false;
            PercentCompleate = 0;
        }

        private void RegisterPrismEvents()
        {
            AppServices.EventAggregator.GetEvent<MenuButtonPrismEvent>().Subscribe(payload =>
            {
                if (payload.Equals("StartProeces3", StringComparison.CurrentCultureIgnoreCase))
                {
                    StartProccesAsync();
                }

                if (payload.Equals("StopPerocess3", StringComparison.CurrentCultureIgnoreCase))
                {
                    StopProcces();
                }
            });

            AppServices.EventAggregator.GetEvent<PassObjecEvent>()
                .Subscribe(payload =>
                {
                    StatusText = $"{payload.Key} Passed {payload.Value as string}.";
                });
        }

        private void ResetCommands()
        {
            PassStringCmd = new DelegateCommand(() =>
            {
                AppServices.EventAggregator.GetEvent<PassObjecEvent>().Publish(new KeyValuePair<string, object>("View 3", StringToPass));
            });
        }
    }
}