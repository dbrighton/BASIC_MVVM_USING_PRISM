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
            this.DataContext = AppServices.Container.Resolve(typeof(IViewFourViewModel), null) as ViewFourViewModel;
        }

        public IViewFourViewModel ViewModel => DataContext as IViewFourViewModel;
    }
}