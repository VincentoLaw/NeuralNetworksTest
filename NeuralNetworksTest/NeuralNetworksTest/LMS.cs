using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworksTest
{
    class LMS
    {
        int[] W;//основной вопрос - какие значения принимает W? int? double? bool lol?
        //ну и так же появляется вопрос, что на вход можно давать. 0 и 1 или всё что угодно? 
        //теоретически вроде можно всё что угодно...
        int inputSize;
        double learningRate;
        public LMS(int input_vector_size, double learning_rate = 0.5)
        {
            inputSize = input_vector_size + 1;
            learningRate = learning_rate;
            W = new int[inputSize];
            for (int i = 0; i < inputSize; i++)
                W[i] = 0;
        }
        public void Learn(int[] learn_vector, int answer_class)
        {
            int vector_class = Classify(learn_vector);
            if (vector_class != answer_class)
            {
                W[0] = (int)(learningRate * (answer_class - vector_class));
                for (var i = 1; i < inputSize; i++)
                    W[i] += (int)(learningRate * (answer_class - vector_class) * learn_vector[i - 1]);
            }
        }
        public int Classify(int[] input_vector){
            int sum = 0;
            for (var i = 0; i < inputSize; i++)
            {
                if (i == 0)
                    sum += 1 * W[i];
                else sum += input_vector[i - 1] * W[i];
            }
            if (sum > 0) return 1;
            else return -1;
        }
    }
}
