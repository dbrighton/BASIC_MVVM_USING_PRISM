using BASIC_MVVM_CORE.PrismEvent;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BASIC_MVVM_CORE.ViewModels
{
    public class View2ViewModel : ViewModelBase, IView2ViewModel
    {
        private readonly Random _rand = new Random();
        private bool _isRunning;
        private ICommand _passStringCmd;
        private int _percentCompleate;
        private string _statusText;
        private string _stringToPass = "Beer";
        private int _view1PercentCompleate;
        private int _view3PercentCompleate;
        private int _view4PercentCompleate;
     

        public View2ViewModel()
        {

         

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

        public int View1PercentCompleate
        {
            get { return _view1PercentCompleate; }
            set { SetProperty(ref _view1PercentCompleate, value); }
        }

        public int View3PercentCompleate
        {
            get { return _view3PercentCompleate; }
            set { SetProperty(ref _view3PercentCompleate, value); }
        }

        public int View4PercentCompleate
        {
            get { return _view4PercentCompleate; }
            set { SetProperty(ref _view4PercentCompleate, value); }
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
                    this.PercentCompleate = i;
                    await Task.Delay(TimeSpan.FromSeconds(_rand.Next(1, 5)));
                }
                IsRunning = false;
            }
            return IsRunning;
        }

        private void RegisterPrismEvents()
        {
            AppServices.EventAggregator.GetEvent<MenuButtonPrismEvent>().Subscribe(args =>
            {
                if (args.Equals("StartProcess2", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (!this.IsRunning)
                    {
                        StartProccesAsync();
                    }
                }

                if (args.Equals("StopProcess2", StringComparison.CurrentCultureIgnoreCase))
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

        private void ResetCommands()
        {
            PassStringCmd = new DelegateCommand(() =>
            {
                AppServices.EventAggregator.GetEvent<PassObjecEvent>().Publish(new KeyValuePair<string, object>("View 2", StringToPass));
            });
        }

        public void StopProcces()
        {
          
            IsRunning = false;
           
          PercentCompleate = 0;
        }

        
    }
}