using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace CommonControls
{
    public sealed partial class TopBarMenuCtrl : UserControl
    {
        public static readonly DependencyProperty ProcessOneIsRunningProperty = DependencyProperty.Register(
            "ProcessOneIsRunning", typeof(bool), typeof(TopBarMenuCtrl), new PropertyMetadata(default(bool)));

        public bool ProcessOneIsRunning
        {
            get { return (bool) GetValue(ProcessOneIsRunningProperty); }
            set { SetValue(ProcessOneIsRunningProperty, value); }
        }

        public static readonly DependencyProperty ProcessTwoIsRunngProperty = DependencyProperty.Register(
            "ProcessTwoIsRunng", typeof(bool), typeof(TopBarMenuCtrl), new PropertyMetadata(default(bool)));

        public bool ProcessTwoIsRunng
        {
            get { return (bool) GetValue(ProcessTwoIsRunngProperty); }
            set { SetValue(ProcessTwoIsRunngProperty, value); }
        }

        public static readonly DependencyProperty ProcessThreeIsRunningProperty = DependencyProperty.Register(
            "ProcessThreeIsRunning", typeof(bool), typeof(TopBarMenuCtrl), new PropertyMetadata(default(bool)));

        public bool ProcessThreeIsRunning
        {
            get { return (bool) GetValue(ProcessThreeIsRunningProperty); }
            set { SetValue(ProcessThreeIsRunningProperty, value); }
        }

        public static readonly DependencyProperty ProcessFourIsRunningProperty = DependencyProperty.Register(
            "ProcessFourIsRunning", typeof(bool), typeof(TopBarMenuCtrl), new PropertyMetadata(default(bool)));

        public bool ProcessFourIsRunning
        {
            get { return (bool) GetValue(ProcessFourIsRunningProperty); }
            set { SetValue(ProcessFourIsRunningProperty, value); }
        }
        public TopBarMenuCtrl()
        {
            this.InitializeComponent();
        }
    }
}