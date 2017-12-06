using Windows.UI.Xaml.Controls;
using BASIC_MVVM_CORE;
using BASIC_MVVM_CORE.ViewModels;

namespace BASIC_MVVM.Views
{
    public sealed partial class ViewFour : UserControl
    {
        public ViewFourViewModel ViewModel => DataContext as ViewFourViewModel;

        public ViewFour()
        {
            this.InitializeComponent();
            this.DataContext = AppServices.Container.Resolve(typeof(ViewFourViewModel), null) as ViewFourViewModel;
        }
    }
}