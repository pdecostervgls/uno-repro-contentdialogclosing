using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ContentDialogClosing
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ContentDialog cd;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog("ContentDialog Opening");
            await md.ShowAsync();
            StackPanel sp = new StackPanel();
            Button b = new Button();
            b.Content = new TextBlock()
            {
                Text = "Close Dialog"
            };
            b.HorizontalAlignment = HorizontalAlignment.Stretch;
            b.VerticalAlignment = VerticalAlignment.Stretch;

            b.Click += B_Click;

            sp.Children.Add(b);
            
            cd = new ContentDialog();

            cd.Content = sp;

            var result = await cd.ShowAsync();
            md = new MessageDialog("ContentDialog Closed");
            await md.ShowAsync();
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            cd.Hide();
        }
    }
}
