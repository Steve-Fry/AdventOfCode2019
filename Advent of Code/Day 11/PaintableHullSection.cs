using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent_of_Code.Day_11
{
    /// <summary>
    /// Hull section - ready to be painted. All squares are black by default. 
    /// However we use a -1 to denote black unpainted and 0 for black painted. 
    /// (1 is white painted). 
    /// </summary>
    class PaintableHullSection
    {
        List<List<int>> _hull;

        public PaintableHullSection()
        {
            _hull = new List<List<int>>();
            
            // Init a 200x200 grid. 
            for (int i = 0; i < 200; i++)
            {
                _hull.Add(Enumerable.Repeat(-1, 200).ToList());
            }
        }

        /// <summary>
        /// Set the colour of a specified hull panel. We offset by 100 panels for simplicity. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="colour"></param>
        internal void SetColour(int x, int y, long colour)
        {
            _hull[x+100][y+100] = (int)colour;
        }

        internal int GetColour(int x, int y)
        {
            
            int colour = _hull[x+100][y+100];
            if (colour == -1)
            {
                return 0;
            }
            else
            {
                return colour;
            }
        }

        internal int CountPaintedPanels()
        {
            int i = 0;
            foreach (var row in _hull)
            {
                foreach (var val in row)
                {
                    if (val == 1 || val == 0) { i++; }
                }
            }
            return i;
        }

        public string GetAreaOfInterest()
        {
            StringBuilder output = new StringBuilder();
            int min_x = 200;
            int min_y = 200;
            int max_x = 0;
            int max_y = 0;

            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 200; j++)
                {
                    if (_hull[i][j] == 0 || _hull[i][j] == 1)
                    {
                        min_x = Math.Min(j, min_x);
                        min_y = Math.Min(i, min_y);
                        
                        max_x = Math.Max(j, max_x);
                        max_y = Math.Max(i, max_y);
                    }
                }
            }

            for (int i = max_y+2; i > min_y-2; i--)
            {
                for (int j = max_x+2; j > min_x-2; j--)
                {
                    switch (_hull[i][j])
                    {
                        case -1:
                            output.Append('.');
                            break;
                        case 0:
                            output.Append('.');
                            break;
                        case 1:
                            output.Append('#');
                            break;
                    }
                }
                output.Append(Environment.NewLine);
            }

            return output.ToString();
        }
    }
}
