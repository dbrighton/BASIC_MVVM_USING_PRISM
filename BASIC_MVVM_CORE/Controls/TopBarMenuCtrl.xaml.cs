﻿using BASIC_MVVM_CORE.PrismEvent;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Prism.Events;

namespace BASIC_MVVM_CORE.Controls
{
    public sealed partial class TopBarMenuCtrl : UserControl
    {
        public static readonly DependencyProperty ProcessFourIsRunningProperty = DependencyProperty.Register(
            "ProcessFourIsRunning", typeof(bool), typeof(TopBarMenuCtrl), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty ProcessOneIsRunningProperty = DependencyProperty.Register(
            "ProcessOneIsRunning", typeof(bool), typeof(TopBarMenuCtrl), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty ProcessThreeIsRunningProperty = DependencyProperty.Register(
            "ProcessThreeIsRunning", typeof(bool), typeof(TopBarMenuCtrl), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty ProcessTwoIsRunngProperty = DependencyProperty.Register(
            "ProcessTwoIsRunng", typeof(bool), typeof(TopBarMenuCtrl), new PropertyMetadata(default(bool)));

        public TopBarMenuCtrl()
        {
            this.InitializeComponent();
            RegisterPrismEvents();
        

        }

        private void RegisterPrismEvents()
        {
            AppServices.EventAggregator.GetEvent<IsRunningStateChanged>().Subscribe(args =>
            {
                var viewName = args.Key.GetType().Name;
                switch (viewName)
                {
                    case "ViewOneViewModel":
                        ProcessOneIsRunning = args.Value;
                        break;

                    case "ViewTwoViewModel":
                        ProcessTwoIsRunng = args.Value;
                        break;

                    case "ViewThreeViewModel":
                        ProcessThreeIsRunning = args.Value;
                        break;

                    case "ViewfourViewModel":
                        ProcessFourIsRunning = args.Value;
                        break;
                }
            });
        }

        public bool ProcessFourIsRunning
        {
            get { return (bool)GetValue(ProcessFourIsRunningProperty); }
            set { SetValue(ProcessFourIsRunningProperty, value); }
        }

        public bool ProcessOneIsRunning
        {
            get { return (bool)GetValue(ProcessOneIsRunningProperty); }
            set { SetValue(ProcessOneIsRunningProperty, value); }
        }

        public bool ProcessThreeIsRunning
        {
            get { return (bool)GetValue(ProcessThreeIsRunningProperty); }
            set { SetValue(ProcessThreeIsRunningProperty, value); }
        }

        public bool ProcessTwoIsRunng
        {
            get { return (bool)GetValue(ProcessTwoIsRunngProperty); }
            set { SetValue(ProcessTwoIsRunngProperty, value); }
        }

        private void StartProcess_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                AppServices.EventAggregator.GetEvent<MenuButtonCmd>().Publish(btn.Name);
            }
        }

       

        private void TopBarMenuCtrl_OnLoaded(object sender, RoutedEventArgs e)
        {
            ProcessOneIsRunning = false;
            ProcessTwoIsRunng = false;
            ProcessThreeIsRunning = false;
            ProcessFourIsRunning = false;
        }
    }
}