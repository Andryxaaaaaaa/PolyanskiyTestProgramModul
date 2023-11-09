using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

namespace Polyanskiy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PolyanskiyTestEntities dbcontext = new PolyanskiyTestEntities();
        public MainWindow()
        {
            InitializeComponent();
            dg1.ItemsSource = dbcontext.Users.ToArray();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Users prog = new Users();
            prog.id = Convert.ToInt32(tb1.Text);
            prog.Role = tb2.Text;
            prog.FIO =  tb3.Text;
            prog.Mail = tb4.Text;;
            prog.Pass = tb5.Text; ;
            dbcontext.Users.Add(prog);
            dbcontext.SaveChanges();
            dg1.ItemsSource = dbcontext.Users.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            long sUpid = Convert.ToInt64(tb1.Text);
            var selectUpId = dbcontext.Users.Where(w => w.id == sUpid).FirstOrDefault();
            selectUpId.id = Convert.ToInt32(tb1.Text);
            selectUpId.Role = tb2.Text;
            selectUpId.FIO  = tb3.Text;
            selectUpId.Mail = tb4.Text;
            selectUpId.Pass = tb5.Text;
            dbcontext.SaveChanges();
            dg1.ItemsSource = dbcontext.Users.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Users error = (Users)dg1.SelectedItem;
            dbcontext.Users.Remove(error);
            dbcontext.SaveChanges();
            dg1.ItemsSource = dbcontext.Users.ToList();
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Users us =(Users)dg1.SelectedItem;
            if (us == null)
                return;

            try
            {
                tb1.Text = us.id.ToString();
                tb2.Text = us.Role.ToString();
                tb3.Text = us.FIO.ToString();
                tb4.Text = us.Mail.ToString();
                tb5.Text = us.Pass.ToString();

            }
            catch (Exception ex) 
            {
                Trace.WriteLine(ex.Message);
            }
                    
        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
