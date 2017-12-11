using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BASIC_MVVM_CORE.Controls
{
    public sealed partial class PassStringCtrl : UserControl
    {
        public static readonly DependencyProperty BtnCmdProperty = DependencyProperty.Register(
            "BtnCmd", typeof(ICommand), typeof(PassStringCtrl), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty StringArgProperty = DependencyProperty.Register(
            "StringArg", typeof(string), typeof(PassStringCtrl), new PropertyMetadata(default(string)));

        public PassStringCtrl()
        {
            this.InitializeComponent();
        }

        public ICommand BtnCmd
        {
            get { return (ICommand)GetValue(BtnCmdProperty); }
            set { SetValue(BtnCmdProperty, value); }
        }

        public string StringArg
        {
            get { return (string)GetValue(StringArgProperty); }
            set { SetValue(StringArgProperty, value); }
        }
    }
}