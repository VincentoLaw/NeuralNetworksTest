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
            Perceptron perc = new Perceptron(6, 1, 2);
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
            }
        }
    }
}
