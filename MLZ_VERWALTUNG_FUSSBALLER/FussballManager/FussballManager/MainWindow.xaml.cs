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
using FussballManager.ViewModel;
using FussballManager.Model;

namespace FussballManager
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new TestViewModel();
            DataContext = viewModel;
        }

        private void cmbTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void lstvTeamPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstvTeamPlayers.SelectedIndex > -1)
            {
                //viewModel.SelPlayer = viewModel.SelPlayers[lstvTeamPlayers.SelectedIndex];
                viewModel.SelPlayer.Player = viewModel.SelPlayers[lstvTeamPlayers.SelectedIndex].Player;
            }
        }
    }
}
