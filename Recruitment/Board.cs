﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    public class Board
    {
        public int Length = 25;
        public int Finish;
        public const int NumberOfLadders = 5;
        public const int NumberOfSnakes = 5;
        public Tile[] Tiles { get; set; }
        public Player Winner { get; set; }
        public bool GameFinished { get; set; }
        public Board(int length)
        {
            Length = length;
            Finish = Length - 1;
            Tiles = new Tile[Length];
            GameFinished = false;
            //generate Board
            generateBoard();

        }
        private void generateBoard()
        {
            Tiles[0] = new Tile(0) { Start = true };
            Tiles[Finish] = new Tile(Finish) { Finish = true };
            for (int i = 1; i < Finish; i++)
            {
                Tiles[i] = new Tile(i);

            }
        }
        public void MakeMove(Token playerToken, int diceRollResult)
        {
            var nextTileIndex = playerToken.Position.Index + diceRollResult;

            var nextTile = Tiles.ElementAtOrDefault(nextTileIndex) ?? Tiles[Finish];
        
            playerToken.MoveToken(nextTile);
            if (nextTile.Finish)
            {
                GameFinished = true;
                Winner = playerToken.Owner;
            }

        }

    }
}
