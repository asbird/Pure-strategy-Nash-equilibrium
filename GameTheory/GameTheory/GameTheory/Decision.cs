using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Decision
    {
        public int row;
        public int column;
        public int value;

        public Decision(int r, int c, int v)
        {
            this.row = r;
            this.column = c;
            this.value = v;
        }
    }
}
