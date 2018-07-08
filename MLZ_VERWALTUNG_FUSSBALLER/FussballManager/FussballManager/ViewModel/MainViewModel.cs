using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FussballManager.DataAccess;
using FussballManager.Model;
using System.Windows.Input;
using FussballManager;
using System.Globalization;

namespace FussballManager.ViewModel
{
    public class MainViewModel
    {
        private TeamPlayerRepository _footballRepository = new TeamPlayerRepository();
        private Player _newPlayer;
        private int _actTeamIndex = -1;
        private bool _inputEnable = false;
        private bool _inputNewPlayer = false;
        private bool _resultValBirthDate = false;
        private bool _resultValPlayerNmbr = false;

        public ObservableCollection<PlayerViewModel> SelPlayers { get; set; }
        public ObservableCollection<Position> AllPositions { get; set; }
        public ObservableCollection<Team> AllTeams { get; set; }
        public PlayerViewModel SelPlayer { get; set; }
        public InputValidation Validation;
        public bool InputEnable
        {
            get { return _inputEnable; }
        }


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
            Validation = new InputValidation();

            foreach (Position pos in _footballRepository.LoadAllPositions())
            {
                AllPositions.Add(pos);
            }

            foreach(Team team in _footballRepository.LoadAllTeams())
            {
                AllTeams.Add(team);
            }
        }

        #region FUNCTIONS / DB ACCESS

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
            _resultValBirthDate = true;
            _resultValPlayerNmbr = true;
        }

        public void LoadNewPlayer()
        {
            _newPlayer = new Player { Name = "New", FirstName = "Player", Height = 180, PlayedGames = 0, Goals = 0, PlayerNumber = 0, PicturePath = _footballRepository.DefaultPicturePath + "anonymus.jpg", BirthDate = DateTime.Now, Position = AllPositions[1] };
            SelPlayer.Player = _newPlayer;
            _resultValBirthDate = true;
            _resultValPlayerNmbr = true;
            _inputEnable = true;
            _inputNewPlayer = true;
            Validation.InitValidation();
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

        private bool SaveEnable()
        {
            if (_resultValBirthDate && _resultValPlayerNmbr)
                return true;
            else
                return false;
        }

        #endregion

        #region INPUT VALIDATION

        public bool ValidPlayerNumber(string input, out string errorText)
        {
            if (Int32.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat, out int value))
            {
                if (SelPlayer.Player.Team.ID > 0)
                {
                    foreach (PlayerViewModel plvm in SelPlayers)
                    {
                        if (value == plvm.Player.PlayerNumber && SelPlayer.Player.ID != plvm.Player.ID)
                        {
                            errorText = "Spielernummer ist bereits vergeben";
                            _resultValPlayerNmbr = false;
                            return false;
                        }
                    }
                }
                errorText = "";
                _resultValPlayerNmbr = true;
                return true;
            }
            else
            {
                errorText = "Eingabe ist ungültig";
                _resultValPlayerNmbr = false;
                return false;
            }
        }

        public bool ValidBirthDate(DateTime input, out string errorText)
        {
            if(input > DateTime.Now || input.Year < (DateTime.Now.Year - 45) || input.Year > (DateTime.Now.Year -18))
            {
                errorText = "Datum ist ausserhalb Gültigkeitsbereich";
                _resultValBirthDate = false;
                return false;
            }
            else
            {
                errorText = "";
                _resultValBirthDate = true;
                return true;
            }
        }

        #endregion

        #region COMMANDS

        void RequestChangePlayerDataExecute()
        {
            _inputEnable = true;
            Validation.InitValidation();
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
            _inputNewPlayer = false;
            LoadAllTeamPlayers(_actTeamIndex);
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
            if (_inputNewPlayer)
                _footballRepository.AddPlayer(SelPlayer.Player);
            else
                _footballRepository.UpdatePlayer(SelPlayer.Player);
            LoadAllTeamPlayers(_actTeamIndex);
            _inputEnable = false;
            _inputNewPlayer = false;
        }

        bool SaveDataChangesCanExecute()
        {
            if (SelPlayer.Player != null && _inputEnable && SaveEnable() && Validation.ResultOfValidation())
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
            _inputNewPlayer = true;
            Validation.InitValidation();
        }

        bool CreateNewPlayerCanExecute()
        {
            if (_inputEnable == false)
                return true;
            else
                return false;
        }

        #endregion


    }
}
