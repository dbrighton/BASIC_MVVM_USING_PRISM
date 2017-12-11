using BASIC_MVVM_CORE;
using BASIC_MVVM_CORE.ViewModels;
using Windows.UI.Xaml.Controls;

namespace BASIC_MVVM.Views
{
    public sealed partial class ViewTwo : UserControl
    {
        public ViewTwo()
        {
            this.InitializeComponent();
            this.DataContext = AppServices.Container.Resolve(typeof(IViewTwoViewModel), null) as ViewTwoViewModel;
        }

        public IViewTwoViewModel ViewModel => DataContext as IViewTwoViewModel;
    }
}