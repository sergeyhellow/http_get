using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
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
using static System.Net.Mime.MediaTypeNames;

namespace http_get
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {

            try
            {


                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage message = await client.GetAsync(Adress.Text.ToString());
                    BodyOf.Text = await message.Content.ReadAsStringAsync();
                    Kod.Content = message.StatusCode.ToString();

                }

                File.WriteAllText("C:\\Users\\User\\Documents\\C# projekts2\\CoreList\\CoreList\\test.txt", BodyOf.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
