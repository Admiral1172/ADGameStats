using System;
using System.IO;
using System.Collections.Generic;
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
using Microsoft.Win32;

namespace ADGameStats
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
             MessageBox.Show("This application can be used to record stats in video games such as K/D, Score, Win/Loss, etc... " +
            "Good for old games that don't record it themselves", "About This Program");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog //creates a save dialog box for user to select a directory to save to.
            {
                Filter = "Text File (*.txt)|*.txt",
                Title = "Save Scores to Text"
            };
            if (saveFileDialog.ShowDialog() == true) //checks if the user selected ok
            {
                File.WriteAllText(saveFileDialog.FileName, ResultBox.Text); //writes results to text file
            }
            
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog //similar to save button but for opening text files
            {
                Filter = "Text File (*.txt)|*.txt",
                Title = "Load Text File"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                ResultBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double FirstValue = Convert.ToInt32(StatBox1.Text);
                double SecondValue = Convert.ToInt32(StatBox2.Text);
                double result = 0;
                Dictionary<int, double> storeVal = new Dictionary<int, double>(); //might use this dictionary for storage in the future for profiles.


                if (ComboBox1.Text == "K/D")
                {
                    result = (FirstValue / SecondValue);
                    storeVal.Add(1, result);
                    ResultBox.Text += "K/D: " + storeVal[1] + Environment.NewLine;

                }
                else if (ComboBox1.Text == "Score")
                {
                    result = FirstValue;
                    storeVal.Add(2, result);
                    ResultBox.Text += "Score: " + storeVal[2] + Environment.NewLine;
                }
                else if (ComboBox1.Text == "Win/Loss")
                {
                    result = (FirstValue / SecondValue);
                    storeVal.Add(3, result);
                    ResultBox.Text += "Win/Loss: " + storeVal[3] + Environment.NewLine;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a number in both boxes if calculating for K/D, Win/Loss.", "Invalid Input");
            }
        }   

        private void Button2_Click(object sender, EventArgs e) //clears boxes
        {
                StatBox1.Text = "";
                StatBox2.Text = "";
                ResultBox.Text = "";
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            StatBox2.IsEnabled = false;
            StatBox2.Text = Convert.ToString(0);
            MessageBox.Show("This button is used for saving scores, second box is disabled", "Button Notification");
        }

        private void ComboBoxItem_Unselected(object sender, RoutedEventArgs e)
        {
            StatBox2.IsEnabled = true;
        }
    }
}
