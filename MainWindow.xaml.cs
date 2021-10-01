using System.Windows;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;

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
            lst.ItemsSource = bdagent.GetContext().Agent.ToList();
            //SqlCommand sc = new SqlCommand(ToString());
          //  sc.CommandText = "SELECT*FROM AgentTypeID";
            
        }
    }
}
