using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Noah Funderburgh
// Date: 11/12/2022
// Class: CST-250
// Teacher: Brandon Bass

namespace ChessBoardModel
{
    public class Board
    {
        // the board is always square normally 8x8
        public int Size { get; set; }
        //2d array of cell objects
        public Cell[,] theGrid;

        public int nextRow = 0;
        public int nextColumn = 0;

        public Board(int s)
        {
            Size = s;
            // we must initialize the array to avoid Null Exception Errors
            theGrid = new Cell[Size, Size];
            for( int i = 0; i < Size; i++)
            {
                for( int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell CurrentCell, string chesspiece)
        {
            for( int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    theGrid[r, c].LegalNextMove = false;
                }
            }

            switch (chesspiece)
            {
                case "Knight":
                    theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber].CurrentlyOccupied = true;

                    if (ValidPosition(CurrentCell, -2, -1))
                    {
                        theGrid[CurrentCell.RowNumber - 2, CurrentCell.ColumnNumber - 1].LegalNextMove = true;
                    }
                    if(ValidPosition(CurrentCell, -2, 1))
                    {
                        theGrid[CurrentCell.RowNumber - 2, CurrentCell.ColumnNumber + 1].LegalNextMove = true;
                    }
                    if(ValidPosition(CurrentCell, -1, 2))
                    {
                        theGrid[CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber + 2].LegalNextMove = true;
                    }
                    if(ValidPosition(CurrentCell, 1, 2))
                    {
                        theGrid[CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber + 2].LegalNextMove = true;
                    }
                    if (ValidPosition(CurrentCell, 2, 1))
                    {
                        theGrid[CurrentCell.RowNumber + 2, CurrentCell.ColumnNumber + 1].LegalNextMove = true;
                    }
                    if (ValidPosition(CurrentCell, 2, -1))
                    {
                        theGrid[CurrentCell.RowNumber + 2, CurrentCell.ColumnNumber - 1].LegalNextMove = true;
                    }
                    if (ValidPosition(CurrentCell, 1, -2))
                    {
                        theGrid[CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber - 2].LegalNextMove = true;
                    }
                    if (ValidPosition(CurrentCell, -1, -2))
                    {
                        theGrid[CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber - 2].LegalNextMove = true;
                    }
                    break;
                case "King":
                    theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber].CurrentlyOccupied = true;

                    // Moves king up and to the left one space
                    if (ValidPosition(CurrentCell, -1, -1))
                    {
                        theGrid[CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber - 1].LegalNextMove = true;
                    }
                    // Moves king up one space
                    if (ValidPosition(CurrentCell, -1, 0))
                    {
                        theGrid[CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber].LegalNextMove = true;
                    }
                    // Moves king left one space
                    if (ValidPosition(CurrentCell, 0, -1))
                    {
                        theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber -1].LegalNextMove = true;
                    }
                    // Moves king right one space
                    if (ValidPosition(CurrentCell, 0, 1))
                    {
                        theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber + 1].LegalNextMove = true;
                    }
                    // Moves king down one space
                    if (ValidPosition(CurrentCell, 1, 0))
                    {
                        theGrid[CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber].LegalNextMove = true;
                    }
                    // Moves king down and to the right one space
                    if (ValidPosition(CurrentCell, 1, 1))
                    {
                        theGrid[CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber + 1].LegalNextMove = true;
                    }
                    // Moves king up and to the right one space
                    if (ValidPosition(CurrentCell, -1, 1))
                    {
                        theGrid[CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber + 1].LegalNextMove = true;
                    }
                    // Moves king down and to the left one space
                    if (ValidPosition(CurrentCell, 1, -1))
                    {
                        theGrid[CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber - 1].LegalNextMove = true;
                    }
                    break;
                case "Rook":
                    theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber].CurrentlyOccupied = true;

                    nextRow = 0;
                    nextColumn = 0;

                    // checking straight to the left
                    while (ValidPosition(CurrentCell, nextRow, nextColumn - 1))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow, CurrentCell.ColumnNumber + nextColumn - 1].LegalNextMove = true;
                        nextColumn--;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking straight to the right
                    while (ValidPosition(CurrentCell, nextRow, nextColumn + 1))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow, CurrentCell.ColumnNumber + nextColumn + 1].LegalNextMove = true;
                        nextColumn++;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking straight down
                    while (ValidPosition(CurrentCell, nextRow + 1, nextColumn))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow + 1, CurrentCell.ColumnNumber + nextColumn].LegalNextMove = true;
                        nextRow++;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking straight up
                    while (ValidPosition(CurrentCell, nextRow - 1, nextColumn))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow - 1, CurrentCell.ColumnNumber + nextColumn].LegalNextMove = true;
                        nextRow--;
                    }


                    break;
                case "Bishop":
                    theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber].CurrentlyOccupied = true;
                    nextRow = 0;
                    nextColumn = 0;

                    // checking up left diagonal
                    while (ValidPosition(CurrentCell, nextRow - 1, nextColumn - 1))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow - 1, CurrentCell.ColumnNumber + nextColumn - 1].LegalNextMove = true;
                        nextRow--;
                        nextColumn--;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking up right diagonal
                    while (ValidPosition(CurrentCell, nextRow - 1, nextColumn + 1))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow - 1, CurrentCell.ColumnNumber + nextColumn + 1].LegalNextMove = true;
                        nextRow--;
                        nextColumn++;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking down right diagonal
                    while (ValidPosition(CurrentCell, nextRow + 1, nextColumn + 1))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow + 1, CurrentCell.ColumnNumber + nextColumn + 1].LegalNextMove = true;
                        nextRow++;
                        nextColumn++;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking down left diagonal
                    while (ValidPosition(CurrentCell, nextRow + 1, nextColumn - 1))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow + 1, CurrentCell.ColumnNumber + nextColumn - 1].LegalNextMove = true;
                        nextRow++;
                        nextColumn--;
                    }
                    break;
                case "Queen":
                    //Queen is basicly a bishop and rook combined
                    theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber].CurrentlyOccupied = true;

                    nextRow = 0;
                    nextColumn = 0;
                    // checking up left diagonal
                    while (ValidPosition(CurrentCell, nextRow - 1, nextColumn - 1))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow - 1, CurrentCell.ColumnNumber + nextColumn - 1].LegalNextMove = true;
                        nextRow--;
                        nextColumn--;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking up right diagonal
                    while (ValidPosition(CurrentCell, nextRow - 1, nextColumn + 1))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow - 1, CurrentCell.ColumnNumber + nextColumn + 1].LegalNextMove = true;
                        nextRow--;
                        nextColumn++;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking down right diagonal
                    while (ValidPosition(CurrentCell, nextRow + 1, nextColumn + 1))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow + 1, CurrentCell.ColumnNumber + nextColumn + 1].LegalNextMove = true;
                        nextRow++;
                        nextColumn++;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking down left diagonal
                    while (ValidPosition(CurrentCell, nextRow + 1, nextColumn - 1))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow + 1, CurrentCell.ColumnNumber + nextColumn - 1].LegalNextMove = true;
                        nextRow++;
                        nextColumn--;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking straight to the left
                    while (ValidPosition(CurrentCell, nextRow, nextColumn - 1))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow, CurrentCell.ColumnNumber + nextColumn - 1].LegalNextMove = true;
                        nextColumn--;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking straight to the right
                    while (ValidPosition(CurrentCell, nextRow, nextColumn + 1))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow, CurrentCell.ColumnNumber + nextColumn + 1].LegalNextMove = true;
                        nextColumn++;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking straight down
                    while (ValidPosition(CurrentCell, nextRow + 1, nextColumn))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow + 1, CurrentCell.ColumnNumber + nextColumn].LegalNextMove = true;
                        nextRow++;
                    }

                    nextRow = 0;
                    nextColumn = 0;

                    // checking straight up
                    while (ValidPosition(CurrentCell, nextRow - 1, nextColumn))
                    {
                        theGrid[CurrentCell.RowNumber + nextRow - 1, CurrentCell.ColumnNumber + nextColumn].LegalNextMove = true;
                        nextRow--;
                    }
                    break;
                default:
                    break;
                
            }
        }

        public bool ValidPosition(Cell currentCell, int extraRows, int extraCols)
        {
            if ((currentCell.RowNumber + extraRows < 0 || currentCell.RowNumber + extraRows > Size - 1) || (currentCell.ColumnNumber + extraCols < 0 || currentCell.ColumnNumber + extraCols > Size - 1))
            {
                return false;
            }
            return true;
        }

        public void resetCurrentlyOccupied()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i,j].CurrentlyOccupied = false;
                }
            }
        }
    }
}
