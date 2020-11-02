using ClientRESTApi.BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientRESTApi.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
 
        }

        private void GoClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.TxtUrl.Text) && this.CmbMethods.SelectedItem != null)
            {
                string url = this.TxtUrl.Text;
                string method = "GET";
                RestClient restClient = new RestClient(url, method);
                string responce = restClient.GetResponce(); 
                this.MainFrame.Content = new ResponceApi(responce);
            }
            else
            {
                //if not fill 
            }

        }
    }
}
