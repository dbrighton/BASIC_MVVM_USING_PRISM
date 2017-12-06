using Common;
using Common.ViewModels;
using Windows.UI.Xaml.Controls;

namespace BASIC_MVVM.Views
{
    public sealed partial class ViewOne : UserControl
    {
        public ViewOneViewModel ViewModel => DataContext as ViewOneViewModel;

        public ViewOne()
        {
            this.InitializeComponent();
            this.DataContext = AppServices.Container.Resolve(typeof(ViewOneViewModel), null) as ViewOneViewModel;
        }
    }
}