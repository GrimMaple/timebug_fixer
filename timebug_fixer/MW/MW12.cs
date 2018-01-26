using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timebug_fixer.MW
{
    class MW12 : Game
    {
        public MW12(GameProcess proc) : base(proc)
        {
            globalIgtAddress = 0x00987598;
            raceIgtAddress = 0x0091329C;
        }
    }
}
