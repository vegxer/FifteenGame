using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Memento
    {
        int[,] field;

        public Memento(int[,] field)
        {
            this.field = new int[field.GetLength(0), field.GetLength(1)];
            Copy(field, this.field);
        }

        private void Copy(int[,] arr1, int[,] arr2)
        {
            if (arr1.GetLength(0) == arr2.GetLength(0) && arr1.GetLength(1) == arr2.GetLength(1))
            {
                for (int i = 0; i < arr1.GetLength(0); ++i)
                    for (int j = 0; j < arr1.GetLength(1); ++j)
                        arr2[i, j] = arr1[i, j];
            }
            else
                throw new ArgumentException();
        }

        public int[,] GetGameState
        {
            get
            {
                /*int[,] fieldCopy = new int[field.GetLength(0), field.GetLength(1)];
                Copy(field, fieldCopy);*/
                return field;
            }
        }
    }
}
