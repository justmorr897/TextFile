using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace TextFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region colours

        //Create list to store strings from the file
        List<string> colourList;

        private void loadColoursButton_Click(object sender, EventArgs e)
        {
            colourList = File.ReadAllLines("Colours.txt").ToList();

            DisplayColours();
        }

        private void saveColoursButton_Click(object sender, EventArgs e)
        {
            File.WriteAllLines("Colours.txt", colourList);
        }

        private void sortColoursButton_Click(object sender, EventArgs e)
        {

        }

        private void addColourButton_Click(object sender, EventArgs e)
        {
            string newColour = colourInput.Text;
            colourList.Add(newColour);

            DisplayColours();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }

        public void DisplayColours()
        {
            colourOutput.Text = "";

            foreach (string colour in colourList)
            {
                colourOutput.Text += $"{colour}\n";
            }
        }

        #endregion


        #region scores

        //Create a list to hold HighScore objects
        List<HighScorecs> scores = new List<HighScorecs>();

        private void loadScoresButton_Click(object sender, EventArgs e)
        {
            List<string> scoreList = File.ReadAllLines("scoreFile.txt").ToList();

            for(int i = 0; i < scoreList.Count; i += 2)
            {
                string name = scoreList[i];
                int score = Convert.ToInt32((scoreList[i+ 1]));

                HighScorecs hs = new HighScorecs(name, score);
                scores.Add(hs);
            }
            
            DisplayScores();
        }

        private void saveScoresButton_Click(object sender, EventArgs e)
        {

        }

        private void sortScoresButton_Click(object sender, EventArgs e)
        {

        }

        private void addScoreButton_Click(object sender, EventArgs e)
        {
            string name = nameInput.Text;
            int score = Convert.ToInt32((scoreInput.Text));

            HighScorecs hs = new HighScorecs(name, score);
            scores.Add(hs);

            DisplayScores();
        }

        private void removeScoresButton_Click(object sender, EventArgs e)
        {

        }

        public void DisplayScores()
        {
            scoreOutput.Text = "";

            foreach (HighScorecs hs in scores)
            {
                scoreOutput.Text += $"{hs.name} {hs.score}\n";
            }
        }

        #endregion
    }
}
