using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisWorldIsAGame.DataBaseF
{
    public partial class UserAction
    {
        public string Plus {
            get {
                return $"+";
            }
        }

        public string Minus
        {
            get
            {
                return $"X";
            }
        }

        public string ExpAction
        {
            get
            {
                return $"+{Action.ActionExp}exp";
            }
        }
    }
}
