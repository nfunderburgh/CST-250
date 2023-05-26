using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Noah Funderburgh
// Date: 11/13/2022
// Class: CST-250
// Teacher: Brandon Bass

namespace Minesweeper
{
    class Program
    {
        /*
        * Main
        */
        public static void Main(string[] args)
        {
            Board board = new Board(8);
            board.setupLiveNeighbors(0.4);
            board.calculateLiveNeighbors();

            bool gameOver = false;
            bool alreadySelected = false;
            int inputRow = -1;
            int inputCol = -1;
            
            printBoard(board);
            printBoardDuringGame(board);

            while (gameOver == false)
            {
                while (alreadySelected == false) {

                    inputRow = -1;
                    inputCol = -1;
                    while (inputRow < 0 || inputRow > 7){
                        Console.WriteLine("Please select a number between 0 and " + (board.getSize() - 1) + " for the row: ");
                        try
                        {
                            inputRow = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("That isn't a valid number");
                        }
                    }

                    while (inputCol < 0 || inputCol > 7)
                    {
                        Console.WriteLine("Please select a number between 0 and " + (board.getSize() - 1) + " for the column: ");
                        try
                        {
                            inputCol = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("That isn't a valid number");
                        }
                    }

                    
                    if (board.Grid[inputRow, inputCol].Visited == true)
                    {
                        alreadySelected = false;
                        Console.WriteLine("That space is already selected");
                    }
                    else
                    {
                        alreadySelected = true;
                    }
                }
                alreadySelected = false;
                Console.WriteLine("You selected location (" + inputRow + "," + inputCol + ")");
                board.Grid[inputRow, inputCol].Visited = true;
                board.FloodFill(inputRow, inputCol);

                gameOver = printBoardDuringGame(board);
                if(gameOver == true)
                {
                    Console.WriteLine("Better luck next time. You lost!");
                    Console.WriteLine("Here is the board");
                    printBoard(board);
                }

                if (board.winner())
                {
                    Console.WriteLine("Congrats you beat the MineSweeper!");
                    gameOver = true;
                    Console.WriteLine("Here is the board");
                    printBoard(board);
                }
            }
        }

        /*
         * Prints the board
         * 
         * @param obj the board
         */
        public static void printBoard(Board obj)
        {
            int boardSize = obj.getSize();

            Console.Write("  ");
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write((i) + "   ");
            }

            Console.WriteLine();
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if ( col == 0)
                    {
                        line(boardSize);
                        Console.WriteLine("+");
                    }
                    if (obj.Grid[row, col].Live == true)
                    {
                        Console.Write("| * ");
                    }
                    else
                    {
                        Console.Write("| " + obj.Grid[row, col].Neighbors + " ");
                    }
                }
                Console.Write("|");
                Console.Write(" " + (row));
                Console.WriteLine();
            }
            line(boardSize);
            Console.WriteLine("+");
        }

        /*
        * Prints the board during the game
        * 
        * @param obj the board
        * @return bool returns true if a live site is picked
        */
        public static bool printBoardDuringGame(Board obj)
        {
            int boardSize = obj.getSize();
            int count = 0;

            Console.Write("  ");
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write((i) + "   ");
            }

            Console.WriteLine();
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (col == 0)
                    {
                        line(boardSize);
                        Console.WriteLine("+");
                    }
                    if (obj.Grid[row, col].Live == true && obj.Grid[row, col].Visited == true)
                    {
                        Console.Write("| * ");
                        count++;
                    }
                    else if(obj.Grid[row, col].Visited == true)
                    {
                        Console.Write("| " + obj.Grid[row, col].Neighbors + " ");
                    }
                    else
                    {
                        Console.Write("| ? ");
                    }
                }
                Console.Write("|");
                Console.Write(" " + (row));
                Console.WriteLine();
            }
            line(boardSize);
            Console.WriteLine("+");
            if(count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * Repeats a line of a plus and hypens
         */
        public static void line(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write("+---");
            }
        }
    }
}