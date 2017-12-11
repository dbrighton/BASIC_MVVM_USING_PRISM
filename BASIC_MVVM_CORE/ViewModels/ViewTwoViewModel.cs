﻿using BASIC_MVVM_CORE.PrismEvent;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BASIC_MVVM_CORE.ViewModels
{
    public class ViewTwoViewModel : ViewModelBase, IViewTwoViewModel
    {
        private bool _isRunning;
        private int _percentCompleate;
        private Random _rand = new Random();
        private int _view1PercentCompleate;
        private int _view3PercentCompleate;
        private int _view4PercentCompleate;

        public ViewTwoViewModel()
        {
            RegisterPrismEvents();
        }

        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                SetProperty(ref _isRunning, value);
                AppServices.EventAggregator.GetEvent<IsRunningStateChangedPrismEvent>().Publish(new KeyValuePair<object, bool>(this, IsRunning));
            }
        }

        public int PercentCompleate
        {
            get { return _percentCompleate; }
            set
            {
                SetProperty(ref _percentCompleate, value);
                AppServices.EventAggregator.GetEvent<RunningPercentChangedPrismEvent>().Publish(new KeyValuePair<object, int>(this, PercentCompleate));
            }
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
                        StartProcces();
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