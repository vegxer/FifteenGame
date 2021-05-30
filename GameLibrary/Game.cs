using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Game
    {
        int[,] field;
        int width, height, x0, y0;

        public Game(int width, int height)
        {
            if (width > 1 && height > 1 && width < 11 && height < 11)
            {
                this.width = width;
                this.height = height;
                field = new int[height, width];
            }
        }

        public Memento CreateGameState()
        {
            return new Memento(field);
        }

        public void SetGameState(Memento GameState)
        {
            field = GameState.GetGameState;
            int x0, y0;
            CoordinatatesOf(0, out x0, out y0);
            this.x0 = x0;
            this.y0 = y0;
        }

        private void CoordinatatesOf(int element, out int x, out int y)
        {
            x = y = -1;
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    if (field[i, j] == element)
                    {
                        x = j;
                        y = i;
                    }
        }

        public void Start()
        {
            int[] numbers = GeneratePermutation();

            int k = 0;
            for (int i = 0; i < height; ++i)
                for (int j = 0; j < width; ++j)
                {
                    field[i, j] = numbers[k++];
                    if (field[i, j] == 0)
                    {
                        x0 = j;
                        y0 = i;
                    }
                }
        }

        public bool End()
        {
            if (field[height - 1, width - 1] != 0)
                return false;
            for (int i = 0; i < height; ++i)
                for (int j = 0; j < width - (i + 1) / height; ++j)
                    if (field[i, j] != CoordinatesToPosition(j, i) + 1)
                        return false;
            return true;
        }

        private int[] GeneratePermutation()
        {
            int[] permutation = new int[height * width];
            for (int i = 0; i < height * width; ++i)
                permutation[i] = i;

            Random rnd = new Random();
            do
            {
                permutation = permutation.OrderBy(x => rnd.Next()).ToArray();
            }
            while (!End() && !EvenPermutation(permutation));

            return permutation;
        }

        private bool EvenPermutation(int[] permutation)
        {
            int incorrectPairs = 0;
            for (int i = 0; i < permutation.Length; ++i)
            {
                if (permutation[i] != 0)
                {
                    for (int j = i + 1; j < permutation.Length; ++j)
                        if (permutation[j] != 0 && permutation[i] > permutation[j])
                            ++incorrectPairs;
                }
                else
                    incorrectPairs += i / width + ((height + width) % 2 == 0 ? 1 : 0);
            }

            return incorrectPairs % 2 == 0;
        }

        public int GetNumber(int position)
        {
            int x, y;
            PositionToCoordinates(position, out x, out y);
            return field[y, x];
        }

        public int Shift(int position)
        {
            int x, y;
            PositionToCoordinates(position, out x, out y);
            int buttX = x;
            int buttY = y;

            if ((Math.Abs(x - x0) == 1 && y == y0) || (x == x0 && Math.Abs(y - y0) == 1))
            {
                field[y0, x0] = field[y, x];
                field[y, x] = 0;
                buttX = x0;
                buttY = y0;
                x0 = x;
                y0 = y;
            }

            return CoordinatesToPosition(buttX, buttY);
        }

        private int CoordinatesToPosition(int x, int y)
        {
            if (x < 0 || y < 0 || x >= width || y >= height)
                throw new ArgumentException();
            return width * y + x;
        }

        private void PositionToCoordinates(int position, out int x, out int y)
        {
            x = -1;
            y = -1;
            if (position < 0 || position >= width * height)
                throw new ArgumentException();
            y = position / width;
            x = position % width;
        }
    }
}
