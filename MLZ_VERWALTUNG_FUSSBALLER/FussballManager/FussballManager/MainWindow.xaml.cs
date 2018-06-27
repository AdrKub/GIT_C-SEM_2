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
            EnableChangeOrInputData(false);
        }

        private void EnableChangeOrInputData(bool mode)
        {
            grdPlayerData.IsEnabled = mode;
        }

        private void lstvTeamPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstvTeamPlayers.SelectedIndex > -1)
            {
                viewModel.LoadPlayer(lstvTeamPlayers.SelectedIndex);
                cmbPosition.SelectedIndex = viewModel.GetPlayerPositionIndex();
                cmbTeam.SelectedIndex = viewModel.GetPlayerTeamIndex();
            }
        }

        private void lstvTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstvTeams.SelectedIndex > -1)
            {
                viewModel.LoadAllTeamPlayers(lstvTeams.SelectedIndex);
                cmbPosition.SelectedIndex = -1;
                cmbTeam.SelectedIndex = -1;
            }
        }

        private void btnFreePlayers_Click(object sender, RoutedEventArgs e)
        {
            viewModel.LoadAllTeamPlayers(-1);
        }
    }
}
