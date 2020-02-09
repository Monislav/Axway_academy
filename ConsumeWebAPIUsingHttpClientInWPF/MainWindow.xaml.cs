using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace ConsumeWebAPIUsingHttpClientInWPF
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

        private void BindEmployeeList()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12789/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/employee").Result;

            if (response.IsSuccessStatusCode)
            {
                var employees = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                grdEmployee.ItemsSource = employees;

            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

        }

        //private void BindResource()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("https://api.icarol.com/");
        //    client.DefaultRequestHeaders.Add("Authorization", "Bearer 38b88e90-ec13-4aad-a6c4-7ffdea01adfd");
        //    // Add an Accept header for JSON format.
        //    //client.DefaultRequestHeaders.Accept.Add(
        //    //    new MediaTypeWithQualityHeaderValue("application/json"));

        //    HttpResponseMessage response = client.GetAsync("v1/Resource/Taxonomy?db=2285").Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var employees = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
        //        grdEmployee.ItemsSource = employees;

        //    }
        //    else
        //    {
        //        MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
        //    }

        //}

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12789/");

            var id = txtId.Text.Trim();

            var url = "api/employee/" + id;

            HttpResponseMessage response = client.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("User Deleted");
                 BindEmployeeList();

            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12789/");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var id = txtId.Text.Trim();

            var url = "api/employee/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var employees = response.Content.ReadAsAsync<Employee>().Result;

                MessageBox.Show("Employee Found : " + employees.Name + " " + employees.Address + " " + employees.Designation);

            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12789/");

            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));            
            var employee = new Employee();

            employee.Id = int.Parse(txtId.Text);
            employee.Name = txtName.Text;
            employee.Address = txtAddress.Text;
            employee.Designation = txtDesignation.Text;

            var response = client.PostAsJsonAsync("api/employee", employee).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Employee Added");
                txtId.Text = "";
                txtName.Text = "";
                txtAddress.Text = "";
                txtDesignation.Text = "";
                BindEmployeeList();
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            BindEmployeeList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindEmployeeList();
        }
    }
}
