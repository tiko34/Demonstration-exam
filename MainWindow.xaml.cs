using System.Windows;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

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
            met:
                if (i > 9999) 
                {
                    connection.Open();

                    y.skidka = "0";
                    connection.Close();
                }
                 else if (i>4999)
                {
                    connection.Open();

                    y.skidka = "5";
                    connection.Close();
                }
                else if (i>49999)
                {
                    connection.Open();

                    y.skidka = "10";
                    connection.Close();
                }
                else if (i > 149999)
                {
                    connection.Open();

                    y.skidka = "20";
                    connection.Close();
                }
                else if (i>500000)
                {
                    connection.Open();

                    y.skidka = "25";
                    connection.Close();
                }
                else
                {
                    connection.Open();

                    y.skidka = "0";
                    connection.Close();
                }
              



            }
            


            lst.ItemsSource = list;


        }
    }
}
