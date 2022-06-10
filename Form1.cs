using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void roll_button_Click_1(object sender, EventArgs e)
        {
            Dice dice = new Dice();
            int[] player1_results = dice.true_roll_the_dice();
            int[] player2_results = dice.cheating_roll_the_dice();
            label1.Text = Convert.ToString(player1_results[0]);
            label5.Text = Convert.ToString(player1_results[1]);
            
            label2.Text = Convert.ToString(player2_results[0]);
            label6.Text = Convert.ToString(player2_results[1]);
            
            label7.Text = Convert.ToString(player1_results.Sum());
            label8.Text = Convert.ToString(player2_results.Sum());


            
            if (player1_results.Sum() > player2_results.Sum())
            {
                textBox1.Text = "Player1 is a winner!";
            }
            else if (player1_results.Sum() == player2_results.Sum())
            {
                textBox1.Text = "Dead heat!";
            }
            else
            {
                textBox1.Text = "Player2 is a winner!";
            }
           
        }
    }

    class Dice
    {
        public double[] probabilities = new double[6] { 0.166666667, 0.166666667, 0.166666667, 0.166666667, 0.166666667, 0.166666667 };
        Random rnd = new Random();
        public int roll_the_dice()
        {
            
            double A = rnd.NextDouble();
            Console.WriteLine(A);
            int k = 0;
            A -= probabilities[k];

            while (A > 0)
            {
                k++;
                A -= probabilities[k];
            }
            return k + 1;
 
        }

        public int cheating_roll_the_dice(double[] cheating_probs)
        {
            double A = rnd.NextDouble();
            Console.WriteLine(A);
            int k = 0;
            A -= cheating_probs[k];

            while (A > 0)
            {
                k++;
                A -= cheating_probs[k];
            }
            return k + 1;
        }

        public int[] cheating_roll_the_dice()
        {
            int[] results_of_computer = { 0, 0 };
            double[] cheating_probabilities = new double[6] { 0.1, 0.1, 0.15, 0.2, 0.2, 0.25 };
            results_of_computer[0] = cheating_roll_the_dice(cheating_probabilities);
            results_of_computer[1] = cheating_roll_the_dice(cheating_probabilities);
            return results_of_computer;
        }

        public int[] true_roll_the_dice()
        {
            int[] results_of_player = { 0, 0 };
            results_of_player[0] = roll_the_dice();
            results_of_player[1] = roll_the_dice();
            return results_of_player;
        }
    }
}