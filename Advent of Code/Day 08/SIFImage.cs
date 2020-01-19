using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent_of_Code.Day_08
{
    class SIFImage
    {
        private readonly List<int> _imageData;

        public int XPixels { get; }
        public int YPixels { get; }
        public int LayerSize { get { return XPixels * YPixels; } }

        private Dictionary<int, char> _pixelMap;

        public IEnumerable<List<int>> Layers
        {
            get
            {
                for (int i = 0; i < _imageData.Count; i+=LayerSize)
                {
                    yield return _imageData.GetRange(i, LayerSize);
                }
            }
        }

        public SIFImage(int x, int y)
        {
            this.XPixels = x;
            this.YPixels = y;

            PopulateDefaultPixelMap();
        }

        public SIFImage(IEnumerable<int> imageData, int x, int y) : this(x, y)
        {
            _imageData = imageData.ToList();
        }

        public SIFImage(string imageFilename, int x, int y) : this(x, y)
        {
            string stringimagedata = System.IO.File.ReadAllText(imageFilename);

            this._imageData = (from s in stringimagedata
                               select int.Parse(s.ToString())
                               ).ToList();
        }

        private void PopulateDefaultPixelMap()
        {
            _pixelMap = new Dictionary<int, char>()
            {
                [0] = '.', // Black
                [1] = '#', // White
                [2] = ' ', // Transparent
            };
        }

        public int Checksum
        {
            get
            {
                return Layers
                        .Select(x => (Zeros: x.Count(y => y == 0),
                                      Ones: x.Count(z => z == 1),
                                      Twos: x.Count(w => w == 2)))
                        .OrderBy(x => x.Zeros)
                        .Select(x => x.Ones * x.Twos)
                        .First();
            }
        }

        public List<int> StackedImage
        {
            get
            {
                List<int> output = Enumerable.Repeat(2, LayerSize).ToList();

                for (int i = 0; i < LayerSize; i++)
                {
                    foreach (var layer in Layers)
                    {
                        if (layer[i] != 2)
                        {
                            output[i] = layer[i];
                            break;
                        }
                    }
                }

                return output;
            }
        }

        public void RenderImageToConsole()
        {
            var output = StackedImage;

            for (int rowIndex = 0; rowIndex < YPixels; rowIndex++)
            {
                int rowStartIndex = rowIndex * XPixels;
                string rowAsString = output.GetRange(rowStartIndex, XPixels).Select(x => _pixelMap[x].ToString()).Aggregate((i, j) => $"{i}{j}");
                Console.WriteLine(rowAsString);
            }
        }
    }
}
