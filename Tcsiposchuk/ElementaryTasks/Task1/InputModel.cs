using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class InputModel
    {
        public int WeightBoard { get; set; }

        public int HeightBoard { get; set; }

        public InputModel(int weight, int height)
        {
            if (weight < 1 || weight > 32)
                throw new ArgumentException("Ширина доски не удолетворяет условие быть целым числом от 1 до 32");
            if (height < 1 || height > 32)
                throw new ArgumentException("Высота доски не удолетворяет условие быть целым числом от 1 до 32");
            WeightBoard = weight;
            HeightBoard = height;
        }

        public InputModel(string weight, string height) : this(Convert.ToInt32(weight), Convert.ToInt32(height))
        {

        }
    }
}
