using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent_of_Code.Day_08
{
    class SIFImage
    {
        private readonly IEnumerable<int> _imageData;

        public int X { get; }
        public int Y { get; }
        public int LayerSize { get { return X * Y; } }

        public List<List<int>> Layers { get; private set; }

        public SIFImage(int x, int y)
        {
            this.X = x;
            this.Y = y;

            this.Layers = new List<List<int>>();
        }

        public SIFImage(IEnumerable<int> imageData, int x, int y) : this(x, y)
        {
            _imageData = imageData; ;

            ParseLayers(_imageData.ToList());
        }

        public SIFImage(string imageFilename, int x, int y) : this(x, y)
        {
            string stringimagedata = System.IO.File.ReadAllText(imageFilename);

            this._imageData = from s in stringimagedata
                              select int.Parse(s.ToString());

            ParseLayers(_imageData.ToList());
        }

        private void ParseLayers(List<int> raw)
        {
            if (raw.Count % LayerSize != 0)
            {
                throw new ArgumentException("Input data length was not a multiple of x*y");
            }
            
            List<int> thisLayer;
            int startIndex;

            for (int i = 0; i < (raw.Count / LayerSize); i++)
            {
                startIndex = i * LayerSize;
                thisLayer = raw.GetRange(startIndex, LayerSize);
                Layers.Add(thisLayer);
            }

        }

        public void PrintLayer1()
        {
            for (int i = 0; i < Y; i++)
            {
                Console.WriteLine(_imageData.Take(X).Aggregate((i, j) => i + j));
            }
        }
    }
}
