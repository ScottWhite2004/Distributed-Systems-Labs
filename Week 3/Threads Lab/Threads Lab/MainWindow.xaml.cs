using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Threads_Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<int> primeNumbers;


        public MainWindow()
        {
            InitializeComponent();
            primeNumbers = new List<int>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ParameterizedThreadStart ts = new ParameterizedThreadStart(FindPrimeNumbers);
            Task T = Task.Run(() => ts.Invoke(20000));
            T.ContinueWith(findPrimesFinished);
        }

        private void FindPrimeNumbers(object param)
        {
            int numberOfPrimesToFind = (int)param;
            int primeCount = 0; int currentPossiblePrime = 1;
            while (primeCount < numberOfPrimesToFind)
            {
                currentPossiblePrime++; int possibleFactor = 2; bool isPrime = true;
                while ((possibleFactor <= currentPossiblePrime / 2) && (isPrime == true))
                {
                    int possibleFactor2 = currentPossiblePrime / possibleFactor;
                    if (currentPossiblePrime == possibleFactor2 * possibleFactor)
                    {
                        isPrime = false;
                    }
                    possibleFactor++;
                }
                if (isPrime)
                {
                    primeCount++;
                    primeNumbers.Add(currentPossiblePrime);
                }
            }
        }

        private void findPrimesFinished(IAsyncResult iar)
        {
            this.Dispatcher.Invoke(
                new Action<int>(updateTextBox),
                new object[] { primeNumbers[19999] });
        }

        private void updateTextBox(int number)
        {
            OutputTextBox.Text = number.ToString();
        }
    }
}