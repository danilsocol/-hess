using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace Chess.Desktop
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            var spMenu = this.FindControl<StackPanel>("spMenu");
            spMenu.IsVisible = false;
        }
    }
}
