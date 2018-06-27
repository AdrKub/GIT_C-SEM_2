using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballManager.Model
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int Height { get; set; }
        public DateTime BirthDate { get; set; }
        public int PlayedGames { get; set; }
        public int Goals { get; set; }
        public string PicturePath { get; set; }
        public Team Team { get; set; }
        public int PlayerNumber { get; set; }
        public Position Position { get; set; }
    }
}
