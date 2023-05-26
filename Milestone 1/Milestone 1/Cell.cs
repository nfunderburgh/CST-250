using System;
using System.Collections.Generic;
using System.Text;

// Author: Noah Funderburgh
// Date: 11/13/2022
// Class: CST-250
// Teacher: Brandon Bass

namespace Minesweeper
{
    class Cell
    {
        /*
         * Default Constructor
         */
        public Cell()
        {
            row = -1;
            column = -1;
            visited = false;
            live = false;
            neighbors = 0;
        }

        /*
         * Parameterized Constructor
         */
        public Cell(int row, int column, bool isVisited, bool Live, int neighbors)
        {
            this.row = row;
            this.column = column;
            this.visited = isVisited;
            this.Live = Live;
            this.neighbors = neighbors;
        }

        private int row { get; set; }
        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        private int column { get; set; }
        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        private bool visited { get; set; }
        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }

        private bool live { get; set; }
        public bool Live
        {
            get { return live; }
            set { live = value; }
        }

        private int neighbors;
        public int Neighbors
        {
            get { return neighbors; }
            set { neighbors = value; }
        }
    }
}