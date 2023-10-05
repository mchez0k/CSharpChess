﻿using Chess;

namespace DemoChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Chess.Chess chess = new Chess.Chess();
            List<string> list;
            while (true)
            {
                list = chess.GetAllMoves();
                Console.WriteLine(chess.fen);
                Console.WriteLine(ChessToAscii(chess));
                Console.WriteLine(chess.IsCheck() ? "CHECK!" : " - ");
                foreach (string moves in list)
                    Console.Write(moves + "\t");
                Console.WriteLine();
                Console.WriteLine("> ");
                string move = Console.ReadLine();
                if (move == "q") break;
                if (move == "") move = list[random.Next(list.Count)];
                chess = chess.Move(move);
            }
        }

        static string ChessToAscii (Chess.Chess chess)
        {
            string text = "  +----------------+\n"; 
            for (int y = 7; y >= 0; y--)
            {
                text += y + 1;
                text += " | ";
                for (int x = 0; x < 8; x++)
                    text += chess.GetFigureAt(x, y) + " ";
                text += "|\n";
            }
            text += "  +----------------+\n";
            text += "    a b c d e f g h\n";
            return text;
        }
    }
}