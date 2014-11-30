using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NeuralNetworksTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int middle_result = 0;
            for (int k = 0; k < 100; k++)
            {
                
                LMS lms = new LMS(2, 1);
                Random rand = new Random();
                for (var i = 0; i < 100; i++)
                {
                    int[] inp = new int[2];
                    int cnt = 0;
                    for (var j = 0; j < 2; j++)
                    {
                        inp[j] = rand.Next(21) - 10;
                        //if (inp[j] == 1)
                        //    cnt++;
                    }
                    int answer = -1;
                    if (inp[0] + inp[1] > 0)
                        answer = 1;
                    lms.Learn(inp, answer);
                }

                int right_answers_cnt = 0, wrong_answers_cnt = 0;
                for (var i = 0; i < 1000; i++)
                {
                    int[] inp = new int[2];
                    int cnt = 0;
                    for (var j = 0; j < 2; j++)
                    {
                        inp[j] = rand.Next(21) - 10;
                        //if (inp[j] == 1)
                        //    cnt++;
                    }
                    int answer = -1;
                    if (inp[0] + inp[1]> 0)
                        answer = 1;
                    int result_class = lms.Classify(inp);
                    if (answer == result_class)
                        right_answers_cnt++;
                    else wrong_answers_cnt++;
                }
                middle_result += (right_answers_cnt * 100 / 1000);
                //MessageBox.Show((right_answers_cnt * 100 / 1000) + "%");
            }
            middle_result /= 100;
            MessageBox.Show(middle_result + "%");
            /*Perceptron perc = new Perceptron(6, 1, 2);
            Random rand = new Random();
            for (var i = 0; i < 100; i++)
            {
                bool[] inp = new bool[6];
                int cnt = 0;
                for (var j = 0; j < 6; j++)
                {
                    inp[j] = Convert.ToBoolean(rand.Next(2));
                    if (inp[j])
                        cnt++;
                }
                bool[] answer = new bool[1];
                answer[0] = false;
                if (cnt <= 3)
                    answer[0] = true;
                perc.learnMSE(inp, answer);
            }

            for (var i = 0; i < 100; i++)
            {
                bool[] inp = new bool[6];
                for (var j = 0; j < 6; j++)
                    inp[j] = Convert.ToBoolean(rand.Next(2));
                var res = perc.classify(inp);
                if (inp[0] && inp[3])
                {
                    if (res[0])
                        MessageBox.Show("Get it! GOOD");
                    //else MessageBox.Show("Get it! BAD");
                }
                //else if (!res[0]) MessageBox.Show("GOOD");
                //else MessageBox.Show("BAD");
            }*/
        }
    }
}
