using BASIC_MVVM_CORE;
using BASIC_MVVM_CORE.ViewModels;
using Windows.UI.Xaml.Controls;

namespace BASIC_MVVM.Views
{
    public sealed partial class ViewFour : UserControl
    {
        public ViewFour()
        {
            this.InitializeComponent();
            this.DataContext = AppServices.Container.Resolve(typeof(View4ViewModel), null) as View4ViewModel;
        }

        public View4ViewModel ViewModel => DataContext as View4ViewModel;
    }
}