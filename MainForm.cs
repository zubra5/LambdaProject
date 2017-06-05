using System;
using System.Windows.Forms;

namespace LambdaProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            btnOK.Click += delegate { MessageBox.Show("Нажата кнопка ОК."); };//анонимный методв

            LambdaExp(); 

            //рекурсия
            Recursion(10);

            Closures(12);
        }

        /// <summary>
        /// рекурсия
        /// </summary>
        /// <param name="cnt">кол-во циклов внутри рекурсии</param>
        private void Recursion(int cnt) {
            Console.WriteLine("This is a recursion.");
            Func<int, int> fc = null;
            fc = i =>
            {
                Console.WriteLine(i);
                return i == 0 ? 0 : fc(--i);
            };
            fc(cnt);
        }

        /// <summary>
        /// работа с лямба выражениями
        /// </summary>
        private void LambdaExp() 
        {
            //после объявление лямба выражений класс Calculator стал лишним
            //Calculator calc = new Calculator();
            Func<int, int, int> func = (x, y) => x - y;

            //в функцию передаем функцию
            Func<int, Func<int, int, int>, int> func2 = (k, f) => f(2, 3) * k;
            int result = func2(5, func);

            lblOutput.Text = String.Format("Результат вычисления - {0}", result);
        }

        private void Closures(int cnt) 
        {
            Console.WriteLine("This is a closures.");

            Action action = null;//не принимает параметры и возрващает выходного значения

            for (int cycleCounter = 1; cycleCounter <= cnt; cycleCounter++) 
            {
                int buffer = cycleCounter;//будет инициализироваться cnt раз и каждый экземпляр этого класса будет содержать свое значение buffer
                action += () => Console.WriteLine(buffer);//замыкание               
            }
            //cycleCounter данная переменная будет видна вне цикла, так как мы использовали ее в замыкании
            action();//все замыкания будут ссылать на один и тот же экземпляр класса
        }
    }
}
