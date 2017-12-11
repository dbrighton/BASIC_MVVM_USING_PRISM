using BASIC_MVVM_CORE.PrismEvent;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BASIC_MVVM_CORE.ViewModels
{
    public class ViewOneViewModel : ViewModelBase, IViewOneViewModel
    {
        private readonly Random _rand = new Random();
        private bool _isRunning;
        private ICommand _passStringCmd;
        private int _percentCompleate;
        private ICommand _startAllUsingUnityCmd;
        private string _stringToPass = "Gas";
        private int _view2PercentCompleate;
        private int _view3PercentCompleate;
        private int _view4PercentCompleate;

        public ViewOneViewModel()
        {
            RegisterPrismEvents();
            ResetCommands();
        }

        private void ResetCommands()
        {
            this.PassStringCmd = new DelegateCommand<string>(ExePassStringCmd);
            this.StartAllUsingUnityCmd = new DelegateCommand(ExeStartAllUsingUnityCmd);
        }

        private void ExeStartAllUsingUnityCmd()
        {
            var vm2 = AppServices.Container.Resolve<ViewTwoViewModel>();
            var vm3 = AppServices.Container.Resolve<ViewThreeViewModel>();
            var vm4 = AppServices.Container.Resolve<ViewFourViewModel>();

            this.StartProccesAsync();
            vm2.StartProccesAsync();
            vm3.StartProccesAsync();
            vm4.StartProccesAsync();
        }

        private void ExePassStringCmd(string aSrtring)
        {
            AppServices.EventAggregator.GetEvent<PassObjecCommand>()
                .Publish(new KeyValuePair<string, object>("PassedFromViewOneString", aSrtring));
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

        private void StopProcces()
        {
            IsRunning = false;
            PercentCompleate = 0;
        }
    }
}