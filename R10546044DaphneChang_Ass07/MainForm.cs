using DaphneGALibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R10546044DaphneChang_Ass07
{
    public partial class MainForm : Form
    {
        BinaryGA myGASolver;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            int numberOfGenes = (int)numericUpDown1.Value;
            splitContainer1.Panel2.Controls.Clear();
            myGASolver = new BinaryGA(64, OptimizationType.Maximization, JobAssignmentObjectiveFunction, splitContainer1.Panel2);
            // propertyGrid1.SelectedObject = myGASolver;
            // myGASolver = new BinaryGA(numberOfGenes, OptimizationType.Minimization, MinimizationProblem001, splitContainer1.Panel2);
            myGASolver.SoFarTheBestSolutionUpdated += MyGASolver_SoFarTheBestSolutionUpdated;
            myGASolver.RestButton.Click += RestButton_Click;

            myGASolver.dgvGenerateProblem();
        }

        private void RestButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GA Reset Button is clicked");
        }

        StringBuilder sb = new StringBuilder();
        private void MyGASolver_SoFarTheBestSolutionUpdated(object sender, EventArgs e)
        {
            sb.Clear();
            chart1.Series[0].Points.Clear();
            foreach (byte b in myGASolver.CurrentBestSolution)
            {
                sb.Append($"{b}, ");
                chart1.Series[0].Points.AddY(b);
            }
            sb.Append($"obj = {myGASolver.CurrentBestObjectiveValue}");
            labSoFarTheBestSolution.Text = sb.ToString();
        }

        /// <summary>
        /// haven't done
        /// </summary>
        /// <param name="aSolution"></param>
        /// <returns></returns>
        // maximization problem if all variables are one (not zero) it is the global best
        private double JobAssignmentObjectiveFunction(byte[ ] aSolution)
        {
            double sum = 0;
            foreach (byte b in aSolution) sum += b;
            return sum;
            //.............
        }

        // minimization problem if all variables are zero.
        private double MinimizationProblem001(byte[ ] aSolution)
        {
            double sum = 0;
            foreach (byte b in aSolution) sum += b;
            return sum;
        }

        // Another optimization problem
        private double MinimizationProblem002(byte[] aSolution)
        {
            double sum = 0;
            for (int i = 0; i < aSolution.Length; i++)
            {
                if (i % 2 == 0)  //if i is even
                {
                    if (aSolution[i] == 1) sum++;
                }
                else
                {
                    if (aSolution[i] == 0) sum++;
                }
            }
            return sum;
        }

        int numberOfJobs;
        int[] rowViolationCounts;
        int[] columnViolationCounts;
        byte[,] solutionMatrix;

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            StreamReader sr = new StreamReader(openFileDialog1.FileName);

            string str = sr.ReadLine();
            numberOfJobs = int.Parse(str);

            rowViolationCounts = new int[numberOfJobs];
            columnViolationCounts = new int[numberOfJobs];
            solutionMatrix = new byte[numberOfJobs, numberOfJobs];

            str = "2.3, 4.5, 1.2, 1.0, 4.5, 23.0, 7, 8 ";
            char[] seps = { ',', ' ' };
            string[] items = str.Split(seps, StringSplitOptions.RemoveEmptyEntries);
            sr.Close();

        }
    }
}
