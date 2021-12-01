
using System.Threading;
using System.Windows;

namespace Lesson_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread _thread;
        private int _fibNumb = 0;
        private int _num;

        /// <summary> Число Фибоначчи. </summary>
        public int Numb { get; set; }

        /// <summary> Порядковый номер числа Фибоначчи. </summary>
        public int FibNumb
        {
            get => _fibNumb;
            set
            {
                if(int.TryParse(value.ToString(), out _num) && value > 0 && value <= 35)
                {
                    _fibNumb = value;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <summary> Событие нажатия на кнопку. </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _thread = new Thread(() => { Numb = Fibonachi(_fibNumb); });

            _thread.Start();
            tb.Text = Numb.ToString();
        }

        /// <summary> Вычислить число Фибоначчи по порядковому номеру. </summary>
        /// <param name="n"> Порядковый номер числа. </param>
        /// <returns> Число Фибоначчи. </returns>
        private int Fibonachi(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            return Fibonachi(n - 1) + Fibonachi(n - 2);
        }
    }
}
