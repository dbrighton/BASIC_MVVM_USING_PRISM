using BASIC_MVVM_CORE;
using BASIC_MVVM_CORE.ViewModels;
using Windows.UI.Xaml.Controls;
using Microsoft.Practices.Unity;

namespace BASIC_MVVM.Views
{
    public sealed partial class ViewTwo : UserControl
    {
        public ViewTwo()
        {
            this.InitializeComponent();
            this.DataContext = AppServices.Container.Resolve(typeof(View2ViewModel), null) as View2ViewModel;
        }

        public View2ViewModel ViewModel => DataContext as View2ViewModel;
    }
}