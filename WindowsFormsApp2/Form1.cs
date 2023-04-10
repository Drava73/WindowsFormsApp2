using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private int num;
        private int secretNum;
        public Form1()
        {
            InitializeComponent();
            string resume = "Мое резюме:\n\n" +
                "Я - программист. У меня есть опыт работы с базами данных и веб-разработкой. Я также имею знания в алгоритмах и структурах данных.\n\n" +
                "Если вы ищете опытного программиста - свяжитесь со мной.";

            int numBoxes = 3;
            int totalChars = resume.Length;
            int avgCharsPerPage = totalChars / numBoxes;

            MessageBox.Show(resume.Substring(0, avgCharsPerPage));
            MessageBox.Show(resume.Substring(avgCharsPerPage, avgCharsPerPage));
            MessageBox.Show(resume.Substring(avgCharsPerPage * 2));

            MessageBox.Show($"Среднее число символов на странице: {avgCharsPerPage}");
            StartNewGame();
        }
        private void StartNewGame()
        {
            Random rand = new Random();
            secretNum = rand.Next(1, 2001);
            num = 0;
        }
        private void GuessNumber()
        {
            int guess;
            string message = "Введите число от 1 до 2000:";
            string title = "Угадай число";
            string inputnum = Microsoft.VisualBasic.Interaction.InputBox(message, title);

            if (!int.TryParse(inputnum, out guess))
            {
                MessageBox.Show("Введите целое число от 1 до 2000!", "Ошибка ввода");
                return;
            }

            num++;

            if (guess == secretNum)
            {
                double avgGuesses = (double)num / 3;
                string resultMessage = $"Вы угадали число {secretNum} за {num} попыток!\nСреднее число символов на странице: {avgGuesses:F2}";
                MessageBox.Show(resultMessage, "Результат");
                StartNewGame();
            }
            else
            {
                string hint = (guess < secretNum) ? "Мало" : "Много";
                string hintMessage = $"Вы ввели число {guess}. {hint}. Попробуйте еще раз.";
                MessageBox.Show(hintMessage, "Подсказка");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GuessNumber();
        }
    }
}
