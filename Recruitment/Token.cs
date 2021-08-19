using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    public class Token
    {
        public int  Position { get; set; }
        public Player Owner { get; set; }
        public Token(Player owner)
        {
            Position = 0;
            Owner = owner;
        }
        public void MoveToken(int diceRoleResult) => Position += diceRoleResult; 
    }
}
