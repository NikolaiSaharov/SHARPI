using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Novella.Model;
using Novella;
using System.Windows;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private GameModel _gameModel;

    public MainWindowViewModel(Window window)

    {
        _gameModel = new GameModel
        {
            CurrentTextIndex = 0,
            Texts = new string[]
            {
                "Текст мыслей автора 1",
                "Текст мыслей автора 2",
                "Текст мыслей автора 3",
                "Текст мыслей автора 4"
            }
        };
        _window = window;
        NextCommand = new RelayCommand(NextButton_Click);
    }

    public ICommand NextCommand { get; private set; }

    public string CurrentText
    {
        get { return _gameModel.Texts[_gameModel.CurrentTextIndex]; }
    }

    private void NextButton_Click()
    {
        _gameModel.CurrentTextIndex++;
        if (_gameModel.CurrentTextIndex < _gameModel.Texts.Length)
        {
            OnPropertyChanged(nameof(CurrentText));
        }
        else
        {
            var minigame1 = new Minigame1();
            minigame1.Show();
            _window.Close();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}