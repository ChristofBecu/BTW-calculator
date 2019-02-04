using System;
using System.Collections.Generic;
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

namespace WpfApp1
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

        private void WndStart_Loaded(object sender, RoutedEventArgs e)
        {
            lstBtwInclExcl.Items.Add("inclusief");
            lstBtwInclExcl.Items.Add("exclusief");

            lstBtwTarieven.Items.Add(6);
            lstBtwTarieven.Items.Add(12);
            lstBtwTarieven.Items.Add(21);

            lstBtwInclExcl.SelectedIndex = 0;
            lstBtwTarieven.SelectedIndex = 0;
        }

        private void BtnBereken_Click(object sender, RoutedEventArgs e)
        {
            int btwTarief = Convert.ToInt16(lstBtwTarieven.SelectedItem);
            decimal nettoBedrag = 0;
            decimal btw = 0;
            decimal brutoBedrag = 0;

            if (lstBtwInclExcl.SelectedItem == "exclusief")
            {
                nettoBedrag = Convert.ToDecimal(txtBedrag.Text);      
                btw = nettoBedrag / 100 * btwTarief;
                brutoBedrag = nettoBedrag + btw;
            }
            if (lstBtwInclExcl.SelectedItem == "inclusief")
            {
                brutoBedrag = Convert.ToDecimal(txtBedrag.Text);
                btw = brutoBedrag / (100 + btwTarief) * btwTarief ;
                nettoBedrag = brutoBedrag / (100 + btwTarief) * 100;
            }
            tbkBereken.Text = "netto : € " + Math.Round(nettoBedrag, 2) + "\n";
            tbkBereken.Text += "btw " + btwTarief + "%: € " + Math.Round(btw, 2) + "\n";
            tbkBereken.Text += "bruto : € " + Math.Round(brutoBedrag, 2);
        }


    }
}
