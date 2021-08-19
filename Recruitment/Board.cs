using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    public class Board
    {
        //assume that we have square board
        public const int Dimension = 5;
        public const int Finish = Dimension * Dimension;
        public const int NumberOfLadders = 5;
        public const int NumberOfSnakes = 5;
        public Tile.Tile[]Tiles { get; set; }
        public Player Winner { get; set; }
        public bool GameFinished { get; set; }
        public Board()
        {
            Tiles = new Tile.Tile[Dimension*Dimension];
            GameFinished = false;
            //generate Board
            generateBoard();
            
        }
        private void generateBoard()
        {
            for (int i = 0; i <= Dimension; i++)
            {
                Tiles[i] =  new Tile.Tile(i, i);
                
            }
        }
        public void MakeMove(Token playerToken, int diceRollResult)
        {
            playerToken.MoveToken(diceRollResult);
            if (playerToken.Position >= Finish)
            {
                GameFinished = true;
                Winner = playerToken.Owner;
            }
                
        }   
      
    }
}
