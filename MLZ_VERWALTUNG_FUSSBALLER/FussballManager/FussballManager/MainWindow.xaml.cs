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
using Microsoft.Win32;
using System.IO;

namespace FussballManager
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;
        private SolidColorBrush gray = new SolidColorBrush(Color.FromArgb(0xFF, 0xCD, 0xCD, 0xCD));
        private SolidColorBrush green = new SolidColorBrush(Color.FromArgb(0xFF, 0xB5, 0xEA, 0x9D));
        private SolidColorBrush red = new SolidColorBrush(Color.FromRgb(255, 0, 0));

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainViewModel();
            DataContext = viewModel;
            EnableChangeOrInputData(false);
        }

        private void Test()
        {
            string _path;
            string oldPath = ;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Bild hinzufügen";
            openFileDialog.Filter = "jpg Dateien (*.jpg)|*.jpg|png Dateien (*.pgn)|*.png|Alle Dateien (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                _path = openFileDialog.FileName;
            }
            else
                _path = null;

        }

        private void EnableChangeOrInputData(bool mode)
        {
            GrdPlayerData.IsEnabled = mode;

        }

        private void ChangeActiveMenu(Label activeMenu)
        {
            LblMenuPlayer.Background = gray;
            LblMenuPlayers.Background = gray;
            LblMenuTeams.Background = gray;
            activeMenu.Background = green;
        }

        private bool ShowYesOrNoMsgBox(string cont, string titel)
        {
            MessageBoxResult result = MessageBox.Show(cont,
                                          titel,
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                return true;
            else
                return false;
        }

        private void ClearPlayerData()
        {
            EnableChangeOrInputData(false);
            ChangeActiveMenu(LblMenuPlayers);
            LblError.Content = "";
            CmbPosition.SelectedIndex = -1;
            CmbTeam.SelectedIndex = -1;
            LstvTeams.IsEnabled = true;
            LstvTeamPlayers.IsEnabled = true;
        }

        private void InputDataValidation()
        {
            string error;
            if (viewModel.InputEnable && viewModel.IsPlayerSelected())
            {
                if (viewModel.Validation.ValidateGoals(TxtBGoals.Text, out error) == false)
                {
                    InputNotValid();
                    LblError.Content = error.ToUpper();
                    return;
                }
                else if(viewModel.Validation.ValidatePalyedGames(TxtBPlayedGames.Text, out error) == false)
                {
                    InputNotValid();
                    LblError.Content = error.ToUpper();
                    return;
                }
                else if(viewModel.Validation.ValidateHeight(TxtBHeight.Text, out error) == false)
                {
                    InputNotValid();
                    LblError.Content = error.ToUpper();
                    return;
                }
                else if(viewModel.ValidBirthDate((DateTime)DtpBirthDate.SelectedDate, out error) == false)
                {
                    InputNotValid();
                    LblError.Content = error.ToUpper();
                    return;
                }
                else if(viewModel.Validation.ValidateFirstName(TxtBFirstName.Text, out error) == false)
                {
                    InputNotValid();
                    LblError.Content = error.ToUpper();
                    return;
                }
                else if(viewModel.Validation.ValidateName(TxtBName.Text, out error) == false)
                {
                    InputNotValid();
                    LblError.Content = error.ToUpper();
                    return;
                }
                else if(viewModel.ValidPlayerNumber(TxtBPlayerNmbr.Text, out error) == false)
                {
                    InputNotValid();
                    LblError.Content = error.ToUpper();
                    return;
                }
                else
                {
                    ChangeActiveMenu(LblMenuPlayer);
                    LblError.Content = "";
                }
            }
        }

        private void InputNotValid()
        {
            LblMenuPlayer.Background = red;
        }

        private void RefreshPlayerList()
        {
            if (LstvTeams.SelectedIndex > -1)
            {
                ChangeActiveMenu(LblMenuPlayers);
                viewModel.LoadAllTeamPlayers(LstvTeams.SelectedIndex);
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
            ClearPlayerData();
        }

        private void BtnFreePlayers_Click(object sender, RoutedEventArgs e)
        {
            viewModel.LoadAllTeamPlayers(-1);
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

        private void DtpBirthDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            InputDataValidation();
        }

        private void TxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputDataValidation();
        }

        private void BtnChangeData_Click(object sender, RoutedEventArgs e)
        {
            EnableChangeOrInputData(true);
            LstvTeams.IsEnabled = false;
            LstvTeamPlayers.IsEnabled = false;
        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            ClearPlayerData();
        }

        private void BtnAbortion_Click(object sender, RoutedEventArgs e)
        {
            ClearPlayerData();
        }

        private void BtnNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            viewModel.LoadNewPlayer();
            EnableChangeOrInputData(true);
            CmbPosition.SelectedIndex = viewModel.GetPlayerPositionIndex();
            ChangeActiveMenu(LblMenuPlayer);
            LstvTeams.IsEnabled = false;
            LstvTeamPlayers.IsEnabled = false;
            if (viewModel.InputEnable)
            {
                if (viewModel.ValidBirthDate((DateTime)DtpBirthDate.SelectedDate, out string error))
                {
                    ChangeActiveMenu(LblMenuPlayer);
                    LblError.Content = "";
                }
                else
                {
                    InputNotValid();
                    LblError.Content = error.ToUpper();
                }
            }
        }

        private void BtnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (ShowYesOrNoMsgBox("Datensatz wirklich löschen ?", "Löschen"))
            {
                viewModel.DeletePlayer();
                ClearPlayerData();
            } 
        }

        private void ImgPlayer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Test();
        }
    }
}
