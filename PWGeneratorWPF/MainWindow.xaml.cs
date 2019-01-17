using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace PWGeneratorWPF
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            button1.PerformClick();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = System.Web.Security.Membership.GeneratePassword(12, 0); // System.Web を参照に追加
            textBox1.SelectAll();
            textBox1.Focus();
            textBox1.Copy();
        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.F5)
            {
                button1.PerformClick();
            }
        }
    }
    public static class ButtonExtensions
    {
        public static void PerformClick(this Button button)
        {
            if (button == null)
                throw new ArgumentNullException("button");

            var provider = new ButtonAutomationPeer(button) as IInvokeProvider;
            provider.Invoke();
        }
    }
}
