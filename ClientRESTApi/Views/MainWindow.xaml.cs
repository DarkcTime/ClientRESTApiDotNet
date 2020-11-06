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
//Library project
using ClientRESTApi.Logic;
using ClientRESTApi.Logic.Model;

namespace ClientRESTApi.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Person { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            new History();
            this.CmbMethods.ItemsSource = MethodsRepository.GetMethods();
        }

        private void GoClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.TxtUrl.Text))
                {
                    
                    //get url request
                    string url = this.TxtUrl.Text;
                    //get method request
                    Methods method = (Methods)this.CmbMethods.SelectedItem;

                    if (string.IsNullOrWhiteSpace(this.TxtBody.Text) && 
                        (method.Equals(Methods.POST) || method.Equals(Methods.PUT)))
                    {
                        if (SharedClass.MessageBoxQuestion("Body is Empty. Continue?") == MessageBoxResult.No) return; 
                    }

                    RestClient restClient = new RestClient(url, method);
                    restClient.MakeRequest();
                    if (method == Methods.POST || method == Methods.PUT)
                    {
                        string body = this.TxtBody.Text;
                        restClient.SetBody(body);
                    }

                    Request request = restClient.GetResponce();
                    string responce = request.Responce;

                    if (request.Method == Methods.GET)
                    {
                        responce = Serialization.GetJsonSerialize(request.Responce);
                    }

                    SetResponce(responce);

                    if(request.Responce.Length > History.MAXLENGHTRESPONCE)
                    {
                        request.Responce = request.Responce.Substring(0, History.MAXLENGHTRESPONCE); 
                    }

                    UpdateHistory(request);

                }
                else
                {
                    SharedClass.MessageBoxWarning("Enter the URL address");
                }
            }
            catch (UriFormatException ufe)
            {
                SharedClass.MessageBoxWarning("Invalid URL format", "URL Format");
            }
            catch (Exception ex)
            {
                SharedClass.MessageBoxError(ex);
            }
          

        }
        private void SetResponce(string responce)
        {
            this.TxtResponce.Text = responce;
        }

        private void UpdateHistory(Request request)
        {
            History.AddRequest(request);
            this.HistoryList.ItemsSource = null; 
            this.HistoryList.ItemsSource = History.ListRequest;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
