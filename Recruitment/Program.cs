﻿using System;
using System.Collections.Generic;

namespace Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            var dice = new Dice();
            var board = new Board(length:25);
            var players = new List<Player>()
            { new Player(name:"Player1")
            , new Player(name:"Player2")};


            do
            {
                players.ForEach(player =>
                {
                    player.RollADiceAndMove(dice, board);
                  
                    
                });
                Console.WriteLine();
            }
            while (!board.GameFinished);


            Console.WriteLine($"Winner {board.Winner.Name}");
            Console.ReadLine();
        }
    }
}
