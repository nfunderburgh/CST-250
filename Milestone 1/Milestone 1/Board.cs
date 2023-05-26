using System;
using System.Collections.Generic;
using System.Text;

// Author: Noah Funderburgh
// Date: 11/13/2022
// Class: CST-250
// Teacher: Brandon Bass

namespace Minesweeper
{
    class Board
    {
        //Properties of the Board
        public Cell[,] Grid;
        public double difficulty;
        private int size;

        /*
         * returns the size property
         * 
         * @return int the size of the board
         * */
        public int getSize()
        {
            return size;
        }

        /*
         * Parameterized Constructor
         */
        public Board(int size)
        {
            Grid = new Cell[size, size];
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Grid[row, col] = new Cell();
                }
            }
            this.size = size;
        }

        /*
         * sets up the the live nighbors randomly around the board
         * The amount setup are dependent on the difficulty
         * 
         * @param double the difficulty of the game from 0 to 1
         *                          0 being the easiest and 1 being the hardest
         * */
        public void setupLiveNeighbors(double difficulty)
        {
            Random rand = new Random();

            int liveGrids = Convert.ToInt32(difficulty * Grid.Length);
            int liveCounter = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int random = rand.Next(0, 2);

                    if (liveCounter < liveGrids)
                    {
                        if (random == 0)
                        {
                            Grid[row, col].Live = false;
                        }
                        else
                        {
                            Grid[row, col].Live = true;
                            liveCounter++;
                        }
                    }
                }
            }
        }

        /*
         * counts the live neighbors around a specific tile
         * */
        public void calculateLiveNeighbors()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    // Top
                    if (inArray(row - 1, col))
                    {
                        if (Grid[row - 1, col].Live)
                        {
                            Grid[row, col].Neighbors++;
                        }
                    }

                    //Top Right
                    if (inArray(row - 1, col - 1))
                    {
                        if (Grid[row - 1, col - 1].Live)
                        {
                            Grid[row, col].Neighbors++;
                        }
                    }

                    // Top Left
                    if (inArray(row - 1, col + 1))
                    {
                        if (Grid[row - 1, col + 1].Live)
                        {
                            Grid[row, col].Neighbors++;
                        }
                    }

                    // Right
                    if (inArray(row, col - 1))
                    {
                        if (Grid[row, col - 1].Live)
                        {
                            Grid[row, col].Neighbors++;
                        }
                    }

                    // Left
                    if (inArray(row, col + 1))
                    {
                        if (Grid[row, col + 1].Live)
                        {
                            Grid[row, col].Neighbors++;
                        }
                    }

                    // Bottom
                    if (inArray(row + 1, col))
                    {
                        if (Grid[row + 1, col].Live)
                        {
                            Grid[row, col].Neighbors++;
                        }
                    }

                    // Bottom left
                    if (inArray(row + 1, col - 1))
                    {
                        if (Grid[row + 1, col - 1].Live)
                        {
                            Grid[row, col].Neighbors++;
                        }
                    }

                    // Bottom right
                    if (inArray(row + 1, col + 1))
                    {
                        if (Grid[row + 1, col + 1].Live)
                        {
                            Grid[row, col].Neighbors++;
                        }
                    }
                }
            }

        }

        /*
         * Checks to see if the specific row, col is in the array return true if it is and false otherwise 
         */
        public bool inArray(int row, int col)
        {
            return (row >= 0 && row < size && col >= 0 && col < size);
        }

        /*
        * Checks to see if the board is completely full of selected squares and live sites
        * 
        * @return bool returns true if board is full and game is over, return false if there are still unvisited sites that are not live
        */
        public bool winner()
        {
            int counter = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (Grid[row, col].Live == true || Grid[row, col].Visited == true)
                    {
                        counter++;
                    }
                }
            }
            if(counter == (size * size))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
       * Sets all cells in area with neighbors == 0 to visted
       * 
       * @Param Row The row of the cell
       * @Param Col The col of the cell
       */
        public void FloodFill(int Row, int Col)
        {
            if (Grid[Row, Col].Neighbors == 0)
            {
                // Top
                if (inArray(Row - 1, Col))
                {
                    if (Grid[Row - 1, Col].Live == false && !Grid[Row - 1, Col].Visited)
                    {
                        Grid[Row - 1, Col].Visited = true;
                        FloodFill(Row - 1, Col);
                    }
                }

                // Top Right
                if (inArray(Row - 1, Col - 1))
                {
                    if (Grid[Row - 1, Col - 1].Live == false && !Grid[Row - 1, Col - 1].Visited)
                    {
                        Grid[Row - 1, Col - 1].Visited = true;
                        FloodFill(Row - 1, Col - 1);
                    }
                }

                // Top Left
                if (inArray(Row - 1, Col + 1))
                {
                    if (Grid[Row - 1, Col + 1].Live == false && !Grid[Row - 1, Col + 1].Visited)
                    {
                        Grid[Row - 1, Col + 1].Visited = true;
                        FloodFill(Row - 1, Col + 1);
                    }
                }

                // Right
                if (inArray(Row, Col - 1))
                {
                    if (Grid[Row, Col - 1].Live == false && !Grid[Row, Col - 1].Visited)
                    {
                        Grid[Row, Col - 1].Visited = true;
                        FloodFill(Row, Col - 1);
                    }
                }

                // Left
                if (inArray(Row, Col + 1))
                {
                    if (Grid[Row, Col + 1].Live == false && !Grid[Row, Col + 1].Visited)
                    {
                        Grid[Row, Col + 1].Visited = true;
                        FloodFill(Row, Col + 1);
                    }
                }

                // Bottom
                if (inArray(Row + 1, Col))
                {
                    if (Grid[Row + 1, Col].Live == false && !Grid[Row + 1, Col].Visited)
                    {
                        Grid[Row + 1, Col].Visited = true;
                        FloodFill(Row + 1, Col);
                    }
                }

                // Bottom Right
                if (inArray(Row + 1, Col - 1))
                {
                    if (Grid[Row + 1, Col - 1].Live == false && !Grid[Row + 1, Col - 1].Visited)
                    {
                        Grid[Row + 1, Col - 1].Visited = true;
                        FloodFill(Row + 1, Col - 1);
                    }
                }

                // Bottom Left
                if (inArray(Row + 1, Col + 1))
                {
                    if (Grid[Row + 1, Col + 1].Live == false && !Grid[Row + 1, Col + 1].Visited)
                    {
                        Grid[Row + 1, Col + 1].Visited = true;
                        FloodFill(Row + 1, Col + 1);
                    }
                }
            }
        }
    }
}
