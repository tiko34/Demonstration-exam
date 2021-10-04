using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

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
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=test2;Integrated Security=True");
            foreach (var item in list)
            {

                SqlCommand sqlcmd = new SqlCommand($"(SELECT SUM(ProductCount) FROM dbo.ProductSale WHERE AgentID = {item.ID} AND YEAR(dbo.ProductSale.SaleDate) = {Convert.ToInt32(DateTime.Now.Year)} )", connection);
                connection.Open();
                item.PtdSale = sqlcmd.ExecuteScalar().ToString();
                connection.Close();
            }

            foreach (var y in list)
            {

                SqlCommand sqlcmd = new SqlCommand($"(SELECT SUM(ProductCount) FROM dbo.ProductSale WHERE AgentID = {y.ID})", connection);
                connection.Open();
                int i = Convert.ToInt32(sqlcmd.ExecuteScalar().ToString());
                connection.Close();
                if (i > 500000)
                {
                    y.skidka = "25";

                }
                else if (i > 149999)
                {
                    y.skidka = "20";
                }

                else if (i > 49999)
                {
                    y.skidka = "10";
                }
                else if (i > 4999)
                {
                    y.skidka = "5";
                }

              else  if (i > 9999)
                {
                    y.skidka = "0";

                }

                else
                {
                    y.skidka = "0";
                }




            }



            lst.ItemsSource = list;


        }
    }
}
