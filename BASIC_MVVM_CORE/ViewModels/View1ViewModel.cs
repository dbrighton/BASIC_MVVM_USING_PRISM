using BASIC_MVVM_CORE.PrismEvent;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

#pragma warning disable 4014

namespace BASIC_MVVM_CORE.ViewModels
{
    public class View1ViewModel : ViewModelBase, IView1ViewModel
    {
        private readonly Random _rand = new Random();
        private bool _isRunning;
        private ICommand _passStringCmd;
        private int _percentCompleate;
        private ICommand _startAllUsingUnityCmd;
        private string _statusText;
        private string _stringToPass = "Gas";
        private int _view2PercentCompleate;
        private int _view3PercentCompleate;
        private int _view4PercentCompleate;
        private CancellationTokenSource _tokenSource;

        public View1ViewModel()
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

        public ICommand StartAllUsingUnityCmd
        {
            get { return _startAllUsingUnityCmd; }
            set { SetProperty(ref _startAllUsingUnityCmd, value); }
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

        public int View2PercentCompleate
        {
            get { return _view2PercentCompleate; }
            set { SetProperty(ref _view2PercentCompleate, value); }
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

        public void ResetCommands()
        {
            this.PassStringCmd = new DelegateCommand(ExePassStringCmd);
            this.StartAllUsingUnityCmd = new DelegateCommand(ExeStartAllUsingUnityCmd);
        }

        public async Task<bool> StartProccesAsync()
        {
            if (!IsRunning)
            {
                IsRunning = true;

                _tokenSource = new CancellationTokenSource();
                var ct = _tokenSource.Token;



                for (int i = 0; i < 100; i++)
                {
                    if (_tokenSource.IsCancellationRequested)
                    {
                        break;
                    }
                    PercentCompleate = i;
                    await Task.Delay(TimeSpan.FromSeconds(_rand.Next(1, 5)), ct);
                }
                IsRunning = false;
            }
            return IsRunning;
        }

        public void StopProcces()
        {
            _tokenSource?.Cancel();
            IsRunning = false;
            PercentCompleate = 0;
        }

        private void ExePassStringCmd()
        {
            AppServices.EventAggregator.GetEvent<PassObjecEvent>()
                .Publish(new KeyValuePair<string, object>("View 1", StringToPass));
        }

        private void ExeStartAllUsingUnityCmd()
        {
            //Get all the ViewModels from Unitity Container and start the
            //process
            var vm2 = AppServices.Container.Resolve<IView2ViewModel>();
            var vm3 = AppServices.Container.Resolve<IView3ViewModel>();
            var vm4 = AppServices.Container.Resolve<IView4ViewModel>();

            StopProcces();
            vm2.StopProcces();
            vm3.StopProcces();
            vm4.StopProcces();

            StartProccesAsync();
            vm2.StartProccesAsync();
            vm3.StartProccesAsync();
            vm4.StartProccesAsync();
        }

        private void RegisterPrismEvents()
        {
            AppServices.EventAggregator.GetEvent<MenuButtonPrismEvent>().Subscribe(args =>
            {
                if (args.Equals("StartProcess1", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (!this.IsRunning)
                    {
                        StartProccesAsync();
                    }
                }

                if (args.Equals("StopProcess1", StringComparison.CurrentCultureIgnoreCase))
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

            AppServices.EventAggregator.GetEvent<RunningPercentChangedPrismEvent>().Subscribe(payload =>
            {
                var name = payload.Key.GetType().Name;
                switch (name)
                {
                    case "View2ViewModel": View2PercentCompleate = payload.Value; break;
                    case "View3ViewModel": View3PercentCompleate = payload.Value; break;
                    case "View4ViewModel": View4PercentCompleate = payload.Value; break;
                }
            });
        }
    }
}