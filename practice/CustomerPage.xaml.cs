using practice.airDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
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

namespace practice
{
    public partial class CustomerPage : Page
    {
        aircompanyTableAdapter aircompany = new aircompanyTableAdapter();
        AirPointTableAdapter AirPoint = new AirPointTableAdapter();
        tariffTableAdapter tariff = new tariffTableAdapter();
        customerTableAdapter customer = new customerTableAdapter();
        ticketTableAdapter ticket = new ticketTableAdapter();

        public CustomerPage()
        {
            InitializeComponent();
            grid1.ItemsSource = aircompany.GetData();
            grid9.ItemsSource = AirPoint.GetData();
            grid10.ItemsSource = customer.GetData();
            grid11.ItemsSource = tariff.GetData();
            grid12.ItemsSource = ticket.GetData();
        }
    }
}
