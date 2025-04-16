using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AdaptiveLayoutApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += OnWindowSizeChanged;
        }

        private void OnDeviceControlClicked(object sender, RoutedEventArgs e)
        {
            if (IsLargeScreen())
            {
                DeviceSplitView.IsPaneOpen = true;
                if (DeviceControlFrame.Content == null)
                {
                    DeviceControlFrame.Navigate(typeof(DeviceControlPage));
                }
            }
            else
            {
                ContentFrame.Navigate(typeof(DeviceControlPage));
            }
        }

        private void OnWindowSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (IsLargeScreen())
            {
                if (DeviceControlFrame.Content != null && !DeviceSplitView.IsPaneOpen)
                {
                    DeviceSplitView.IsPaneOpen = true;
                }
            }
            else
            {
                if (DeviceSplitView.IsPaneOpen)
                {
                    DeviceSplitView.IsPaneOpen = false;
                    if (DeviceControlFrame.Content != null)
                    {
                        ContentFrame.Navigate(typeof(DeviceControlPage));
                    }
                }
            }
        }

        private bool IsLargeScreen() => Window.Current.Bounds.Width >= 720;

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Window.Current.SizeChanged -= OnWindowSizeChanged;
            base.OnNavigatedFrom(e);
        }
    }
}