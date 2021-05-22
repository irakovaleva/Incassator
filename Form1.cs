using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Incassator
{
    public partial class Form1 : Form
    {
        public Task task;
        public string fileToOpen;
        public Form1()
        {
            InitializeComponent();
            task = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFile_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            FD.InitialDirectory = @"D:\Anya\Tests";
            fileToOpen = "";
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileToOpen = FD.FileName;
            }
            if (fileToOpen != "")
            {
                selectFileTextBox.Text = fileToOpen;
                selectFileTextBox.ForeColor = Color.Black;
                this.task = MainAlgorithm.openTask(fileToOpen);
                this.Draw(this.task);
                this.otherSolutionsTitle.Text = "Other solutions with lower value of directive faults:";
                this.solutionText.Text = "";
                this.otherSolutionsLabel.Text = "";
                this.bruteForceText.Text = "";
                this.timeMVGText.Text = "";
                this.timeBruteForceText.Text = "";
                this.timeBinaryText.Text = "";
            }
        }

        private void Draw(Task task)
        {
            matrixCorePanel.Controls.Add(matrixTablePanel);
            profitCorePanel.Controls.Add(profitTablePanel);
            directiveCorePanel.Controls.Add(directiveTablePanel);

            matrixTablePanel.Visible = false;
            profitTablePanel.Visible = false;
            directiveTablePanel.Visible = false;
            profitTablePanel.Controls.Clear();
            matrixTablePanel.Controls.Clear();
            directiveTablePanel.Controls.Clear();
            matrixTablePanel.SuspendLayout();
            profitTablePanel.SuspendLayout();
            directiveTablePanel.SuspendLayout();
            matrixTablePanel.ColumnCount = task.numOfLocations + 1;
            matrixTablePanel.RowCount = task.numOfLocations + 1;
            profitTablePanel.ColumnCount = task.numOfLocations;
            directiveTablePanel.ColumnCount = task.numOfLocations - 1;
            for (int i = 0; i < task.numOfLocations + 1; i++)
            {
                string text = (i == 0) ? " " : Convert.ToString(i - 1);
                text = (i == 1) ? "B" : text;
                Label label = new Label();
                label.AutoSize = true;
                label.Text = text;
                label.Font = new Font(DefaultFont, FontStyle.Bold);
                matrixTablePanel.Controls.Add(label, 0, i);
                if (i != 0)
                {
                    Label profit = new Label();
                    profit.AutoSize = true;
                    profit.Text = text;
                    profit.Font = new Font(DefaultFont, FontStyle.Bold);
                    profitTablePanel.Controls.Add(profit, i - 1, 0);
                    if (i != 1)
                    {
                        Label directive = new Label();
                        directive.AutoSize = true;
                        directive.Text = text;
                        directive.Font = new Font(DefaultFont, FontStyle.Bold);
                        directiveTablePanel.Controls.Add(directive, i - 2, 0);
                    }
                }
            }

            for (int i = 1; i < task.numOfLocations + 1; i++)
            {
                string text = (i == 1) ? "B" : Convert.ToString(i - 1);
                Label label = new Label();
                label.AutoSize = true;
                label.Text = text;
                label.Font = new Font(DefaultFont, FontStyle.Bold);
                matrixTablePanel.Controls.Add(label, i, 0);
            }
            for (int i = 0; i < task.numOfLocations; i++)
            {
                for (int j = 0; j < task.numOfLocations; j++)
                {
                    Label label = new Label();
                    string text = Convert.ToString(task.times[i, j]);
                    label.Text = (text == "-1") ? " " : text;
                    label.AutoSize = true;
                    matrixTablePanel.Controls.Add(label, i + 1, j + 1);
                }
            }

            // Add profits and directive times
            for (int i = 0; i < task.numOfLocations; i++)
            {
                Label label = new Label();
                string text = (i == 0) ? Convert.ToString(task.initialSum) : Convert.ToString(task.profitOnVertex[i]);
                label.Text = text;
                label.AutoSize = true;
                profitTablePanel.Controls.Add(label, i, 1);
                if (i != 0)
                {
                    Label directive = new Label();
                    string directiveText = Convert.ToString(task.directiveTime[i]);
                    directive.Text = directiveText;
                    directive.AutoSize = true;
                    directiveTablePanel.Controls.Add(directive, i - 1, 1);
                }
            }
            matrixTablePanel.ResumeLayout();
            matrixTablePanel.Visible = true;
            profitTablePanel.ResumeLayout();
            profitTablePanel.Visible = true;
            directiveTablePanel.ResumeLayout();
            directiveTablePanel.Visible = true;

        }

        private void getSolution_Click(object sender, EventArgs e)
        {
            MainAlgorithm.allSolutions = new List<Solution>();
            if (this.task == null)
            {
                MessageBox.Show("Select file with Task info, please", "No Task Info", MessageBoxButtons.OK);
                return;
            }
            if (MainAlgorithm.globalMin != -1)
            {
                this.task = MainAlgorithm.openTask(fileToOpen);
            }
            this.otherSolutionsTitle.Text = "Other solutions with lower value of directive faults:";
            int bestSolutionIndex = MainAlgorithm.getSolution(task);

            showResults(bestSolutionIndex);
        }

        private void showOtherSolutionFull_Click(object sender, EventArgs e)
        {
            string labelText = this.showFullTextBox.Text;
            int numOfSolution = -1;
            if (MainAlgorithm.allSolutions == null || MainAlgorithm.allSolutions.Count == 0)
            {
                MessageBox.Show("You need to get solution first", "No solution", MessageBoxButtons.OK);
                return;
            }
            try
            {
                numOfSolution = Convert.ToInt32(labelText);
            }
            catch (Exception err)
            {
                MessageBox.Show("Please write NUMBER of needed solution", "Number wasn't got", MessageBoxButtons.OK);
                return;
            }
            if (numOfSolution >= MainAlgorithm.allSolutions.Count)
            {
                MessageBox.Show("You wrote number of solution that doesn't exist", "Incorrect index", MessageBoxButtons.OK);
                return;
            }
            if (MainAlgorithm.allSolutions.Count == 1)
            {
                return;
            }
            solutionText.Text = MainAlgorithm.allSolutions[numOfSolution].getPrint();
            this.otherSolutionsTitle.Text = "Other known solutions:";
            String otherSolutionsText = "";
            for (int i = 0; i < MainAlgorithm.allSolutions.Count; i++)
            {
                if (i != numOfSolution)
                {
                    otherSolutionsText += i + ". " + MainAlgorithm.allSolutions[i].getShortPrint();
                }
            }
            otherSolutionsLabel.Text = otherSolutionsText;
        }

        private void useBrutForce_Click(object sender, EventArgs e)
        {
            if (this.task == null)
            {
                MessageBox.Show("Select file with Task info, please", "No Task Info", MessageBoxButtons.OK);
                return;
            }
            BruteForce bruteForce = new BruteForce();
            Solution solution = bruteForce.getSolution(this.task);
            bruteForceText.Text = solution.getPrint();
            timeBruteForceText.Text = MainAlgorithm.getTime(bruteForce.time);
        }

        private void tryToFindMoreSolutions_CheckedChanged(object sender, EventArgs e)
        {
            MainAlgorithm.runBinarySearch = this.tryToFindMoreSolutions.Checked;
            if (this.tryToFindMoreSolutions.Checked && MainAlgorithm.globalMin != -1)
            {
                DialogResult result = MessageBox.Show("Need to try to find solutions for less value of directive faults?", "Binary Search", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int bestSolutionIndex = 0;
                    int anotherSolutionIndex = MainAlgorithm.binarySearch(task);
                    if (anotherSolutionIndex != -1)
                    {
                        bestSolutionIndex = anotherSolutionIndex;
                    }
                    showResults(bestSolutionIndex);
                }
            }
        }

        private void showResults(int bestSolutionIndex)
        {
            solutionText.Text = MainAlgorithm.allSolutions[bestSolutionIndex].getPrint();

            if (MainAlgorithm.allSolutions.Count == 1 && this.tryToFindMoreSolutions.Checked)
            {
                otherSolutionsLabel.Text = "No other solutions with lower value of directive faults was found";
            }
            else
            {
                String otherSolutionsText = "";
                for (int i = 0; i < MainAlgorithm.allSolutions.Count; i++)
                {
                    if (i != bestSolutionIndex)
                    {
                        otherSolutionsText += i + ". " + MainAlgorithm.allSolutions[i].getShortPrint();
                    }
                }
                otherSolutionsLabel.Text = otherSolutionsText;
            }
            this.timeMVGText.Text = MainAlgorithm.getTime(MainAlgorithm.timeMVG);
            if (tryToFindMoreSolutions.Checked)
                this.timeBinaryText.Text = MainAlgorithm.getTime(MainAlgorithm.timeBinary);
        }
    }
}
