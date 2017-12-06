using Windows.UI.Xaml.Controls;
using BASIC_MVVM_CORE;
using BASIC_MVVM_CORE.ViewModels;

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