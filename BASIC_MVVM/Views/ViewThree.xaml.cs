using BASIC_MVVM_CORE;
using BASIC_MVVM_CORE.ViewModels;
using Windows.UI.Xaml.Controls;

namespace BASIC_MVVM.Views
{
    public sealed partial class ViewThree : UserControl
    {
        public ViewThree()
        {
            this.InitializeComponent();
            this.DataContext = AppServices.Container.Resolve(typeof(View3ViewModel), null) as View3ViewModel;
        }

        public View3ViewModel ViewModel => DataContext as View3ViewModel;
    }
}