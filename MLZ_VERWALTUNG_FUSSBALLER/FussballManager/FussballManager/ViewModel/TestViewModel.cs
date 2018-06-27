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
        private Player EmptyPlayer;

        public ObservableCollection<PlayerViewModel> SelPlayers { get; set; }
        public ObservableCollection<Position> AllPositions { get; set; }
        public ObservableCollection<Team> AllTeams { get; set; }
        public PlayerViewModel SelPlayer { get; set; }


        public TestViewModel()
        {
            SelPlayers = new ObservableCollection<PlayerViewModel>();
            AllPositions = new ObservableCollection<Position>();
            AllTeams = new ObservableCollection<Team>();
            EmptyPlayer = new Player();
            SelPlayer = new PlayerViewModel(EmptyPlayer);

            //foreach(Player pl in footballRepository.TestLoadPlayers())
            //{
            //    SelPlayers.Add(new PlayerViewModel(pl));
            //}

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

            if (listIndex == -1)
                teamID = listIndex;
            else
                teamID = AllTeams[listIndex].ID;

            SelPlayers.Clear();
            SelPlayer.Player = EmptyPlayer;
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


    }
}
