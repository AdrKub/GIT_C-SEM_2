﻿using System.Collections.Generic;
using System.Linq;
using FussballManager.Model;
using System.IO;

namespace FussballManager.DataAccess
{
    public class TeamPlayerRepository
    {
        public string DefaultPicturePath = Path.GetFullPath(@"..\..\Pictures\");

        public List<Player> LoadPlayersWithTeam(int teamID) //Alle Spieler des selektieren Teams laden
        {
            List<tblPlayer> _players;
            List<Player> players = new List<Player>();
            using (FootballMngmtEntities context = new FootballMngmtEntities())
            {
                if(teamID == -1)
                    _players = (from pl in context.tblPlayers.Include("tblPosition").Include("tblTeam") where pl.Team_ID == null select pl).ToList<tblPlayer>();
                else
                    _players = (from pl in context.tblPlayers.Include("tblPosition").Include("tblTeam") where pl.Team_ID == teamID select pl).ToList<tblPlayer>();
            }
            foreach(tblPlayer player in _players)
            {
                //Umwandlung Nullable Types
                int number;
                int? tnumber = player.PlayerNmbr as int?;

                if (tnumber.HasValue)
                    number = tnumber.Value;
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

        public List<Position> LoadAllPositions() //Alle vorhandenen Spieler Positionen laden
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

        public List<Team> LoadAllTeams() //Alle vorhandenen Teams laden
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

        public void UpdatePlayer(Player player) //Spezifische Spieler Daten aktualisieren
        {
            using (FootballMngmtEntities context = new FootballMngmtEntities())
            {
                tblPlayer actpl = (from p in context.tblPlayers where p.ID == player.ID select p).FirstOrDefault();
                actpl.FirstName = player.FirstName;
                actpl.Name = player.Name;
                actpl.BirthDate = player.BirthDate;
                actpl.Goals = player.Goals;
                actpl.PicturePath = Path.GetFileName(player.PicturePath);
                actpl.Height = player.Height;
                actpl.PlayedGames = player.PlayedGames;
                actpl.Position_ID = player.Position.ID;
                if (player.Team.ID > 0)
                    actpl.Team_ID = player.Team.ID;
                else
                    actpl.Team_ID = null;

                context.SaveChanges();
            }
        }

        public void AddPlayer(Player player) //Neuer Spieler hinzufügen
        {
            using (FootballMngmtEntities context = new FootballMngmtEntities())
            {
                tblPlayer actpl = new tblPlayer { Name = player.Name, FirstName = player.FirstName, BirthDate = player.BirthDate, Goals = player.Goals, Height = player.Height, PicturePath = Path.GetFileName(player.PicturePath), PlayedGames = player.PlayedGames, PlayerNmbr = player.PlayerNumber, Position_ID = player.Position.ID };
                context.tblPlayers.Add(actpl);
                context.SaveChanges();
            }

        }

        public void DeletePlayer(Player player) //Bestehender Spieler löschen
        {
            using (FootballMngmtEntities context = new FootballMngmtEntities())
            {
                tblPlayer actpl = (from p in context.tblPlayers where p.ID == player.ID select p).FirstOrDefault();
                context.tblPlayers.Remove(actpl);
                context.SaveChanges();
            }
        }
    }
}
