using System.Windows;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System;

namespace evg
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          var list = bdagent.GetContext().Agent.ToList();

            foreach (var item in list)
            {
                SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=test2;Integrated Security=True");


                SqlCommand sqlcmd = new SqlCommand($"(SELECT SUM(ProductCount) FROM dbo.ProductSale WHERE AgentID = {item.ID} AND YEAR(dbo.ProductSale.SaleDate) = {Convert.ToInt32(DateTime.Now.Year)} )", connection);


                connection.Open();
                item.PtdSale = sqlcmd.ExecuteScalar().ToString();
             
                connection.Close();
            }
           lst.ItemsSource = bdagent.GetContext().Agent.ToList();





        }
    }
}
