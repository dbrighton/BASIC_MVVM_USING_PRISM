using Prism.Windows.Mvvm;
using System;
using System.Threading.Tasks;

namespace BASIC_MVVM_CORE.ViewModels
{
    public class ViewFourViewModel : ViewModelBase, IViewFourViewModel
    {
        private int _percentCompleate;
        private bool _isRunning;
        private readonly Random _rand = new Random();
        private int _view1PercentCompleate;
        private int _view2PercentCompleate;
        private int _view3PercentCompleate;

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

        public int View1PercentCompleate
        {
            get { return _view1PercentCompleate; }
            set { SetProperty(ref _view1PercentCompleate, value); }
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

        public int PercentCompleate
        {
            get { return _percentCompleate; }
            set { SetProperty(ref _percentCompleate, value); }
        }

        public bool IsRunning
        {
            get { return _isRunning; }
            set { SetProperty(ref _isRunning, value); }
        }
    }
}