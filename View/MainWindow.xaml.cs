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

namespace Novella
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentTextIndex = 0;
        private string[] texts = {
            "Текст мыслей автора 1",
            "Текст мыслей автора 2",
            "Текст мыслей автора 3",
            "Текст мыслей автора 4"
        };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);

            textBlock.Text = texts[currentTextIndex];
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentTextIndex++;
            if (currentTextIndex < texts.Length)
            {
                textBlock.Text = texts[currentTextIndex];
            }
            else
            {
                var minigame1 = new Minigame1();
                minigame1.Show();
                this.Close();
            }
        }
    }
}
