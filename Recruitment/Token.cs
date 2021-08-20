using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    public class Token
    {
        public Tile  Position { get; set; }
        public Player Owner { get; set; }
        public Token(Player owner)
        {
            Position = new Tile(0) { Start = true };
            Owner = owner;
        }
        public void MoveToken(Tile tile) => Position = tile; 
    }
}
