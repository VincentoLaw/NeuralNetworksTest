using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworksTest
{
    class Perceptron
    {
        /// <summary>
        /// W is weight matrix. 1st layer have inputVectorSize * 2 size. 
        /// Second have size equal to neurons count, it is neuronsCount;
        /// </summary>
        public int[,] W;
        public int[] N;//тут пока что только пороги А элементов. Для R они не нужны.
        int inputVectorSize;
        int outputVectorSize;
        int neuronsCount;
        int fstLayerSize;
        int outputClassesCount;
        public Perceptron(int input_vector_size, int output_vector_size, int output_classes_count)
        {
            Random rand = new Random();
            inputVectorSize = input_vector_size; 
            outputVectorSize = output_vector_size;
            fstLayerSize = input_vector_size;
            W = new int[2, fstLayerSize];
            neuronsCount = input_vector_size / 2 + input_vector_size % 2;
            N = new int[neuronsCount];

            for (var j = 0; j < fstLayerSize; j++)
            {
                W[0, j] = rand.Next(2);
                if (W[0, j] == 0)
                    W[0, j]--;
            }
            for (var j = 0; j < fstLayerSize; j++)
                W[1, j] = 0;
            for (var j = 0; j < neuronsCount; j++)
                N[j] = rand.Next(3) - 1;
        }
        public void learnMSE(bool[] input_vector, bool[] ouput_class){
            for (var i = 0; i < fstLayerSize; i += 2)
            {
                if (W[0, i] * Convert.ToInt32(input_vector[i]) + W[0, i + 1] * Convert.ToInt32(input_vector[i + 1]) > N[i / 2])
                {
                    if (ouput_class[i / 6])
                        W[1, i / 2]++;
                    else W[1, i / 2]--;
                }
            }
        }
        public bool[] classify(bool[] input_vector)
        {
            bool [] result = new bool[neuronsCount / 3];
            for (var i = 0; i < fstLayerSize; i += 6)
            {
                int sum = 0;
                int sig1 = W[0, i] * Convert.ToInt32(input_vector[i]) + W[0, i + 1] * Convert.ToInt32(input_vector[i + 1]);
                int sig2 = W[0, i + 2] * Convert.ToInt32(input_vector[i + 2]) + W[0, i + 3] * Convert.ToInt32(input_vector[i + 3]);
                int sig3 = W[0, i + 4] * Convert.ToInt32(input_vector[i + 4]) + W[0, i + 5] * Convert.ToInt32(input_vector[i + 5]);
                if (sig1 > N[i / 2])
                    sum += W[1, i / 2];
                if (sig2 > N[(i + 2) / 2])
                    sum += W[1, (i + 2) / 2];
                if (sig3 > N[(i + 4) / 2])
                    sum += W[1, (i + 4) / 2];
                if (sum >= 1) result[i / 6] = true;
                else result[i / 6] = false;
            }
            return result;
        }
    }
}
