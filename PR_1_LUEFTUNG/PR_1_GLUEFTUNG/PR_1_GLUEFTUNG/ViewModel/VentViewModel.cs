﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR_1_GLUEFTUNG.Control;

namespace PR_1_GLUEFTUNG.ViewModel
{
    public class VentViewModel
    {
        public EngControl Fan_1 { get; set; }
        public LvlControl Ctrl_1 { get; set; }

        public VentViewModel()
        {

        }
    }
}
