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

namespace ErsteWPFApplikation
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            double zahl_A = 0;
            double zahl_B = 0;

            Double.TryParse(TxtBx_NumberValueA.Text, out zahl_A);
            Double.TryParse(TxtBx_NumberValueB.Text, out zahl_B);

            TxtBx_ResultValue.Text = (zahl_A + zahl_B).ToString();
        }
    }
}
