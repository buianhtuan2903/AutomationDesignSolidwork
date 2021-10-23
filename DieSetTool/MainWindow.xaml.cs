using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DieSetTool
{
    public partial class MainWindow : System.Windows.Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, RoutedEventArgs e)
        {
            string combobox1data = cbb1.Text;
            string combobox2data = cbb2.Text;
            string combobox3data = cbb3.Text;
            string combobox4data = cbb4.Text;
            string combobox5data = cbb5.Text;
            string combobox6data = cbb6.Text;
            string combobox7data = cbb7.Text;
            string TB1data = TB1.Text;
            string TB2data = TB2.Text;
            string TB3data = TB3.Text;
            string TB4data = TB4.Text;

            if ((radioButton3.IsChecked == false) & (radioButton2.IsChecked == false) & (radioButton1.IsChecked == false))
                    { System.Windows.MessageBox.Show("Please choose mold type"); }
        
               if (radioButton2.IsChecked == true)
                {
                    DEType RuncodeDE = new DEType();
                    RuncodeDE.getdata(combobox1data, combobox2data, combobox3data, combobox4data, combobox5data, combobox6data, combobox7data, TB1data, TB2data, TB3data);
                    RuncodeDE.DETypeCode();
                }

                if (radioButton1.IsChecked == true)
                {
                    SType RuncodeS = new SType();
                    RuncodeS.getdata(combobox1data, combobox2data, combobox3data, combobox4data, combobox5data, combobox6data, combobox7data, TB2data, TB3data);
                    RuncodeS.STypeCode();
                }

                if (radioButton3.IsChecked == true)
                {
                    HType RuncodeH = new HType();
                    RuncodeH.getdata(combobox1data, combobox2data, combobox3data, combobox4data, combobox5data, combobox6data, combobox7data, TB1data, TB2data, TB3data, TB4data);
                    RuncodeH.HTypeCode();
                }
           
        }

        private void openfile_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openfile = new System.Windows.Forms.OpenFileDialog();
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TB2.Text = openfile.FileName;
            }
        }

        private void savefile_Click(object sender, RoutedEventArgs e)
        {
            using (var savefile = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = savefile.ShowDialog();
                TB3.Text = savefile.SelectedPath.ToString();
            }
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            image.Source = new BitmapImage(new Uri("S.jpg", UriKind.Relative));

            TB1.IsEnabled = false;
            label8.IsEnabled = false;
            label9.IsEnabled = false;
            TB4.IsEnabled = false;

            cbb1.Resources.Clear();
            cbb2.Resources.Clear();
            cbb3.Resources.Clear();
            cbb4.Resources.Clear();
            cbb5.Resources.Clear();
            cbb6.Resources.Clear();
            cbb7.Resources.Clear();

            string[] Molddimdata = { "1113", "1313", "1315", "1515", "1518", "1520", "1523", "1525", "1530", "1818", "1820" ,"1823", "1825", "1830", "1835", "2020", "2023", "2025", "2030", "2035", "2040", "2045",
                "2323", "2325", "2327", "2330", "2335", "2340", "2525", "2527", "2530", "2535", "2540", "2545", "2550", "2730", "2735", "2740", "2750", "2930", "2935", "2940", "3030", "3032", "3035", "3040", "3045", "3050", "3055", "3060",
                "3335", "3340", "3345", "3350", "3535", "3540", "3545", "3550", "3555", "3560", "4040", "4045", "4050", "4055", "4060", "4070", "4545", "4550", "4555", "4560", "5050", "5060", "5070",
                "5555", "5560", "5565", "5570", "5575", "5580", "6060", "6065", "6070", "6075", "6080", "6565", "6570", "6575", "6580", "7070", "7075", "7080" };
            cbb1.ItemsSource = Molddimdata;      
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            image.Source = new BitmapImage(new Uri("DE.jpg", UriKind.Relative));
            TB1.IsEnabled = true;
            label8.IsEnabled = true;
            label9.IsEnabled = false;
            TB4.IsEnabled = false;

            cbb1.Resources.Clear();
            cbb2.Resources.Clear();
            cbb3.Resources.Clear();
            cbb4.Resources.Clear();
            cbb5.Resources.Clear();
            cbb6.Resources.Clear();
            cbb7.Resources.Clear();

            string[] Molddimdata = { "1113", "1313", "1315", "1518", "1520", "1523", "1525", "1530", "1820", "1823", "1825", "1830", "1835", "2020", "2023", "2025", "2030", "2035", "2040", "2045",
                "2323", "2325", "2327", "2330", "2335", "2340", "2525", "2527", "2530", "2535", "2540", "2545", "2550", "2730", "2735", "2740", "2750", "2930", "2935", "2940", "3030", "3032", "3035", "3040", "3045", "3050", "3055", "3060",
                "3335", "3340", "3345", "3350", "3535", "3540", "3545", "3550", "3555", "3560", "4040", "4045", "4050", "4055", "4060", "4070", "4545", "4550", "4555", "4560", "5050", "5060", "5070" };
            cbb1.ItemsSource = Molddimdata;

        }

        private void radioButton3_Checked(object sender, RoutedEventArgs e)
        {

            image.Source = new BitmapImage(new Uri("H.jpg", UriKind.Relative));
            TB1.IsEnabled = true;
            label8.IsEnabled = true;
            label9.IsEnabled = true;
            TB4.IsEnabled = true;

            cbb1.Resources.Clear();
            cbb2.Resources.Clear();
            cbb3.Resources.Clear();
            cbb4.Resources.Clear();
            cbb5.Resources.Clear();
            cbb6.Resources.Clear();
            cbb7.Resources.Clear();
            string[] Molddimdata = { "2540", "2545", "2550", "2740", "2750", "3045", "3050", "3055", "3060", "3350", "3550", "3555", "3560" , "4060", "4070" };
            cbb1.ItemsSource = Molddimdata;

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void cbb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbb1.Resources.Clear();
            cbb2.Resources.Clear();
            cbb3.Resources.Clear();
            cbb4.Resources.Clear();
            cbb5.Resources.Clear();
            cbb6.Resources.Clear();
            cbb7.Resources.Clear();
        }


        private void cbb1_DropDownClosed(object sender, EventArgs e)
        {
            if (cbb1.Text == "")
            { System.Windows.MessageBox.Show("Please choose mold dimension"); }
            else
            {
                if (radioButton2.IsChecked == true)
                {
                    cbb2.Resources.Clear();
                    cbb3.Resources.Clear();
                    cbb4.Resources.Clear();
                    cbb5.Resources.Clear();
                    cbb6.Resources.Clear();
                    cbb7.Resources.Clear();

                    // Input CW data
                    if (Convert.ToDouble(cbb1.Text) < 1316)
                    { string[] CWdata = { "175" }; cbb2.ItemsSource = CWdata; }

                    if ((1517 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 1531))
                    { string[] CWdata = { "200", "230" }; cbb2.ItemsSource = CWdata; }

                    if ((1819 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 1836))
                    { string[] CWdata = { "230", "280" }; cbb2.ItemsSource = CWdata; }

                    if ((2019 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2046))
                    { string[] CWdata = { "250", "280" }; cbb2.ItemsSource = CWdata; }

                    if ((2322 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2341))
                    { string[] CWdata = { "280", "350" }; cbb2.ItemsSource = CWdata; }

                    if ((2524 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2551))
                    { string[] CWdata = { "300", "350" }; cbb2.ItemsSource = CWdata; }

                    if ((2729 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2751))
                    { string[] CWdata = { "320", "400" }; cbb2.ItemsSource = CWdata; }

                    if ((2929 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3061))
                    { string[] CWdata = { "350", "400" }; cbb2.ItemsSource = CWdata; }

                    if ((3334 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3561))
                    { string[] CWdata = { "400", "550" }; cbb2.ItemsSource = CWdata; }

                    if ((4039 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 4071))
                    { string[] CWdata = { "450", "550" }; cbb2.ItemsSource = CWdata; }

                    if ((4544 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 4561))
                    { string[] CWdata = { "500", "550" }; cbb2.ItemsSource = CWdata; }

                    if ((5049 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5071))
                    { string[] CWdata = { "600", "700" }; cbb2.ItemsSource = CWdata; }

                    // Input A and B data
                    if (Convert.ToDouble(cbb1.Text) < 1316)
                    {
                        string[] Adata = { "20", "25", "30", "35", "40", "50", "60" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "20", "25", "30", "35", "40", "50", "60" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((1517 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 1836))
                    {
                        string[] Adata = { "20", "25", "30", "35", "40", "50", "60", "70", "80" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "20", "25", "30", "35", "40", "50", "60", "70", "80" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((2019 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2046))
                    {
                        string[] Adata = { "20", "25", "30", "35", "40", "50", "60", "70", "80", "90", "100" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "20", "25", "30", "35", "40", "50", "60", "70", "80", "90", "100" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((2322 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2341))
                    {
                        string[] Adata = { "25", "30", "35", "40", "50", "60", "70", "80", "90", "100" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "25", "30", "35", "40", "50", "60", "70", "80", "90", "100" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((2524 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2551))
                    {
                        string[] Adata = { "25", "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "25", "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((2729 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2941))
                    {
                        string[] Adata = { "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120" }; cbb5.ItemsSource = Bdata;
                    }

                    if (Convert.ToDouble(cbb1.Text) == 3030)
                    {
                        string[] Adata = { "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((3031 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3351))
                    {
                        string[] Adata = { "35", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "35", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((3534 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3561))
                    {
                        string[] Adata = { "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((4039 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5071))
                    {
                        string[] Adata = { "40", "50", "60", "70", "80", "90", "100", "110", "120", "130", "140", "150" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "40", "50", "60", "70", "80", "90", "100", "110", "120", "130", "140", "150" }; cbb5.ItemsSource = Bdata;
                    }

                    // Input S data
                    if (Convert.ToDouble(cbb1.Text) < 1316)
                    { string[] Sdata = { "0", "10", "20", "30" }; cbb4.ItemsSource = Sdata; }

                    if ((1517 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 1836))
                    { string[] Sdata = { "0", "15", "20", "30" }; cbb4.ItemsSource = Sdata; }

                    if ((2019 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2341))
                    { string[] Sdata = { "0", "20", "30", "40", "50" }; cbb4.ItemsSource = Sdata; }

                    if ((2524 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2941))
                    { string[] Sdata = { "0", "25", "30", "40", "50" }; cbb4.ItemsSource = Sdata; }

                    if ((3029 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3351))
                    { string[] Sdata = { "0", "30", "40", "50", "60" }; cbb4.ItemsSource = Sdata; }

                    if ((3534 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 4071))
                    { string[] Sdata = { "0", "35", "40", "50", "60" }; cbb4.ItemsSource = Sdata; }

                    if ((4544 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5071))
                    { string[] Sdata = { "0", "40", "50", "60" }; cbb4.ItemsSource = Sdata; }

                    // Input U data
                    if (Convert.ToDouble(cbb1.Text) < 1316)
                    { string[] Udata = { "0", "25", "30" }; cbb6.ItemsSource = Udata; }

                    if ((1517 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2046))
                    { string[] Udata = { "0", "30", "40" }; cbb6.ItemsSource = Udata; }

                    if ((2322 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2551))
                    { string[] Udata = { "0", "35", "50" }; cbb6.ItemsSource = Udata; }

                    if ((2729 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2941))
                    { string[] Udata = { "0", "40", "50" }; cbb6.ItemsSource = Udata; }

                    if ((3029 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3561))
                    { string[] Udata = { "0", "45", "60" }; cbb6.ItemsSource = Udata; }

                    if ((4039 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 4071))
                    { string[] Udata = { "0", "50", "70" }; cbb6.ItemsSource = Udata; }

                    if ((4544 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5071))
                    { string[] Udata = { "0", "60", "80" }; cbb6.ItemsSource = Udata; }

                    //Input C data
                    if (Convert.ToDouble(cbb1.Text) < 1316)
                    { string[] Cdata = { "40", "50" }; cbb7.ItemsSource = Cdata; }

                    if ((1517 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 1836))
                    { string[] Cdata = { "50", "60", "70", "80" }; cbb7.ItemsSource = Cdata; }

                    if ((2019 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2046))
                    { string[] Cdata = { "50", "60", "70", "80", "90" }; cbb7.ItemsSource = Cdata; }

                    if ((2322 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2551))
                    { string[] Cdata = { "60", "70", "80", "90", "100" }; cbb7.ItemsSource = Cdata; }

                    if ((2729 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2941))
                    { string[] Cdata = { "70", "80", "90", "100" }; cbb7.ItemsSource = Cdata; }

                    if ((3029 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3561))
                    { string[] Cdata = { "70", "80", "90", "100", "110" }; cbb7.ItemsSource = Cdata; }

                    if ((4039 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5071))
                    { string[] Cdata = { "100", "110", "120", "130" }; cbb7.ItemsSource = Cdata; }
                }

                if (radioButton1.IsChecked == true)
                {

                    cbb2.Resources.Clear();
                    cbb3.Resources.Clear();
                    cbb4.Resources.Clear();
                    cbb5.Resources.Clear();
                    cbb6.Resources.Clear();
                    cbb7.Resources.Clear();

                    // Input CW data
                    if (Convert.ToDouble(cbb1.Text) < 1316)
                    { string[] CWdata = { "175" }; cbb2.ItemsSource = CWdata; }

                    if ((1514 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 1531))
                    { string[] CWdata = { "200", "230" }; cbb2.ItemsSource = CWdata; }

                    if ((1817 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 1836))
                    { string[] CWdata = { "230", "280" }; cbb2.ItemsSource = CWdata; }

                    if ((2019 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2046))
                    { string[] CWdata = { "250", "280" }; cbb2.ItemsSource = CWdata; }

                    if ((2322 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2341))
                    { string[] CWdata = { "280", "350" }; cbb2.ItemsSource = CWdata; }

                    if ((2524 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2551))
                    { string[] CWdata = { "300", "350" }; cbb2.ItemsSource = CWdata; }

                    if ((2729 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2751))
                    { string[] CWdata = { "320", "400" }; cbb2.ItemsSource = CWdata; }

                    if ((2929 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3061))
                    { string[] CWdata = { "350", "400" }; cbb2.ItemsSource = CWdata; }

                    if ((3334 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3561))
                    { string[] CWdata = { "400", "550" }; cbb2.ItemsSource = CWdata; }

                    if ((4039 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 4071))
                    { string[] CWdata = { "450", "550" }; cbb2.ItemsSource = CWdata; }

                    if ((4544 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 4561))
                    { string[] CWdata = { "500", "550" }; cbb2.ItemsSource = CWdata; }

                    if ((5049 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5581))
                    { string[] CWdata = { "600", "700" }; cbb2.ItemsSource = CWdata; }

                    if ((6059 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 6081))
                    { string[] CWdata = { "700" }; cbb2.ItemsSource = CWdata; }

                    if ((6564 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 6581))
                    { string[] CWdata = { "750" }; cbb2.ItemsSource = CWdata; }

                    if ((7069 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 7081))
                    { string[] CWdata = { "800", "890" }; cbb2.ItemsSource = CWdata; }

                    // Input A and B data
                    if (Convert.ToDouble(cbb1.Text) < 1316)
                    {
                        string[] Adata = { "20", "25", "30", "35", "40", "50", "60" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "20", "25", "30", "35", "40", "50", "60" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((1514 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 1836))
                    {
                        string[] Adata = { "20", "25", "30", "35", "40", "50", "60", "70", "80" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "20", "25", "30", "35", "40", "50", "60", "70", "80" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((2019 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2046))
                    {
                        string[] Adata = { "20", "25", "30", "35", "40", "50", "60", "70", "80", "90", "100" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "20", "25", "30", "35", "40", "50", "60", "70", "80", "90", "100" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((2322 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2341))
                    {
                        string[] Adata = { "25", "30", "35", "40", "50", "60", "70", "80", "90", "100" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "25", "30", "35", "40", "50", "60", "70", "80", "90", "100" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((2524 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2551))
                    {
                        string[] Adata = { "25", "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "25", "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((2729 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2941))
                    {
                        string[] Adata = { "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120" }; cbb5.ItemsSource = Bdata;
                    }

                    if (Convert.ToDouble(cbb1.Text) == 3030)
                    {
                        string[] Adata = { "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((3031 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3351))
                    {
                        string[] Adata = { "35", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "35", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((3534 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3561))
                    {
                        string[] Adata = { "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((4039 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5071))
                    {
                        string[] Adata = { "40", "50", "60", "70", "80", "90", "100", "110", "120", "130", "140", "150" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "40", "50", "60", "70", "80", "90", "100", "110", "120", "130", "140", "150" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((5554 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5571))
                    {
                        string[] Adata = { "60", "70", "80", "90", "100", "110", "120", "130", "140", "150", "160", "180", "200", "220", "250" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "60", "70", "80", "90", "100", "110", "120", "130", "140", "150", "160", "180", "200" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((5574 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5581))
                    {
                        string[] Adata = { "80", "90", "100", "110", "120", "130", "140", "150", "160", "180", "200", "220", "250" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "80", "90", "100", "110", "120", "130", "140", "150", "160", "180", "200" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((6059 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 6071))
                    {
                        string[] Adata = { "60", "70", "80", "90", "100", "110", "120", "130", "140", "150", "160", "180", "200", "220", "250" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "60", "70", "80", "90", "100", "110", "120", "130", "140", "150", "160", "180", "200" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((6074 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 7081))
                    {
                        string[] Adata = { "100", "110", "120", "130", "140", "150", "160", "180", "200", "220", "250" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "100", "110", "120", "130", "140", "150", "160", "180", "200" }; cbb5.ItemsSource = Bdata;
                    }

                    // Input S data
                    if (Convert.ToDouble(cbb1.Text) < 1316)
                    { string[] Sdata = { "0", "10", "20", "30" }; cbb4.ItemsSource = Sdata; }

                    if ((1514 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 1836))
                    { string[] Sdata = { "0", "15", "20", "30", "40" }; cbb4.ItemsSource = Sdata; }

                    if ((2019 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2341))
                    { string[] Sdata = { "0", "20", "30", "40", "50" }; cbb4.ItemsSource = Sdata; }

                    if ((2524 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2941))
                    { string[] Sdata = { "0", "25", "30", "40", "50" }; cbb4.ItemsSource = Sdata; }

                    if ((3029 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3351))
                    { string[] Sdata = { "0", "30", "40", "50", "60" }; cbb4.ItemsSource = Sdata; }

                    if ((3534 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 4071))
                    { string[] Sdata = { "0", "35", "40", "50", "60" }; cbb4.ItemsSource = Sdata; }

                    if ((4544 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5071))
                    { string[] Sdata = { "0", "40", "50", "60" }; cbb4.ItemsSource = Sdata; }

                    if ((5554 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5581))
                    { string[] Sdata = { "0", "40" }; cbb4.ItemsSource = Sdata; }

                    if ((6059 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 6081))
                    { string[] Sdata = { "0", "50" }; cbb4.ItemsSource = Sdata; }

                    if ((6564 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 7081))
                    { string[] Sdata = { "0", "60" }; cbb4.ItemsSource = Sdata; }

                    // Input U data
                    if (Convert.ToDouble(cbb1.Text) < 1316)
                    { string[] Udata = { "0", "25", "30" }; cbb6.ItemsSource = Udata; }

                    if ((1514 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2046))
                    { string[] Udata = { "0", "30", "40" }; cbb6.ItemsSource = Udata; }

                    if ((2322 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2551))
                    { string[] Udata = { "0", "35", "50" }; cbb6.ItemsSource = Udata; }

                    if ((2729 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2941))
                    { string[] Udata = { "0", "40", "50" }; cbb6.ItemsSource = Udata; }

                    if ((3029 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3561))
                    { string[] Udata = { "0", "45", "60" }; cbb6.ItemsSource = Udata; }

                    if ((4039 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 4071))
                    { string[] Udata = { "0", "50", "70" }; cbb6.ItemsSource = Udata; }

                    if ((4544 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5071))
                    { string[] Udata = { "0", "60", "80" }; cbb6.ItemsSource = Udata; }

                    if ((5554 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5581))
                    { string[] Udata = { "0", "70" }; cbb6.ItemsSource = Udata; }

                    if ((6059 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 6081))
                    { string[] Udata = { "0", "80" }; cbb6.ItemsSource = Udata; }

                    if ((6564 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 6581))
                    { string[] Udata = { "0", "90" }; cbb6.ItemsSource = Udata; }

                    if ((7069 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 7081))
                    { string[] Udata = { "0", "100" }; cbb6.ItemsSource = Udata; }

                    //Input C data
                    if (Convert.ToDouble(cbb1.Text) < 1316)
                    { string[] Cdata = { "40", "50" }; cbb7.ItemsSource = Cdata; }

                    if ((1514 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 1836))
                    { string[] Cdata = { "50", "60", "70", "80" }; cbb7.ItemsSource = Cdata; }

                    if ((2019 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2046))
                    { string[] Cdata = { "50", "60", "70", "80", "90" }; cbb7.ItemsSource = Cdata; }

                    if ((2322 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2551))
                    { string[] Cdata = { "60", "70", "80", "90", "100" }; cbb7.ItemsSource = Cdata; }

                    if ((2729 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2941))
                    { string[] Cdata = { "70", "80", "90", "100" }; cbb7.ItemsSource = Cdata; }

                    if ((3029 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3561))
                    { string[] Cdata = { "70", "80", "90", "100", "110" }; cbb7.ItemsSource = Cdata; }

                    if ((4039 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 5071))
                    { string[] Cdata = { "100", "110", "120", "130" }; cbb7.ItemsSource = Cdata; }

                    if ((5554 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 7081))
                    { string[] Cdata = { "100", "120", "150", "170" }; cbb7.ItemsSource = Cdata; }

                }
                if (radioButton3.IsChecked == true)
                {
                    cbb2.Resources.Clear();
                    cbb3.Resources.Clear();
                    cbb4.Resources.Clear();
                    cbb5.Resources.Clear();
                    cbb6.Resources.Clear();
                    cbb7.Resources.Clear();

                    // Input CWdata
                    if (Convert.ToDouble(cbb1.Text) < 2551)
                    { string[] CWdata = { "300", "350" }; cbb2.ItemsSource = CWdata; }

                    if ((2739 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2751))
                    { string[] CWdata = { "320", "400" }; cbb2.ItemsSource = CWdata; }

                    if ((3044 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3061))
                    { string[] CWdata = { "350", "400" }; cbb2.ItemsSource = CWdata; }

                    if ((3349 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3561))
                    { string[] CWdata = { "400", "550" }; cbb2.ItemsSource = CWdata; }

                    if (4059 < Convert.ToDouble(cbb1.Text))
                    { string[] CWdata = { "450", "550" }; cbb2.ItemsSource = CWdata; }

                    // Input A, B data
                    if (Convert.ToDouble(cbb1.Text) < 2551)
                    {
                        string[] Adata = { "25", "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "25", "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((2739 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2751))
                    {
                        string[] Adata = { "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "30", "35", "40", "50", "60", "70", "80", "90", "100", "110", "120" }; cbb5.ItemsSource = Bdata;
                    }

                    if ((3044 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3351))
                    {
                        string[] Adata = { "35", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "35", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb5.ItemsSource = Bdata;
                    }


                    if ((3549 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 4071))
                    {
                        string[] Adata = { "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb3.ItemsSource = Adata;
                        string[] Bdata = { "40", "50", "60", "70", "80", "90", "100", "110", "120", "130" }; cbb5.ItemsSource = Bdata;
                    }

                    // Input S data
                    if (Convert.ToDouble(cbb1.Text) < 2751)
                    { string[] Sdata = { "0", "25", "30", "40", "50" }; cbb4.ItemsSource = Sdata; }

                    if ((3044 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3351))
                    { string[] Sdata = { "0", "30", "40", "50", "60" }; cbb4.ItemsSource = Sdata; }

                    if ((3549 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3561))
                    { string[] Sdata = { "0", "35", "40", "50", "60" }; cbb4.ItemsSource = Sdata; }

                    // Input U data
                    if (Convert.ToDouble(cbb1.Text) < 2551)
                    { string[] Udata = { "0", "35", "50" }; cbb6.ItemsSource = Udata; }

                    if ((2739 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2751))
                    { string[] Udata = { "0", "40", "50" }; cbb6.ItemsSource = Udata; }

                    if ((3044 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3561))
                    { string[] Udata = { "0", "45", "60" }; cbb6.ItemsSource = Udata; }

                    if (4059 < Convert.ToDouble(cbb1.Text))
                    { string[] Udata = { "0", "50", "70" }; cbb6.ItemsSource = Udata; }

                    // Input C data
                    if (Convert.ToDouble(cbb1.Text) < 2551)
                    { string[] Cdata = { "60", "70", "80", "90", "100" }; cbb7.ItemsSource = Cdata; }

                    if ((2739 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 2751))
                    { string[] Cdata = { "70", "80", "90", "100" }; cbb7.ItemsSource = Cdata; }

                    if ((3044 < Convert.ToDouble(cbb1.Text)) & (Convert.ToDouble(cbb1.Text) < 3561))
                    { string[] Cdata = { "70", "80", "90", "100", "110" }; cbb7.ItemsSource = Cdata; }

                    if (4059 < Convert.ToDouble(cbb1.Text))
                    { string[] Cdata = { "100", "110", "120", "130" }; cbb7.ItemsSource = Cdata; }

                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //double abc = DateTime.Now.ToOADate();
            // Setting end day trial
            //if (DateTime.Now.ToOADate() >= 43800)
            //{
               
            //    TB1.IsEnabled = false;
            //    TB2.IsEnabled = false;
            //    TB3.IsEnabled = false;
            //    TB4.IsEnabled = false;
            //    cbb1.IsEnabled = false;
            //    cbb2.IsEnabled = false;
            //    cbb3.IsEnabled = false;
            //    cbb4.IsEnabled = false;
            //    cbb5.IsEnabled = false;
            //    cbb6.IsEnabled = false;
            //    cbb7.IsEnabled = false;
            //    radioButton1.IsEnabled = false;
            //    radioButton2.IsEnabled = false;
            //    radioButton3.IsEnabled = false;
            //    button1.IsEnabled = false;
            //    openfile.IsEnabled = false;
            //    savefile.IsEnabled = false;
            //    System.Windows.MessageBox.Show("Your free trial has ended. Please contact buianhtuan2903@gmail.com for purchase license");
            //}
        }

    }
}

    