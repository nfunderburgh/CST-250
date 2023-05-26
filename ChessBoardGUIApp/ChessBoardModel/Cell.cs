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
    public class Cell
    {

        //row and col are the cell's location on the grid
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }

        // T/F is the chess piece on this cell?
        public bool CurrentlyOccupied { get; set; }

        // is this square a legal move for the chess piece on the board?
        public bool LegalNextMove { get; set; }

        //Constructor
        public Cell(int r, int c)
        {
            RowNumber = r;
            ColumnNumber = c;
        }

    }
}
