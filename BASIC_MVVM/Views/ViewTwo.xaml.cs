using Common;
using Common.ViewModels;
using Windows.UI.Xaml.Controls;

namespace BASIC_MVVM.Views
{
    public sealed partial class ViewTwo : UserControl
    {
        public ViewTwoViewModel ViewModel => DataContext as ViewTwoViewModel;

        public ViewTwo()
        {
            this.InitializeComponent();
            this.DataContext = AppServices.Container.Resolve(typeof(ViewTwoViewModel), null) as ViewTwoViewModel;
        }
    }
}