using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    public class Tile
    {
        public bool IsSnake { get; set; }
        public bool Start { get; set; }
        public bool Finish { get; set; }
        public int Index { get; set; }
        public Tile(int index)
        {
            Finish = false;
            Start = false;
            IsSnake = false;
            Index = index;

        }
        
    }
}
