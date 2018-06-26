using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    //[AttributeUsage(validOn: AttributeTargets.All)]
    public class CustDebugAttrAttribute:Attribute
    {
        private string _description;

        public string Description
        {
            get { return _description; }
        }

        public CustDebugAttrAttribute(string description)
        {
            _description = description;
        }
    }
}
