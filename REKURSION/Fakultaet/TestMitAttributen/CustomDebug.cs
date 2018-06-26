using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMitAttributen
{
    [AttributeUsage(validOn: AttributeTargets.All)]
    public class CustomDebugAttribute:Attribute
    {
        private string _beschreibung;

        public string Beschreibung
        {
            get { return _beschreibung; }
        }

        public CustomDebugAttribute(string description)
        {
            _beschreibung = description;
        }
    }
}
