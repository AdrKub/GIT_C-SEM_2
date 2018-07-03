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
            GrdPlayerData.IsEnabled = mode;
        }

        private void ChangeActiveMenu(Label activeMenu)
        {
            SolidColorBrush gray = new SolidColorBrush(Color.FromArgb(0xFF, 0xCD, 0xCD, 0xCD));
            SolidColorBrush green = new SolidColorBrush(Color.FromArgb(0xFF, 0xB5, 0xEA, 0x9D));
            LblMenuPlayer.Background = gray;
            LblMenuPlayers.Background = gray;
            LblMenuTeams.Background = gray;
            activeMenu.Background = green;
        }

        private void RefreshPlayerList()
        {
            if (LstvTeams.SelectedIndex > -1)
            {
                ChangeActiveMenu(LblMenuPlayers);
                viewModel.LoadAllTeamPlayers(LstvTeams.SelectedIndex);
                CmbPosition.SelectedIndex = -1;
                CmbTeam.SelectedIndex = -1;
            }
        }

        private void LstvTeamPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(LstvTeamPlayers.SelectedIndex > -1)
            {
                ChangeActiveMenu(LblMenuPlayer);
                viewModel.LoadPlayer(LstvTeamPlayers.SelectedIndex);
                CmbPosition.SelectedIndex = viewModel.GetPlayerPositionIndex();
                CmbTeam.SelectedIndex = viewModel.GetPlayerTeamIndex();
            }
        }

        private void LstvTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshPlayerList();
        }

        private void BtnFreePlayers_Click(object sender, RoutedEventArgs e)
        {
            viewModel.LoadAllTeamPlayers(-1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EnableChangeOrInputData(true);
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            //RefreshPlayerList();
            EnableChangeOrInputData(false);
        }

        private void ImgPlayer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LblMenuPlayer.Background = new SolidColorBrush(Color.FromRgb(255,0,0));
        }

        private void ImgPlayer_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CmbPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.SetPlayerPosition(CmbPosition.SelectedIndex);
        }

        private void CmbTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.SetPlayerTeam(CmbTeam.SelectedIndex);
        }

        private void BtnDeleteTeam_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RemoveTeam();
            CmbTeam.SelectedIndex = -1;
        }

        private void TextBox_TextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
