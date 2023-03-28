using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using practice.airDataSetTableAdapters;

namespace practice
{
    public partial class AdminPage : Page
    {
    aircompanyTableAdapter aircompany = new aircompanyTableAdapter();
    airportTableAdapter airport = new airportTableAdapter();
    professionTableAdapter profession = new professionTableAdapter();
    AirPointTableAdapter AirPoint = new AirPointTableAdapter();
    tariffTableAdapter tariff = new tariffTableAdapter();
    customerTableAdapter customer = new customerTableAdapter();
    usersTableAdapter users = new usersTableAdapter();
    airport_aircompanyTableAdapter airport_aircompany = new airport_aircompanyTableAdapter();
    hangarTableAdapter hangar = new hangarTableAdapter();
    planeTableAdapter plane = new planeTableAdapter();
    workerTableAdapter worker = new workerTableAdapter();
    ticketTableAdapter ticket = new ticketTableAdapter();
        int sw = 0; int idAirc = 0; int idProf = 0; int idUsers = 0; int idAirp = 0; int idAirc1 = 0; int idAirp1 = 0; int idHan = 0; int idAirc2 = 0; int idCus = 0; int idAirp2 = 0; int idTar = 0;
        public AdminPage()
        {
            InitializeComponent();
            grid1.ItemsSource = aircompany.GetData();
            grid2.ItemsSource = worker.GetData();
            grid3.ItemsSource = profession.GetData();
            grid4.ItemsSource = users.GetData();
            grid5.ItemsSource = airport_aircompany.GetData();
            grid6.ItemsSource = airport.GetData();
            grid7.ItemsSource = hangar.GetData();
            grid8.ItemsSource = plane.GetData();
            grid9.ItemsSource = AirPoint.GetData();
            grid10.ItemsSource = customer.GetData();
            grid11.ItemsSource = tariff.GetData();
            grid12.ItemsSource = ticket.GetData();
            cmb21.ItemsSource = aircompany.GetData();
            cmb21.SelectedIndex = 0;
            cmb21.DisplayMemberPath = "aircompany_name";
            cmb22.ItemsSource = profession.GetData();
            cmb22.SelectedIndex= 0;
            cmb22.DisplayMemberPath = "profession_name";
            cmb23.ItemsSource = users.GetData();
            cmb23.SelectedIndex= 0;
            cmb23.DisplayMemberPath = "users_login";
            cmb51.ItemsSource = aircompany.GetData();
            cmb51.SelectedIndex= 0;
            cmb51.DisplayMemberPath = "aircompany_name";
            cmb52.ItemsSource = airport.GetData();
            cmb52.SelectedIndex= 0;
            cmb52.DisplayMemberPath = "airport_name";
            cmb7.ItemsSource = airport.GetData();
            cmb7.SelectedIndex= 0;
            cmb7.DisplayMemberPath = "airport_name";
            cmb8.ItemsSource = hangar.GetData();
            cmb8.SelectedIndex= 0;
            cmb8.DisplayMemberPath = "hangar_number";
            cmb121.ItemsSource = aircompany.GetData();
            cmb121.SelectedIndex= 0;
            cmb121.DisplayMemberPath = "aircompany_name";
            cmb122.ItemsSource = customer.GetData();
            cmb122.SelectedIndex= 0;
            cmb122.DisplayMemberPath = "customer_surname";
            cmb123.ItemsSource = AirPoint.GetData();
            cmb123.SelectedIndex= 0;
            cmb123.DisplayMemberPath = "AirPoint_B";
            cmb124.ItemsSource = tariff.GetData();
            cmb124.SelectedIndex= 0;
            cmb124.DisplayMemberPath = "tariff_name";
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            
            if (text11.Text.Trim() == "" || text12.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их добавления";
            }
            else 
            {
                Errtxt.Content = "";
                aircompany.InsertAircompany(text11.Text, text12.Text);
                grid1.ItemsSource = aircompany.GetData();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (text11.Text.Trim() == "" || text12.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их изменения";
            }
            else
            {
                Errtxt.Content = "";
                object id = (grid1.SelectedItem as DataRowView).Row[0];
                aircompany.UpdateAircompany(text11.Text, text12.Text, Convert.ToInt32(id));
                grid1.ItemsSource = aircompany.GetData();
            }
           
        }
        private void grid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sw == 0)
            {
                text11.Text = (grid1.SelectedItem as DataRowView).Row[1].ToString();
                text12.Text = (grid1.SelectedItem as DataRowView).Row[2].ToString();
                sw = 1;
            }
            else sw = 0;
        }
        private void button13_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid1.SelectedItem as DataRowView).Row[0];
            aircompany.DeleteAircompany(Convert.ToInt32(id));
            grid1.ItemsSource = aircompany.GetData();
        }
        private void cmb21_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cmb21.SelectedItem as DataRowView).Row[0];
            idAirc = (int)cell;
        }
        private void cmb22_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cmb22.SelectedItem as DataRowView).Row[0];
            idProf = (int)cell;
        }
        private void cmb23_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cmb23.SelectedItem as DataRowView).Row[0];
            idUsers = (int)cell;
        }
        private void button21_Click(object sender, RoutedEventArgs e)
        {
            if (text21.Text.Trim() == "" || text22.Text.Trim() == "" || text23.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их добавления";
            }
            else
            {
                Errtxt.Content = "";
                worker.InsertWorker(text21.Text, text22.Text, text23.Text, idAirc, idProf, idUsers);
                grid2.ItemsSource = worker.GetData();
            }
        }
        private void button22_Click(object sender, RoutedEventArgs e)
        {
            if (text21.Text.Trim() == "" || text22.Text.Trim() == "" || text23.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их изменения";
            }
            else
            {
                Errtxt.Content = "";
                object id = (grid2.SelectedItem as DataRowView).Row[0];
                worker.UpdateWorker(text21.Text, text22.Text, text23.Text, idAirc, idProf, idUsers, Convert.ToInt32(id));
                grid2.ItemsSource = worker.GetData();
            }
            
        }
        private void button23_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid2.SelectedItem as DataRowView).Row[0];
            worker.DeleteWorker(Convert.ToInt32(id));
            grid2.ItemsSource = worker.GetData();
        }
        private void grid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sw == 0)
            {
                text21.Text = (grid2.SelectedItem as DataRowView).Row[1].ToString();
                text22.Text = (grid2.SelectedItem as DataRowView).Row[2].ToString();
                text23.Text = (grid2.SelectedItem as DataRowView).Row[3].ToString();
                sw = 1;
            }
            else sw = 0;
        }

        private void button31_Click(object sender, RoutedEventArgs e)
        {
            if (text3.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их добавления";
            }
            else
            {
                Errtxt.Content = "";
                profession.InsertProfession(text3.Text);
                grid3.ItemsSource = profession.GetData();
            }
            
        }
        private void button32_Click(object sender, RoutedEventArgs e)
        {
            if (text3.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их изменения";
            }
            else
            {
                Errtxt.Content = "";
                object id = (grid3.SelectedItem as DataRowView).Row[0];
                profession.UpdateProfession(text3.Text, Convert.ToInt32(id));
                grid3.ItemsSource = profession.GetData();
            }
            
        }
        private void button33_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid3.SelectedItem as DataRowView).Row[0];
            profession.DeleteProfession(Convert.ToInt32(id));
            grid3.ItemsSource = profession.GetData();
        }
        private void grid3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sw == 0)
            {
                text3.Text = (grid3.SelectedItem as DataRowView).Row[1].ToString();
                sw = 1;
            }
            else sw = 0;
        }
        private void button41_Click(object sender, RoutedEventArgs e)
        {
            if (text41.Text.Trim() == "" || text42.Text.Trim() == "" || text43.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их добавления";
            }
            else
            {
                Errtxt.Content = "";
                users.InsertUsers(text41.Text, text42.Text, text43.Text);
                grid4.ItemsSource = users.GetData();
            }
            
        }
        private void button42_Click(object sender, RoutedEventArgs e)
        {
            if (text41.Text.Trim() == "" || text42.Text.Trim() == "" || text43.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их изменения";
            }
            else
            {
                Errtxt.Content = "";
                object id = (grid4.SelectedItem as DataRowView).Row[0];
                users.UpdateUsers(text41.Text, text42.Text, text43.Text, Convert.ToInt32(id));
                grid3.ItemsSource = profession.GetData();
            }
            
        }
        private void button43_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid4.SelectedItem as DataRowView).Row[0];
            users.DeleteUsers(Convert.ToInt32(id));
            grid4.ItemsSource = users.GetData();
        }
        private void grid4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sw == 0)
            {
                text41.Text = (grid4.SelectedItem as DataRowView).Row[1].ToString();
                text42.Text = (grid4.SelectedItem as DataRowView).Row[2].ToString();
                text43.Text = (grid4.SelectedItem as DataRowView).Row[3].ToString();
                sw = 1;
            }
            else sw = 0;
        }

        private void button51_Click(object sender, RoutedEventArgs e)
        {
            airport_aircompany.InsertAirport_aircompany(idAirc1, idAirp);
            grid5.ItemsSource = airport_aircompany.GetData();
        }

        private void button52_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid5.SelectedItem as DataRowView).Row[0];
            airport_aircompany.UpdateAirport_aircompany(idAirc1, idAirp, Convert.ToInt32(id));
            grid5.ItemsSource = airport_aircompany.GetData();
        }

        private void button53_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid5.SelectedItem as DataRowView).Row[0];
            airport_aircompany.DeleteAirport_aircompany(Convert.ToInt32(id));
            grid5.ItemsSource = airport_aircompany.GetData();
        }

        private void cmb51_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cmb51.SelectedItem as DataRowView).Row[0];
            idAirc1 = (int)cell;
        }

        private void cmb52_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cmb52.SelectedItem as DataRowView).Row[0];
            idAirp = (int)cell;
        }

        private void button61_Click(object sender, RoutedEventArgs e)
        {
            if (text61.Text.Trim() == "" || text62.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их добавления";
            }
            else
            {
                Errtxt.Content = "";
                airport.InsertAirport(text61.Text, text62.Text);
                grid6.ItemsSource = airport.GetData();
            }
            
        }

        private void button62_Click(object sender, RoutedEventArgs e)
        {
            if (text61.Text.Trim() == "" || text62.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их изменения";
            }
            else
            {
                Errtxt.Content = "";
                object id = (grid6.SelectedItem as DataRowView).Row[0];
                airport.UpdateAirport(text61.Text, text62.Text, Convert.ToInt32(id));
                grid6.ItemsSource = airport.GetData();
            }
           
        }

        private void button63_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid6.SelectedItem as DataRowView).Row[0];
            airport.DeleteAirport(Convert.ToInt32(id));
            grid6.ItemsSource = airport.GetData();
        }

        private void grid6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sw == 0)
            {
                text61.Text = (grid6.SelectedItem as DataRowView).Row[1].ToString();
                text62.Text = (grid6.SelectedItem as DataRowView).Row[2].ToString();
                sw = 1;
            }
            else sw = 0;
        }

        private void button71_Click(object sender, RoutedEventArgs e)
        {
            if (text7.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их добавления";
            }
            else
            {
                Errtxt.Content = "";
                int a = Convert.ToInt32(text7.Text);
                hangar.InsertHangar(a, idAirp1);
                grid7.ItemsSource = hangar.GetData();
            }
            
        }

        private void button72_Click(object sender, RoutedEventArgs e)
        {
            if (text7.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их изменения";
            }
            else
            {
                Errtxt.Content = "";
                int a = Convert.ToInt32(text7.Text);
                object id = (grid7.SelectedItem as DataRowView).Row[0];
                hangar.UpdateHangar(a, idAirp1, Convert.ToInt32(id));
                grid7.ItemsSource = hangar.GetData();
            }
            
        }

        private void button73_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid7.SelectedItem as DataRowView).Row[0];
            hangar.DeleteHangar(Convert.ToInt32(id));
            grid7.ItemsSource = hangar.GetData();
        }

        private void grid7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sw == 0)
            {
                text7.Text = (grid7.SelectedItem as DataRowView).Row[1].ToString();
                sw = 1;
            }
            else sw = 0;
        }

        private void cmb7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cmb7.SelectedItem as DataRowView).Row[0];
            idAirp1 = (int)cell;
        }

        private void button81_Click(object sender, RoutedEventArgs e)
        {
            if (text81.Text.Trim() == "" || text82.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их добавления";
            }
            else
            {
                Errtxt.Content = "";
                plane.InsertPlane(text81.Text, text82.Text, idHan);
                grid8.ItemsSource = plane.GetData();
            }
            
        }

        private void button82_Click(object sender, RoutedEventArgs e)
        {
            if (text81.Text.Trim() == "" || text82.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их изменения";
            }
            else
            {
                Errtxt.Content = "";
                object id = (grid8.SelectedItem as DataRowView).Row[0];
                plane.UpdatePlane(text81.Text, text82.Text, idAirp1, Convert.ToInt32(id));
                grid8.ItemsSource = plane.GetData();
            }
            
        }

        private void button83_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid8.SelectedItem as DataRowView).Row[0];
            plane.DeletePlane(Convert.ToInt32(id));
            grid8.ItemsSource = plane.GetData();
        }

        private void grid8_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sw == 0)
            {
                text81.Text = (grid8.SelectedItem as DataRowView).Row[1].ToString();
                text82.Text = (grid8.SelectedItem as DataRowView).Row[2].ToString();

                sw = 1;
            }
            else sw = 0;
        }

        private void cmb8_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cmb8.SelectedItem as DataRowView).Row[0];
            idHan = (int)cell;
        }

        private void button91_Click(object sender, RoutedEventArgs e)
        {
            if (text91.Text.Trim() == "" || text92.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их добавления";
            }
            else
            {
                Errtxt.Content = "";
                worker.InsertWorker(text21.Text, text22.Text, text23.Text, idAirc, idProf, idUsers);
                grid2.ItemsSource = worker.GetData();
            }
            
        }

        private void button92_Click(object sender, RoutedEventArgs e)
        {
            if (text91.Text.Trim() == "" || text92.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их изменения";
            }
            else
            {
                Errtxt.Content = "";
                object id = (grid9.SelectedItem as DataRowView).Row[0];
                AirPoint.UpdateAirPoint(text91.Text, text92.Text, Convert.ToInt32(id));
                grid9.ItemsSource = AirPoint.GetData();
            }
            
        }

        private void button93_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid9.SelectedItem as DataRowView).Row[0];
            AirPoint.DeleteAirPoint(Convert.ToInt32(id));
            grid9.ItemsSource = AirPoint.GetData();
        }

        private void grid9_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sw == 0)
            {
                text91.Text = (grid9.SelectedItem as DataRowView).Row[1].ToString();
                text92.Text = (grid9.SelectedItem as DataRowView).Row[2].ToString();

                sw = 1;
            }
            else sw = 0;
        }

        private void button101_Click(object sender, RoutedEventArgs e)
        {
            if (text101.Text.Trim() == "" || text102.Text.Trim() == "" || text103.Text.Trim() == "" || text104.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их добавления";
            }
            else
            {
                Errtxt.Content = "";
                customer.InsertCustomer(text101.Text, text102.Text, text103.Text, text104.Text);
                grid10.ItemsSource = customer.GetData();
            }
            
        }

        private void button102_Click(object sender, RoutedEventArgs e)
        {
            if (text101.Text.Trim() == "" || text102.Text.Trim() == "" || text103.Text.Trim() == "" || text104.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их изменения";
            }
            else
            {
                Errtxt.Content = "";
                object id = (grid10.SelectedItem as DataRowView).Row[0];
                customer.UpdateCustomer(text101.Text, text102.Text, text103.Text, text104.Text, Convert.ToInt32(id));
                grid10.ItemsSource = customer.GetData();
            }
            
        }

        private void button103_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid10.SelectedItem as DataRowView).Row[0];
            customer.DeleteCustomer(Convert.ToInt32(id));
            grid10.ItemsSource = customer.GetData();
        }

        private void grid10_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sw == 0)
            {
                text101.Text = (grid10.SelectedItem as DataRowView).Row[1].ToString();
                text102.Text = (grid10.SelectedItem as DataRowView).Row[2].ToString();
                text103.Text = (grid10.SelectedItem as DataRowView).Row[3].ToString();
                text104.Text = (grid10.SelectedItem as DataRowView).Row[4].ToString();
                sw = 1;
            }
            else sw = 0;
        }

        private void button111_Click(object sender, RoutedEventArgs e)
        {
            if (text111.Text.Trim() == "" || text112.Text.Trim() == "" || text113.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их добавления";
            }
            else
            {
                Errtxt.Content = "";
                tariff.InsertTariff(text111.Text, text112.Text, text113.Text);
                grid11.ItemsSource = tariff.GetData();
            }
            
        }

        private void button112_Click(object sender, RoutedEventArgs e)
        {
            if (text111.Text.Trim() == "" || text112.Text.Trim() == "" || text113.Text.Trim() == "")
            {
                Errtxt.Content = "Укажите значения для их изменения";
            }
            else
            {
                Errtxt.Content = "";
                object id = (grid11.SelectedItem as DataRowView).Row[0];
                tariff.UpdateTariff(text111.Text, text112.Text, text113.Text, Convert.ToInt32(id));
                grid11.ItemsSource = tariff.GetData();
            }
            
        }

        private void button113_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid11.SelectedItem as DataRowView).Row[0];
            customer.DeleteCustomer(Convert.ToInt32(id));
            grid11.ItemsSource = tariff.GetData();
        }

        private void grid11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sw == 0)
            {
                text111.Text = (grid11.SelectedItem as DataRowView).Row[1].ToString();
                text112.Text = (grid11.SelectedItem as DataRowView).Row[2].ToString();
                text113.Text = (grid11.SelectedItem as DataRowView).Row[3].ToString();
                sw = 1;
            }
            else sw = 0;
        }

        private void button121_Click(object sender, RoutedEventArgs e)
        {
            ticket.InsertTicket(idAirc2, idCus, idAirp2, idTar);
            grid12.ItemsSource = ticket.GetData();
        }

        private void button122_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid12.SelectedItem as DataRowView).Row[0];
            ticket.UpdateTicket(idAirc2, idCus, idAirp2, idTar, Convert.ToInt32(id));
            grid12.ItemsSource = ticket.GetData();
        }

        private void button123_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid12.SelectedItem as DataRowView).Row[0];
            ticket.DeleteTicket(Convert.ToInt32(id));
            grid12.ItemsSource = ticket.GetData();
        }

        private void cmb121_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cmb121.SelectedItem as DataRowView).Row[0];
            idAirc2 = (int)cell;
        }

        private void cmb122_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cmb122.SelectedItem as DataRowView).Row[0];
            idCus = (int)cell;
        }

        private void cmb123_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cmb123.SelectedItem as DataRowView).Row[0];
            idAirp2 = (int)cell;
        }

        private void cmb124_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cmb124.SelectedItem as DataRowView).Row[0];
            idTar = (int)cell;
        }
    }
}
