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
        //Alle vorhandenen Badges laden
        public List<Player> TestLoadPlayers()
        {
            List<tblPlayer> _players;
            List<Player> players = new List<Player>();
            using (FootballMngmtEntities context = new FootballMngmtEntities())
            {
                // _players = context.tblPlayers.Include("tblPositions").ToList<tblPlayer>();
                _players = (from pl in context.tblPlayers.Include("tblPosition").Include("tblTeam") select pl).ToList<tblPlayer>();
            }
            foreach(tblPlayer player in _players)
            {
                int number = 0;
                int? test = player.PlayerNmbr as int?;

                if (test.HasValue)
                    number = test.Value;
                else
                    number = 0;
                

                Position position = new Position { ID = player.tblPosition.ID, PosName = player.tblPosition.Position };
                players.Add(new Player { Name = player.Name, FirstName = player.FirstName, BirthDate = player.BirthDate, Goals = player.Goals, Height = player.Height, ID = player.ID, PicturePath = @"Images\"+player.PicturePath, PlayedGames = player.PlayedGames, Position = position, PlayerNumber = number });
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
    }
}
