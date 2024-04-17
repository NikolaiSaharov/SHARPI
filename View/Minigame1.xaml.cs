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
using System.Windows.Shapes;

namespace Novella
{
    /// <summary>
    /// Логика взаимодействия для Minigame1.xaml
    /// </summary>
    public partial class Minigame1 : Window
    {
        private int attempts = 10;
        private int numberToGuess;
        public Minigame1()
        {
            InitializeComponent();
            GenerateNumber();
        }
        private void GenerateNumber()
        {
            Random random = new Random();
            numberToGuess = random.Next(1, 101);
        }

        private void GuessButton_Click(object sender, RoutedEventArgs e)
        {
            if (attempts > 0)
            {
                int userGuess;
                if (int.TryParse(UserGuessTextBox.Text, out userGuess))
                {
                    if (userGuess == numberToGuess)
                    {
                        MessageBox.Show("Поздравляем! Вы угадали число.");
                        
                        Novella2 novella2 = new Novella2();
                        novella2.Show();
                        
                        this.Close();
                    }
                    else if (userGuess < numberToGuess)
                    {
                        MessageBox.Show("Загаданное число больше.");
                    }
                    else
                    {
                        MessageBox.Show("Загаданное число меньше.");
                    }

                    attempts--;
                    AttemptsLabel.Content = $"Осталось попыток: {attempts}";
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите число.");
                }
            }
            else
            {
                MessageBox.Show("Игра окончена. Вы исчерпали все попытки.");
                GenerateNumber();
                attempts = 10;
            }

            UserGuessTextBox.Text = "";
        }
    }
}
