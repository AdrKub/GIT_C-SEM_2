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
using PR_1_GLUEFTUNG.ViewModel;
using PR_1_GLUEFTUNG.Control;

namespace PR_1_GLUEFTUNG
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VentViewModel _vent_1;

        public MainWindow()
        {
            InitializeComponent();
            //_fan_1 = new EngControl();
            //DataContext = _fan_1;
            
            _vent_1 = new VentViewModel();
            _vent_1.Fan_1 = new EngControl();
            _vent_1.Ctrl_1 = new LvlControl(_vent_1.Fan_1);
            //_vent_1 = (VentViewModel) this.DataContext;
            DataContext = _vent_1;
            
        }
    }
}
