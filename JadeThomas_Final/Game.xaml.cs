using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace JadeThomas_Final
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        private string[] MOVIES = { "The Apartment", "Metropolis" , "Taxi Driver" };
        User player;
        //DBInterface db = new DBInterface();
        public Game()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

             player = (User)e.Parameter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            char[] movie;
            for (int i = 0; i < MOVIES.Length; i++)
            {
                movie = MOVIES[i].ToCharArray();
                for (int j = 0; j < movie.Length; j++)
                {
                    
                    if (letterTxtbx.Text.ToUpper() == movie[j].ToString().ToUpper())
                    {
                        hintTxtblk.Visibility = Visibility.Visible;
                        hintTxtblk.Text = "the letter is within the string";
                    }
                    else
                    {
                        hintTxtblk.Visibility = Visibility.Visible;
                        hintTxtblk.Text = "the letter is not in the string";
                    }
                }
            }
        }

        private void guessBtn_Click(object sender, RoutedEventArgs e)
        {
            const int GUESSES = 3;
            Random rnd = new Random();//get a random movie everytime
            for (int i = 0; i < GUESSES; i++)
            {
                if (guessTextbx.Text.ToUpper() == MOVIES[rnd.Next(0, 3)].ToUpper())
                {
                    resultTxtBlk.Text = "You guessed it right";
                }
                else
                {
                    resultTxtBlk.Text = "You guessed it wrong";
                }
            }
        }
    }
}
