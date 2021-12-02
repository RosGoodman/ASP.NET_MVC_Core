
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Lesson_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread _thread;
        private int _fibCount = 1;
        private int _regulator = 1;

        private List<int> _numbs;
        private int _num;
        
        private object _locker = new object();

        /// <summary> Регулятор кол-ва секунд. </summary>
        public int Regulator
        {
            get => _regulator / 1000;
            set => _regulator = value * 1000;
        }

        /// <summary> Число Фибоначчи. </summary>
        public int Numb { get; set; }

        /// <summary> Порядковый номер числа Фибоначчи. </summary>
        public int FibNumb
        {
            get => _fibCount;
            set
            {
                if(int.TryParse(value.ToString(), out _num) && value > 0 && value <= 35)
                {
                    _fibCount = value;
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
            _numbs = new List<int>();
            for (int i = 1; i < _fibCount; i++)
            {
                _numbs.Add(Fibonachi(i));
            }
             
            _thread = new Thread(() => 
            {
                foreach (var n in _numbs)
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
                        {
                            tb.Text = n.ToString();
                            Thread.Sleep(_regulator);

                            //Task 3
                            //Thread.ResetAbort(); //System.PlatformNotSupportedException: "Thread abort is not supported on this platform."
                        });
                }
            });
            _thread.Start();
            _thread.Join();
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
