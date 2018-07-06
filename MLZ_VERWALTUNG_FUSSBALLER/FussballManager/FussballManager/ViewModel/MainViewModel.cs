using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FussballManager.DataAccess;
using FussballManager.Model;
using System.Windows.Input;

namespace FussballManager.ViewModel
{
    public class MainViewModel
    {
        private TeamPlayerRepository _footballRepository = new TeamPlayerRepository();
        private int _actTeamIndex = -1;
        private bool _inputEnable = false;

        public ObservableCollection<PlayerViewModel> SelPlayers { get; set; }
        public ObservableCollection<Position> AllPositions { get; set; }
        public ObservableCollection<Team> AllTeams { get; set; }
        public PlayerViewModel SelPlayer { get; set; }


        public ICommand RequestChangePlayerData { get { return new RelayCommand(RequestChangePlayerDataExecute, RequestChangePlayerDataCanExecute); } }
        public ICommand ChangeDataAbortion { get { return new RelayCommand(ChangeDataAbortionExecute, ChangeDataAbortionCanExecute); } }
        public ICommand SaveDataChanges { get { return new RelayCommand(SaveDataChangesExecute, SaveDataChangesCanExecute); } }
        public ICommand DeletePlayer { get { return new RelayCommand(DeletePlayerExecute, DeletePlayerCanExecute); } }
        public ICommand CreateNewPlayer { get { return new RelayCommand(CreateNewPlayerExecute, CreateNewPlayerCanExecute); } }

        public MainViewModel()
        {
            SelPlayers = new ObservableCollection<PlayerViewModel>();
            AllPositions = new ObservableCollection<Position>();
            AllTeams = new ObservableCollection<Team>();
            SelPlayer = new PlayerViewModel(null);

            foreach (Position pos in _footballRepository.LoadAllPositions())
            {
                AllPositions.Add(pos);
            }

            foreach(Team team in _footballRepository.LoadAllTeams())
            {
                AllTeams.Add(team);
            }
        }

        public void LoadAllTeamPlayers(int listIndex)
        {
            int teamID;
            _actTeamIndex = listIndex;

            if (listIndex == -1)
                teamID = listIndex;
            else
                teamID = AllTeams[listIndex].ID;

            SelPlayers.Clear();
            SelPlayer.Player = null;
            foreach (Player pl in _footballRepository.LoadPlayersWithTeam(teamID))
            {
                SelPlayers.Add(new PlayerViewModel(pl));
            }
        }

        public void LoadPlayer(int listIndex)
        {
            SelPlayer.Player = SelPlayers[listIndex].Player;
        }

        public int GetPlayerPositionIndex()
        {
            int index = -1;
            for(int i = 0;i < AllPositions.Count; i++)
            {
                if (AllPositions[i].ID == SelPlayer.Position.ID)
                    index = i;
            }
            return index;
        }

        public int GetPlayerTeamIndex()
        {
            int index = -1;
            for (int i = 0; i < AllTeams.Count; i++)
            {
                if (AllTeams[i].ID == SelPlayer.Team.ID)
                    index = i;
            }
            return index;
        }

        public void SetPlayerPosition(int listIndex)
        {
            if(listIndex != -1)
            {
                if (SelPlayer.Player.Position.ID != AllPositions[listIndex].ID)
                    SelPlayer.Player.Position = AllPositions[listIndex];
            }
        }

        public void SetPlayerTeam(int listIndex)
        {
            if(listIndex != -1)
            {
                if (SelPlayer.Player.Team.ID != AllTeams[listIndex].ID)
                    SelPlayer.Player.Team = AllTeams[listIndex];
            }
        }

        public void RemoveTeam()
        {
            if (SelPlayer.Player != null)
                SelPlayer.Player.Team.ID = 0;
        }

        #region COMMANDS
        void RequestChangePlayerDataExecute()
        {
            _inputEnable = true;
        }

        bool RequestChangePlayerDataCanExecute()
        {
            if (SelPlayer.Player != null && _inputEnable == false)
                return true;
            else
                return false;
        }

        void ChangeDataAbortionExecute()
        {
            _inputEnable = false;
        }

        bool ChangeDataAbortionCanExecute()
        {
            if (SelPlayer.Player != null && _inputEnable)
                return true;
            else
                return false;
        }

        void SaveDataChangesExecute()
        {
            _footballRepository.UpdatePlayer(SelPlayer.Player);
            LoadAllTeamPlayers(_actTeamIndex);
        }

        bool SaveDataChangesCanExecute()
        {
            if (SelPlayer.Player != null && _inputEnable)
                return true;
            else
                return false;
        }

        void DeletePlayerExecute()
        {

        }

        bool DeletePlayerCanExecute()
        {
            if (SelPlayer.Player != null && _inputEnable == false)
                return true;
            else
                return false;
        }

        void CreateNewPlayerExecute()
        {

        }

        bool CreateNewPlayerCanExecute()
        {
            if (SelPlayer.Player == null)
                return true;
            else
                return false;
        }

        #endregion


    }
}
