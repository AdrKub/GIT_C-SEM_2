using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FussballManager.Model;
using System.Text.RegularExpressions;

namespace FussballManager.DataAccess
{
    public class TeamPlayerRepository
    {
        private string DefaultPicturePath = @"Images\";

        //Alle vorhandenen Badges laden
        public List<Player> LoadPlayersWithTeam(int teamID)
        {
            List<tblPlayer> _players;
            List<Player> players = new List<Player>();
            using (FootballMngmtEntities context = new FootballMngmtEntities())
            {
                // _players = context.tblPlayers.Include("tblPositions").ToList<tblPlayer>();
                if(teamID == -1)
                    _players = (from pl in context.tblPlayers.Include("tblPosition").Include("tblTeam") where pl.Team_ID == null select pl).ToList<tblPlayer>();
                else
                    _players = (from pl in context.tblPlayers.Include("tblPosition").Include("tblTeam") where pl.Team_ID == teamID select pl).ToList<tblPlayer>();
            }
            foreach(tblPlayer player in _players)
            {
                int number;
                int? test = player.PlayerNmbr as int?;

                if (test.HasValue)
                    number = test.Value;
                else
                    number = 0;

                Position position = new Position { ID = player.tblPosition.ID, PosName = player.tblPosition.Position };
                Team team;
                if (teamID > -1)
                    team = new Team { ID = player.tblTeam.ID, PicturePath = DefaultPicturePath + player.tblTeam.PicturePath, CountryName = player.tblTeam.Country };
                else
                    team = new Team();
                players.Add(new Player { Name = player.Name, FirstName = player.FirstName, BirthDate = player.BirthDate, Goals = player.Goals, Height = player.Height, ID = player.ID, PicturePath = DefaultPicturePath + player.PicturePath, PlayedGames = player.PlayedGames, Position = position, PlayerNumber = number, Team = team });
            }

            return players;
        }

        public List<Position> LoadAllPositions()
        {
            List<tblPosition> _positions;
            List<Position> positions = new List<Position>();
            using (FootballMngmtEntities context = new FootballMngmtEntities())
            {
                _positions = context.tblPositions.ToList<tblPosition>();
            }
            foreach (tblPosition position in _positions)
            {
                positions.Add(new Position {ID = position.ID, PosName = position.Position });
            }

            return positions;
        }

        public List<Team> LoadAllTeams()
        {
            List<tblTeam> _teams;
            List<Team> teams = new List<Team>();
            using (FootballMngmtEntities context = new FootballMngmtEntities())
            {
                _teams = context.tblTeams.ToList<tblTeam>();
            }
            foreach (tblTeam team in _teams)
            {
                teams.Add(new Team { ID = team.ID, CountryName = team.Country, PicturePath = DefaultPicturePath + team.PicturePath  });
            }

            return teams;
        }
    }
}
