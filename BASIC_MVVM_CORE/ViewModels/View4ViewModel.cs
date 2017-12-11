using BASIC_MVVM_CORE.PrismEvent;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BASIC_MVVM_CORE.ViewModels
{
    public class View4ViewModel : ViewModelBase, IView4ViewModel
    {
        private readonly Random _rand = new Random();
        private bool _isRunning;
        private ICommand _passStringCmd;
        private int _percentCompleate;
        private string _statusText;
        private string _stringToPass = "a card";

        public View4ViewModel()
        {
            PassStringCmd = new DelegateCommand(() =>
            {
                AppServices.EventAggregator.GetEvent<PassObjecEvent>()
                    .Publish(new KeyValuePair<string, object>("View 4", StringToPass));
            });

            RegisterPrismEvents();
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

                for (int i = 0; i < 100; i++)
                {
                    if (!IsRunning)
                    {
                        break;
                    }
                    PercentCompleate = i;
                    await Task.Delay(TimeSpan.FromSeconds(_rand.Next(1, 5)));
                }
                IsRunning = false;
            }
            return IsRunning;
        }

        public void StopProcces()
        {
            IsRunning = false;
            PercentCompleate = 0;
        }

        private void RegisterPrismEvents()
        {
            AppServices.EventAggregator.GetEvent<MenuButtonPrismEvent>().Subscribe(args =>
            {
                if (args.Equals("StartProcess4", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (!this.IsRunning)
                    {
                        StartProccesAsync();
                    }
                }

                if (args.Equals("StopProccess4", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (this.IsRunning)
                    {
                        StopProcces();
                    }
                }
            });

            AppServices.EventAggregator.GetEvent<PassObjecEvent>()
                .Subscribe(payload =>
                {
                    StatusText = $"{payload.Key} Passed {payload.Value as string}.";
                });
        }
    }
}