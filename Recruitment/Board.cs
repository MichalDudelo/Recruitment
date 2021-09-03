using System;
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
        public const int Start = 0;
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
            var randomSnakeGenerator = new Random();
            Tiles[Start] = new Tile(index: Start) { Start = true };
            Tiles[Finish] = new Tile(index: Finish) { Finish = true };
            for (int i = 1; i < Finish; i++)
            {
                Tiles[i] = new Tile(index: i);
                //generate Snake tile with probability = 25%
                Tiles[i].IsSnake = randomSnakeGenerator.NextDouble() >= 0.75;
                //generate Ladder tile with probability 25%,
                //make sure by logical operation that tile cannot be Ladder and Snake simultaneously
                Tiles[i].IsLadder = !Tiles[i].IsSnake && randomSnakeGenerator.NextDouble() >= 0.75;
            }
        }
        public void MakeMove(Token playerToken, int diceRollResult)
        {
            //get tile index based on current position and dice roll result
            var nextTileIndex = playerToken.Position.Index + diceRollResult;
            //check if player finishes the game
            var nextTile = getNextTileFromBoard(nextTileIndex);
            //playerToken move
            Console.WriteLine(ReportGamePlay(playerToken.Owner, playerToken.Position.Index, nextTileIndex, diceRollResult));
            playerToken.MoveToken(nextTile);
             //see if nextTile is a Snake
            if (nextTile.IsSnake)
            {
                nextTile = getNextTileFromBoard(nextTile.Index + Tile.SnakeHopLength);
                Console.WriteLine(ReportGamePlay(playerToken.Owner, playerToken.Position.Index, nextTileIndex, diceRollResult));
                playerToken.MoveToken(nextTile);
            }
            if (nextTile.IsLadder)
            {
                nextTile = getNextTileFromBoard(nextTile.Index + Tile.LadderHopLength);
                Console.WriteLine(ReportGamePlay(playerToken.Owner, playerToken.Position.Index, nextTile.Index, diceRollResult));
                playerToken.MoveToken(nextTile);
            }

            if (nextTile.Finish)
            {
                GameFinished = true;
                Winner = playerToken.Owner;
            }

        }
        public string ReportGamePlay(Player player,int startPosition, int currentPosition, int diceRollResult)
        {
               return @$"Player name: {player.Name}, start position: {(startPosition == 0 ? "Start" : startPosition)}, current position: {currentPosition}, current position isSnake {player.Token.Position.IsSnake}, current position isLadder {player.Token.Position.IsLadder}, last roll result {diceRollResult}";
        }
        //Board checks if token is inside bounds (Start/End)
        private Tile getNextTileFromBoard(int nextTileIndex)
        {
            if (nextTileIndex <= 0)
                return Tiles[Start];
            else if (nextTileIndex >= Finish)
                return Tiles[Finish];
            else
                return Tiles[nextTileIndex];
        }

    }
}
