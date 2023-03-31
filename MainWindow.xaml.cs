﻿using System;
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

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBlock lastTextBlockClicked;
        private bool findingMatch = false;
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "😹‍", "😹‍",
                "🦊", "🦊",
                "🦄", "🦄",
                "🐠", "🐠",
                "🦆", "🦆",
                "🧞", "🧞",
                "🐙", "🐙",
                "🐢", "🐢",
            };

            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>()) 
            {
                int index = random.Next(animalEmoji.Count);
                string nextEmoij = animalEmoji[index];
                textBlock.Text = nextEmoij;
                animalEmoji.RemoveAt(index);
            }
        }


        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textblock = sender as TextBlock;
            if (findingMatch == false)
            {
                textblock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textblock;
                findingMatch = true;
            }
            else if (textblock.Text == lastTextBlockClicked.Text)
            {
                textblock.Visibility = Visibility.Hidden;
                // lastTextBlockClicked = null;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }
    }
}
