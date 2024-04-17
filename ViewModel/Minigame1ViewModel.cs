using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Novella.ViewModels
{
    public class Minigame1ViewModel : INotifyPropertyChanged
    {
        private int _attempts;
        private int _numberToGuess;

        public Minigame1ViewModel()
        {
            GenerateNumber();
            Attempts = 10;
            GuessCommand = new RelayCommand(GuessButton_Click);
        }

        public int Attempts
        {
            get { return _attempts; }
            set
            {
                _attempts = value;
                OnPropertyChanged(nameof(Attempts));
            }
        }

        public ICommand GuessCommand { get; private set; }

        private void GenerateNumber()
        {
            Random random = new Random();
            _numberToGuess = random.Next(1, 101);
        }

        private void GuessButton_Click()
        {
            if (Attempts > 0)
            {
                int userGuess;
                if (int.TryParse(UserGuessTextBox.Text, out userGuess))
                {
                    if (userGuess == _numberToGuess)
                    {
                        MessageBox.Show("Поздравляем! Вы угадали число.");
                        // Переход к следующему окну
                    }
                    else
                    {
                        Attempts--;
                        // Обработка неверного ответа
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}