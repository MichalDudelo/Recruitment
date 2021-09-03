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
        public bool IsLadder { get; set; }

        public const int SnakeHopLength = -5;
        public const int LadderHopLength = 5;
        public bool Start { get; set; }
        public bool Finish { get; set; }
        public int Index { get; set; }
        public Tile(int index)
        {
            Finish = false;
            Start = false;
            IsSnake = false;
            IsLadder = false;
            Index = index;

        }
        
    }
}
