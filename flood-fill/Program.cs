using System;

namespace flood_fill
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = new int[,] { { 0, 0, 0 }, { 0, 1, 1 } };
            var result = FloodFill(image, 1, 1, 1);
            for (var i = 0; i < image.GetLength(0); i++)
            {
                for (var j = 0; j < image.GetLength(1); j++)
                    System.Console.Write(image[i, j] + "\t");
                Console.WriteLine();
            }
            System.Console.WriteLine();
        }

        public static int[,] FloodFill(int[,] image, int sr, int sc, int newColor)
        {
            if (image == null || image.GetLength(0) == 0)
                return image;
            var old = image[sr, sc];
            if (old != newColor)
                Helper(image, sr, sc, old, newColor);

            return image;
        }

        private static void Helper(int[,] image, int sr, int sc, int old, int newColor)
        {
            if (image[sr, sc] == old)
                image[sr, sc] = newColor;
            else
                return;

            var dirs = new int[,]
            {
            {0,1},
            {1,0},
            {0,-1},
            {-1,0}
            };

            for (var k = 0; k < 4; k++)
            {
                var nx = sr + dirs[k, 0];
                var ny = sc + dirs[k, 1];

                if (nx >= 0 && ny >= 0 && nx < image.GetLength(0) && ny < image.GetLength(1))
                    Helper(image, nx, ny, old, newColor);
            }
        }
    }
}
