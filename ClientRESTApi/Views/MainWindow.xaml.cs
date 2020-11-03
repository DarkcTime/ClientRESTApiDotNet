using ClientRESTApi.BackEnd;
using ClientRESTApi.Models;
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
//using System.Web.Script.Serialization;

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
            new History(); 
        }

        private void GoClick(object sender, RoutedEventArgs e)
        {
        
            if (!string.IsNullOrWhiteSpace(this.TxtUrl.Text))
            {
                //get url request
                string url = this.TxtUrl.Text;
                //get method request
                string method = this.CmbMethods.Text;           

                RestClient restClient = new RestClient(url, method);
                if (restClient.MakeRequest()){
                    Request request = restClient.GetResponce();
                    SetResponce(request.Responce);
                    UpdateHistory(request);
                }
                else
                {
                    this.TxtUrl.Focus(); 
                }


            }
            else
            {
                SharedClass.MessageBoxWarning("Введите URL адрес");
            }
            

        }
        private void SetResponce(string responce)
        {
            this.TxtResponce.Text = responce;  
        }

        private void UpdateHistory(Request request)
        {
            History.AddRequest(request);
            this.HistoryList.ItemsSource = History.ListRequest; 
        }

    }
}
