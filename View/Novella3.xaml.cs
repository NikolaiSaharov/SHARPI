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
    /// Логика взаимодействия для Novella3.xaml
    /// </summary>
    public partial class Novella3 : Window
    {
        private int currentTextIndex = 0;
        private string[] texts = {
            "Текст мыслей автора 1",
            "Текст мыслей автора 2",
            "Текст мыслей автора 3",
            "Текст мыслей автора 4"
        };
        public Novella3()
        {
            InitializeComponent();
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
                var minigame2 = new Minigame2();
                minigame2.Show();
                this.Close();
            }
        }
    }
}
