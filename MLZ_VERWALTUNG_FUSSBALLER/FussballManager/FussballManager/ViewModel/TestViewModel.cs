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
    public class TestViewModel
    {
        private TeamPlayerRepository footballRepository = new TeamPlayerRepository();
        private Player TemporaryPlayer;
        private int actTeamIndex = -1;

        public ObservableCollection<PlayerViewModel> SelPlayers { get; set; }
        public ObservableCollection<Position> AllPositions { get; set; }
        public ObservableCollection<Team> AllTeams { get; set; }
        public PlayerViewModel SelPlayer { get; set; }


        public ICommand RequestChangePlayerData { get { return new RelayCommand(RequestChangePlayerDataExecute, RequestChangePlayerDataCanExecute); } }
        public ICommand ChangeDataAbortion { get { return new RelayCommand(ChangeDataAbortionExecute, ChangeDataAbortionCanExecute); } }
        public ICommand SaveDataChanges { get { return new RelayCommand(SaveDataChangesExecute, SaveDataChangesCanExecute); } }

        public TestViewModel()
        {
            SelPlayers = new ObservableCollection<PlayerViewModel>();
            AllPositions = new ObservableCollection<Position>();
            AllTeams = new ObservableCollection<Team>();
            TemporaryPlayer = new Player();
            SelPlayer = new PlayerViewModel(null);

            foreach (Position pos in footballRepository.LoadAllPositions())
            {
                AllPositions.Add(pos);
            }

            foreach(Team team in footballRepository.LoadAllTeams())
            {
                AllTeams.Add(team);
            }
        }

        public void LoadAllTeamPlayers(int listIndex)
        {
            int teamID;
            actTeamIndex = listIndex;

            if (listIndex == -1)
                teamID = listIndex;
            else
                teamID = AllTeams[listIndex].ID;

            SelPlayers.Clear();
            SelPlayer.Player = null;
            foreach (Player pl in footballRepository.LoadPlayersWithTeam(teamID))
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

        }

        bool RequestChangePlayerDataCanExecute()
        {
            if (SelPlayer.Player != null)
                return true;
            else
                return false;
        }

        void ChangeDataAbortionExecute()
        {
            
        }

        bool ChangeDataAbortionCanExecute()
        {
            if (SelPlayer.Player != null)
                return true;
            else
                return false;
        }

        void SaveDataChangesExecute()
        {
            footballRepository.UpdatePlayer(SelPlayer.Player);
            LoadAllTeamPlayers(actTeamIndex);
        }

        bool SaveDataChangesCanExecute()
        {
            return true;
        }

        #endregion


    }
}
