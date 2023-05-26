using System;
using ChessBoardModel;

// Author: Noah Funderburgh
// Date: 11/12/2022
// Class: CST-250
// Teacher: Brandon Bass

namespace ChessBoardConsoleApp
{
    class Program
    {
        static Board myBoard = new Board(8);

        static void Main(string[] args)
        {
            bool validChessPiece = false;
            string chessPiece = "";
            printGrid(myBoard);

            while (validChessPiece == false)
            {
                Console.WriteLine("Please pick a chess piece. Knight, King, Rook, Bishop, Queen ");
                chessPiece = Console.ReadLine();
                if(chessPiece == "Knight" || chessPiece == "King" || chessPiece == "Rook" || chessPiece == "Bishop" || chessPiece == "Queen")
                {
                    validChessPiece = true;
                }
            }
            Cell myLocation = setCurrentCell();
            myBoard.MarkNextLegalMoves(myLocation, chessPiece);
            printGrid(myBoard);
            Console.ReadLine();
        }

        static public void printGrid(Board myBoard)
        {
            for(int i = 0; i < myBoard.Size; i++)
            {
                for(int j = 0; j < myBoard.Size; j++)
                {
                    if(j == 0)
                    {
                        line(myBoard.Size);
                        Console.WriteLine("+");
                    }
                    if(myBoard.theGrid[i, j].CurrentlyOccupied)
                    {
                        Console.Write("| X ");
                    }
                    else if(myBoard.theGrid[i, j].LegalNextMove)
                    {
                        Console.Write("| + ");
                    }
                    else
                    {
                        Console.Write("| - ");
                    }
                }
                Console.Write("|");
                Console.WriteLine();
            }
            line(myBoard.Size);
            Console.WriteLine("+\n=================================");
        }

        static public Cell setCurrentCell()
        {
            int currentRow = -1;
            int currentCol = -1;
            bool validRowCol = false;

            while (validRowCol == false)
            {
                Console.Out.Write("Enter your current row number\n");
                try
                {
                    currentRow = int.Parse(Console.ReadLine());
                    if (currentRow >= 0 && currentRow <= 7)
                    {
                        validRowCol = true;
                    }
                }
                catch
                {

                }
            }
            validRowCol = false;
            while (validRowCol == false)
            {
                Console.WriteLine("Enter your current column number");
                try
                {
                    currentCol = int.Parse(Console.ReadLine());
                    if (currentCol >= 0 && currentCol <= 7)
                    {
                        validRowCol = true;
                    }
                }
                catch
                {

                }
            }
            
            myBoard.theGrid[currentRow, currentCol].CurrentlyOccupied = true;
            Console.WriteLine("You legal moves at (" + currentRow + ", " + currentCol + ") are");
            return myBoard.theGrid[currentRow,currentCol];
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
