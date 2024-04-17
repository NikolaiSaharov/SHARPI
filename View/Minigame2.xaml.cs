using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Novella.ViewModels
{
    public class Minigame2ViewModel : INotifyPropertyChanged
    {
        private Random random = new Random();
        private int _playerWins;
        private int _computerWins;
        private string _result;

        public Minigame2ViewModel()
        {
            PlayGameCommand = new RelayCommand<string>(PlayGame);
        }

        public int PlayerWins
        {
            get { return _playerWins; }
            set
            {
                _playerWins = value;
                OnPropertyChanged(nameof(PlayerWins));
            }
        }

        public int ComputerWins
        {
            get { return _computerWins; }
            set
            {
                _computerWins = value;
                OnPropertyChanged(nameof(ComputerWins));
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ICommand PlayGameCommand { get; private set; }

        private void PlayGame(string playerChoice)
        {
            string computerChoice = GetComputerChoice();
            string result = DetermineWinner(playerChoice, computerChoice);

            Result = $"Вы выбрали: {playerChoice}\nКомпьютер выбрал: {computerChoice}\n\n{result}";

            if (result == "Вы победили!")
            {
                PlayerWins++;
                if (PlayerWins == 3)
                {
                    MessageBox.Show("Поздравляем! Вы достигли 3 побед!");
                    // Переход к следующему окну
                    // Например, открываем окно Novella3
                    Novella3 novella3 = new Novella3();
                    novella3.Show();
                    // Закрываем текущее окно
                    CloseWindow();
                }
            }
            else if (result == "Компьютер победил!")
            {
                ComputerWins++;
                if (ComputerWins == 3)
                {
                    MessageBox.Show("Компьютер достиг 3 побед. Вы проиграли!");
                    // Закрываем текущее окно
                    CloseWindow();
                }
            }
            else if (result == "Ничья!")
            {
                PlayerWins = 0;
                ComputerWins = 0;
            }
        }

        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is Minigame2)
                {
                    window.Close();
                    break;
                }
            }
        }

        private string GetComputerChoice()
        {
            int choice = random.Next(3);
            switch (choice)
            {
                case 0: return "Камень";
                case 1: return "Ножницы";
                case 2: return "Бумага";
                default: return "Неизвестно";
            }
        }

        private string DetermineWinner(string playerChoice, string computerChoice)
        {
            if (playerChoice == computerChoice)
                return "Ничья!";

            if ((playerChoice == "Камень" && computerChoice == "Ножницы") ||
                (playerChoice == "Ножницы" && computerChoice == "Бумага") ||
                (playerChoice == "Бумага" && computerChoice == "Камень"))
                return "Вы победили!";

            return "Компьютер победил!";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}