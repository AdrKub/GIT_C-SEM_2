using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20_MvvmFramework;

namespace FussballManager.Model
{
    public class Position : ObservableObject
    {
        public int ID { get; set; }
        public string PosName { get; set; }
    }
}
