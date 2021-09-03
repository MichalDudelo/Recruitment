using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    public class Player
    {
        public string Name { get; init; }
        public Token Token { get; init; }
        private int diceRollResult { get; set; }
       
        public Player(string name)
        {
            Token = new Token(owner: this);
            Name = name;
        }

        public void RollADiceAndMove(Dice dice, Board board)
        {
            diceRollResult = dice.Roll();
            board.MakeMove(Token, diceRollResult);

        }

    }
}
