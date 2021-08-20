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
        public string ReportGamePlay()
        {
            var currentPosition = Token.Position.Index - diceRollResult;
            return @$"Player name: {Name}, start position: {(currentPosition == 0 ? "Start" : currentPosition)}, current position: {Token.Position.Index}, last roll result {diceRollResult}";
        }
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
