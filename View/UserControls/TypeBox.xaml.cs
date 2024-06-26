using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WPFTutorial.View.UserControls
{
    public partial class TypeBox : UserControl
    {
        public TypeBox()
        {
            InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("YOU SHOULDN'T HAVE CLICKED THAT!!!", "RETARD ALERT", MessageBoxButton.OK, MessageBoxImage.Error);
            Environment.Exit(0);
        }
    }
}
