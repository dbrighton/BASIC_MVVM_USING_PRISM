using BASIC_MVVM_CORE;
using BASIC_MVVM_CORE.ViewModels;
using Windows.UI.Xaml.Controls;

namespace BASIC_MVVM.Views
{
    public sealed partial class ViewOne : UserControl
    {
        public ViewOne()
        {
            this.InitializeComponent();
            this.DataContext = AppServices.Container.Resolve(typeof(View1ViewModel), null)
                as View1ViewModel;
        }

        public View1ViewModel ViewModel=> DataContext as View1ViewModel;
    }
}