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

namespace DataBinding
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Car DisplayCar { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DisplayCar = new Car()
            {
                Brand = "Subaru",
                Model = "Levorg",
                Color = "Blue"
            };

            //--Beispiel 1.A (bevorzugt)
            //--DATENBINDUNG AN DAS VATER ELEMENT (ALLE CONTROLS ERBEN)
            //this.DataContext = DisplayCar;


            //--Beispiel 1.B
            //--EINZELNE DATENANBINDUNG
            //tbxBrand.DataContext = DisplayCar;
            //tbxModel.DataContext = DisplayCar;
            //lblColor.DataContext = DisplayCar;
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            DisplayCar.Brand = "Nissan".ToUpper();
            DisplayCar.Model = "GTX".ToUpper();
            DisplayCar.Color = "Grey";
        }
    }
}
