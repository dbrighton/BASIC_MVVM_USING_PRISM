using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BASIC_MVVM_CORE.PrismEvent;
using Prism.Windows.Mvvm;

namespace BASIC_MVVM_CORE.ViewModels
{
    public class ViewOneViewModel : ViewModelBase
    {
        private bool _isRunning;
        private int _percentCompleate;
        private Random _rand = new Random();

        public ViewOneViewModel()
        {
            RegisterPrismEvents();
        }

        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                SetProperty(ref _isRunning, value);
                AppServices.EventAggregator.GetEvent<IsRunningStateChanged>().Publish(new KeyValuePair<object, bool>(this, IsRunning));
            }
        }

        public int PercentCompleate
        {
            get { return _percentCompleate; }
            set
            {
                SetProperty(ref _percentCompleate, value);
                AppServices.EventAggregator.GetEvent<RunningPercentChanged>().Publish(new KeyValuePair<object, int>(this, PercentCompleate));
            }
        }

        private void RegisterPrismEvents()
        {
            AppServices.EventAggregator.GetEvent<MenuButtonCmd>().Subscribe(args =>
            {
                if (args.Equals("StartProcess1", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (!this.IsRunning)
                    {
                        StartProcces();
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

        private async Task<bool> StartProcces()
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