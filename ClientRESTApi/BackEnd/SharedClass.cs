using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientRESTApi.BackEnd
{
    /// <summary>
    /// Input standart options for work with ComboBoxes 
    /// </summary>
    public class SharedClass
    {
        public static void MessageBoxError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void MessageBoxError(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void MessageBoxWarning(string message, string title = "Check data")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void MessageBoxInformation(string message, string title = "Success")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static MessageBoxResult MessageBoxQuestion(string message, string title = "Question")
        {
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result;
        }
    }
}
