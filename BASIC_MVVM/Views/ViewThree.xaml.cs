using Common;
using Common.ViewModels;
using Windows.UI.Xaml.Controls;

namespace BASIC_MVVM.Views
{
    public sealed partial class ViewThree : UserControl
    {
        public ViewThreeViewModel ViewModel => DataContext as ViewThreeViewModel;

        public ViewThree()
        {
            this.InitializeComponent();
            this.DataContext = AppServices.Container.Resolve(typeof(ViewThreeViewModel), null) as ViewThreeViewModel;
        }
    }
}