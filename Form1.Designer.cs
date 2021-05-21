namespace Incassator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectFileTitle = new System.Windows.Forms.Label();
            this.selectFileTextBox = new System.Windows.Forms.TextBox();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.matrixTitle = new System.Windows.Forms.Label();
            this.matrixTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.profitTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.matrixCorePanel = new System.Windows.Forms.Panel();
            this.profitTitle = new System.Windows.Forms.Label();
            this.profitCorePanel = new System.Windows.Forms.Panel();
            this.directiveTitle = new System.Windows.Forms.Label();
            this.directiveCorePanel = new System.Windows.Forms.Panel();
            this.directiveTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.getSolutionButton = new System.Windows.Forms.Button();
            this.solutionTitle = new System.Windows.Forms.Label();
            this.solutionCorePanel = new System.Windows.Forms.Panel();
            this.solutionText = new System.Windows.Forms.Label();
            this.otherSolutionsTitle = new System.Windows.Forms.Label();
            this.otherSolutionsCorePanel = new System.Windows.Forms.Panel();
            this.otherSolutionsLabel = new System.Windows.Forms.Label();
            this.showFullTitle = new System.Windows.Forms.Label();
            this.showFullTextBox = new System.Windows.Forms.TextBox();
            this.showFullButton = new System.Windows.Forms.Button();
            this.useBrutForce = new System.Windows.Forms.Button();
            this.bruteForceTitle = new System.Windows.Forms.Label();
            this.bruteForceCorePanel = new System.Windows.Forms.Panel();
            this.bruteForceText = new System.Windows.Forms.Label();
            this.tryToFindMoreSolutions = new System.Windows.Forms.CheckBox();
            this.timeMVG = new System.Windows.Forms.Label();
            this.timeBinary = new System.Windows.Forms.Label();
            this.timeBruteForce = new System.Windows.Forms.Label();
            this.timeMVGText = new System.Windows.Forms.Label();
            this.timeBinaryText = new System.Windows.Forms.Label();
            this.timeBruteForceText = new System.Windows.Forms.Label();
            this.solutionCorePanel.SuspendLayout();
            this.otherSolutionsCorePanel.SuspendLayout();
            this.bruteForceCorePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectFileTitle
            // 
            this.selectFileTitle.AutoSize = true;
            this.selectFileTitle.Location = new System.Drawing.Point(13, 13);
            this.selectFileTitle.Name = "selectFileTitle";
            this.selectFileTitle.Size = new System.Drawing.Size(159, 17);
            this.selectFileTitle.TabIndex = 0;
            this.selectFileTitle.Text = "Select file with task data";
            // 
            // selectFileTextBox
            // 
            this.selectFileTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.selectFileTextBox.Location = new System.Drawing.Point(16, 34);
            this.selectFileTextBox.Name = "selectFileTextBox";
            this.selectFileTextBox.Size = new System.Drawing.Size(207, 22);
            this.selectFileTextBox.TabIndex = 1;
            this.selectFileTextBox.Text = "Select file...";
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(230, 32);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(75, 28);
            this.selectFileButton.TabIndex = 2;
            this.selectFileButton.Text = "Browse";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // matrixTitle
            // 
            this.matrixTitle.AutoSize = true;
            this.matrixTitle.Location = new System.Drawing.Point(13, 69);
            this.matrixTitle.Name = "matrixTitle";
            this.matrixTitle.Size = new System.Drawing.Size(45, 17);
            this.matrixTitle.TabIndex = 3;
            this.matrixTitle.Text = "Matrix";
            // 
            // matrixTablePanel
            // 
            this.matrixTablePanel.AutoSize = true;
            this.matrixTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.matrixTablePanel.ColumnCount = 1;
            this.matrixTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.matrixTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.matrixTablePanel.Location = new System.Drawing.Point(0, 0);
            this.matrixTablePanel.Name = "matrixTablePanel";
            this.matrixTablePanel.RowCount = 1;
            this.matrixTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.matrixTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.matrixTablePanel.Size = new System.Drawing.Size(200, 100);
            this.matrixTablePanel.TabIndex = 4;
            this.matrixTablePanel.Visible = false;
            // 
            // profitTablePanel
            // 
            this.profitTablePanel.AutoSize = true;
            this.profitTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.profitTablePanel.ColumnCount = 1;
            this.profitTablePanel.Location = new System.Drawing.Point(0, 0);
            this.profitTablePanel.Name = "profitTablePanel";
            this.profitTablePanel.RowCount = 2;
            this.profitTablePanel.Size = new System.Drawing.Size(5, 5);
            this.profitTablePanel.TabIndex = 8;
            this.profitTablePanel.Visible = false;
            // 
            // matrixCorePanel
            // 
            this.matrixCorePanel.AutoScroll = true;
            this.matrixCorePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matrixCorePanel.Location = new System.Drawing.Point(16, 90);
            this.matrixCorePanel.MaximumSize = new System.Drawing.Size(316, 235);
            this.matrixCorePanel.Name = "matrixCorePanel";
            this.matrixCorePanel.Size = new System.Drawing.Size(316, 235);
            this.matrixCorePanel.TabIndex = 5;
            // 
            // profitTitle
            // 
            this.profitTitle.AutoSize = true;
            this.profitTitle.Location = new System.Drawing.Point(16, 332);
            this.profitTitle.Name = "profitTitle";
            this.profitTitle.Size = new System.Drawing.Size(103, 17);
            this.profitTitle.TabIndex = 6;
            this.profitTitle.Text = "Profit on vertex";
            // 
            // profitCorePanel
            // 
            this.profitCorePanel.AutoScroll = true;
            this.profitCorePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profitCorePanel.Location = new System.Drawing.Point(16, 353);
            this.profitCorePanel.Name = "profitCorePanel";
            this.profitCorePanel.Size = new System.Drawing.Size(316, 65);
            this.profitCorePanel.TabIndex = 7;
            // 
            // directiveTitle
            // 
            this.directiveTitle.AutoSize = true;
            this.directiveTitle.Location = new System.Drawing.Point(16, 425);
            this.directiveTitle.Name = "directiveTitle";
            this.directiveTitle.Size = new System.Drawing.Size(105, 17);
            this.directiveTitle.TabIndex = 8;
            this.directiveTitle.Text = "Directive Times";
            // 
            // directiveCorePanel
            // 
            this.directiveCorePanel.AutoScroll = true;
            this.directiveCorePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.directiveCorePanel.Location = new System.Drawing.Point(16, 446);
            this.directiveCorePanel.Name = "directiveCorePanel";
            this.directiveCorePanel.Size = new System.Drawing.Size(316, 65);
            this.directiveCorePanel.TabIndex = 9;
            // 
            // directiveTablePanel
            // 
            this.directiveTablePanel.AutoSize = true;
            this.directiveTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.directiveTablePanel.ColumnCount = 1;
            this.directiveTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.directiveTablePanel.Location = new System.Drawing.Point(0, 0);
            this.directiveTablePanel.Name = "directiveTablePanel";
            this.directiveTablePanel.RowCount = 2;
            this.directiveTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.directiveTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.directiveTablePanel.Size = new System.Drawing.Size(50, 49);
            this.directiveTablePanel.TabIndex = 10;
            this.directiveTablePanel.Visible = false;
            // 
            // getSolutionButton
            // 
            this.getSolutionButton.Location = new System.Drawing.Point(411, 22);
            this.getSolutionButton.Name = "getSolutionButton";
            this.getSolutionButton.Size = new System.Drawing.Size(143, 38);
            this.getSolutionButton.TabIndex = 11;
            this.getSolutionButton.Text = "Get Solution";
            this.getSolutionButton.UseVisualStyleBackColor = true;
            this.getSolutionButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // solutionTitle
            // 
            this.solutionTitle.AutoSize = true;
            this.solutionTitle.Location = new System.Drawing.Point(408, 69);
            this.solutionTitle.Name = "solutionTitle";
            this.solutionTitle.Size = new System.Drawing.Size(59, 17);
            this.solutionTitle.TabIndex = 12;
            this.solutionTitle.Text = "Solution";
            // 
            // solutionCorePanel
            // 
            this.solutionCorePanel.AutoScroll = true;
            this.solutionCorePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.solutionCorePanel.Controls.Add(this.solutionText);
            this.solutionCorePanel.Location = new System.Drawing.Point(411, 90);
            this.solutionCorePanel.Name = "solutionCorePanel";
            this.solutionCorePanel.Size = new System.Drawing.Size(329, 235);
            this.solutionCorePanel.TabIndex = 13;
            // 
            // solutionText
            // 
            this.solutionText.AutoSize = true;
            this.solutionText.Location = new System.Drawing.Point(0, 0);
            this.solutionText.Name = "solutionText";
            this.solutionText.Size = new System.Drawing.Size(0, 17);
            this.solutionText.TabIndex = 0;
            // 
            // otherSolutionsTitle
            // 
            this.otherSolutionsTitle.AutoSize = true;
            this.otherSolutionsTitle.Location = new System.Drawing.Point(411, 331);
            this.otherSolutionsTitle.Name = "otherSolutionsTitle";
            this.otherSolutionsTitle.Size = new System.Drawing.Size(322, 17);
            this.otherSolutionsTitle.TabIndex = 14;
            this.otherSolutionsTitle.Text = "Other solutions with lower value of directive faults:";
            // 
            // otherSolutionsCorePanel
            // 
            this.otherSolutionsCorePanel.AutoScroll = true;
            this.otherSolutionsCorePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.otherSolutionsCorePanel.Controls.Add(this.otherSolutionsLabel);
            this.otherSolutionsCorePanel.Location = new System.Drawing.Point(414, 353);
            this.otherSolutionsCorePanel.Name = "otherSolutionsCorePanel";
            this.otherSolutionsCorePanel.Size = new System.Drawing.Size(326, 89);
            this.otherSolutionsCorePanel.TabIndex = 15;
            // 
            // otherSolutionsLabel
            // 
            this.otherSolutionsLabel.AutoSize = true;
            this.otherSolutionsLabel.Location = new System.Drawing.Point(0, 0);
            this.otherSolutionsLabel.Name = "otherSolutionsLabel";
            this.otherSolutionsLabel.Size = new System.Drawing.Size(0, 17);
            this.otherSolutionsLabel.TabIndex = 0;
            // 
            // showFullTitle
            // 
            this.showFullTitle.AutoSize = true;
            this.showFullTitle.Location = new System.Drawing.Point(414, 449);
            this.showFullTitle.Name = "showFullTitle";
            this.showFullTitle.Size = new System.Drawing.Size(267, 17);
            this.showFullTitle.TabIndex = 16;
            this.showFullTitle.Text = "Show full version of solution with number:";
            // 
            // showFullTextBox
            // 
            this.showFullTextBox.Location = new System.Drawing.Point(417, 470);
            this.showFullTextBox.Name = "showFullTextBox";
            this.showFullTextBox.Size = new System.Drawing.Size(50, 22);
            this.showFullTextBox.TabIndex = 17;
            // 
            // showFullButton
            // 
            this.showFullButton.Location = new System.Drawing.Point(497, 470);
            this.showFullButton.Name = "showFullButton";
            this.showFullButton.Size = new System.Drawing.Size(75, 23);
            this.showFullButton.TabIndex = 18;
            this.showFullButton.Text = "Show";
            this.showFullButton.UseVisualStyleBackColor = true;
            this.showFullButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // useBrutForce
            // 
            this.useBrutForce.Location = new System.Drawing.Point(784, 22);
            this.useBrutForce.Name = "useBrutForce";
            this.useBrutForce.Size = new System.Drawing.Size(153, 37);
            this.useBrutForce.TabIndex = 19;
            this.useBrutForce.Text = "Use Brute Force";
            this.useBrutForce.UseVisualStyleBackColor = true;
            this.useBrutForce.Click += new System.EventHandler(this.useBrutForce_Click);
            // 
            // bruteForceTitle
            // 
            this.bruteForceTitle.AutoSize = true;
            this.bruteForceTitle.Location = new System.Drawing.Point(781, 69);
            this.bruteForceTitle.Name = "bruteForceTitle";
            this.bruteForceTitle.Size = new System.Drawing.Size(135, 17);
            this.bruteForceTitle.TabIndex = 20;
            this.bruteForceTitle.Text = "Brute Force solution";
            // 
            // bruteForceCorePanel
            // 
            this.bruteForceCorePanel.AutoScroll = true;
            this.bruteForceCorePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bruteForceCorePanel.Controls.Add(this.bruteForceText);
            this.bruteForceCorePanel.Location = new System.Drawing.Point(784, 90);
            this.bruteForceCorePanel.Name = "bruteForceCorePanel";
            this.bruteForceCorePanel.Size = new System.Drawing.Size(336, 352);
            this.bruteForceCorePanel.TabIndex = 21;
            // 
            // bruteForceText
            // 
            this.bruteForceText.AutoSize = true;
            this.bruteForceText.Location = new System.Drawing.Point(0, 0);
            this.bruteForceText.Name = "bruteForceText";
            this.bruteForceText.Size = new System.Drawing.Size(0, 17);
            this.bruteForceText.TabIndex = 0;
            // 
            // tryToFindMoreSolutions
            // 
            this.tryToFindMoreSolutions.AutoSize = true;
            this.tryToFindMoreSolutions.Checked = true;
            this.tryToFindMoreSolutions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tryToFindMoreSolutions.Location = new System.Drawing.Point(583, 39);
            this.tryToFindMoreSolutions.Name = "tryToFindMoreSolutions";
            this.tryToFindMoreSolutions.Size = new System.Drawing.Size(119, 21);
            this.tryToFindMoreSolutions.TabIndex = 22;
            this.tryToFindMoreSolutions.Text = "Binary Search";
            this.tryToFindMoreSolutions.UseVisualStyleBackColor = true;
            this.tryToFindMoreSolutions.CheckedChanged += new System.EventHandler(this.tryToFindMoreSolutions_CheckedChanged);
            // 
            // timeMVG
            // 
            this.timeMVG.AutoSize = true;
            this.timeMVG.Location = new System.Drawing.Point(784, 450);
            this.timeMVG.Name = "timeMVG";
            this.timeMVG.Size = new System.Drawing.Size(108, 17);
            this.timeMVG.TabIndex = 23;
            this.timeMVG.Text = "time base MVG:";
            // 
            // timeBinary
            // 
            this.timeBinary.AutoSize = true;
            this.timeBinary.Location = new System.Drawing.Point(784, 475);
            this.timeBinary.Name = "timeBinary";
            this.timeBinary.Size = new System.Drawing.Size(131, 17);
            this.timeBinary.TabIndex = 24;
            this.timeBinary.Text = "time Binary Search:";
            // 
            // timeBruteForce
            // 
            this.timeBruteForce.AutoSize = true;
            this.timeBruteForce.Location = new System.Drawing.Point(784, 500);
            this.timeBruteForce.Name = "timeBruteForce";
            this.timeBruteForce.Size = new System.Drawing.Size(112, 17);
            this.timeBruteForce.TabIndex = 25;
            this.timeBruteForce.Text = "time Brute Force";
            // 
            // timeMVGText
            // 
            this.timeMVGText.AutoSize = true;
            this.timeMVGText.Location = new System.Drawing.Point(898, 450);
            this.timeMVGText.Name = "timeMVGText";
            this.timeMVGText.Size = new System.Drawing.Size(46, 17);
            this.timeMVGText.TabIndex = 26;
            this.timeMVGText.Text = "";
            // 
            // timeBinaryText
            // 
            this.timeBinaryText.AutoSize = true;
            this.timeBinaryText.Location = new System.Drawing.Point(921, 475);
            this.timeBinaryText.Name = "timeBinaryText";
            this.timeBinaryText.Size = new System.Drawing.Size(46, 17);
            this.timeBinaryText.TabIndex = 27;
            this.timeBinaryText.Text = "";
            // 
            // timeBruteForceText
            // 
            this.timeBruteForceText.AutoSize = true;
            this.timeBruteForceText.Location = new System.Drawing.Point(903, 500);
            this.timeBruteForceText.Name = "timeBruteForceText";
            this.timeBruteForceText.Size = new System.Drawing.Size(46, 17);
            this.timeBruteForceText.TabIndex = 28;
            this.timeBruteForceText.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 533);
            this.Controls.Add(this.timeBruteForceText);
            this.Controls.Add(this.timeBinaryText);
            this.Controls.Add(this.timeMVGText);
            this.Controls.Add(this.timeBruteForce);
            this.Controls.Add(this.timeBinary);
            this.Controls.Add(this.timeMVG);
            this.Controls.Add(this.tryToFindMoreSolutions);
            this.Controls.Add(this.bruteForceCorePanel);
            this.Controls.Add(this.bruteForceTitle);
            this.Controls.Add(this.useBrutForce);
            this.Controls.Add(this.showFullButton);
            this.Controls.Add(this.showFullTextBox);
            this.Controls.Add(this.showFullTitle);
            this.Controls.Add(this.otherSolutionsCorePanel);
            this.Controls.Add(this.otherSolutionsTitle);
            this.Controls.Add(this.solutionCorePanel);
            this.Controls.Add(this.solutionTitle);
            this.Controls.Add(this.getSolutionButton);
            this.Controls.Add(this.directiveTablePanel);
            this.Controls.Add(this.directiveCorePanel);
            this.Controls.Add(this.directiveTitle);
            this.Controls.Add(this.profitCorePanel);
            this.Controls.Add(this.profitTitle);
            this.Controls.Add(this.matrixTablePanel);
            this.Controls.Add(this.matrixCorePanel);
            this.Controls.Add(this.matrixTitle);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.selectFileTextBox);
            this.Controls.Add(this.selectFileTitle);
            this.Name = "Form1";
            this.Text = "Delivery";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.solutionCorePanel.ResumeLayout(false);
            this.solutionCorePanel.PerformLayout();
            this.otherSolutionsCorePanel.ResumeLayout(false);
            this.otherSolutionsCorePanel.PerformLayout();
            this.bruteForceCorePanel.ResumeLayout(false);
            this.bruteForceCorePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectFileTitle;
        private System.Windows.Forms.TextBox selectFileTextBox;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Label matrixTitle;
        private System.Windows.Forms.TableLayoutPanel matrixTablePanel;
        private System.Windows.Forms.Panel matrixCorePanel;
        private System.Windows.Forms.Label profitTitle;
        private System.Windows.Forms.Panel profitCorePanel;
        private System.Windows.Forms.TableLayoutPanel profitTablePanel;
        private System.Windows.Forms.Label directiveTitle;
        private System.Windows.Forms.Panel directiveCorePanel;
        private System.Windows.Forms.TableLayoutPanel directiveTablePanel;
        private System.Windows.Forms.Button getSolutionButton;
        private System.Windows.Forms.Label solutionTitle;
        private System.Windows.Forms.Panel solutionCorePanel;
        private System.Windows.Forms.Label solutionText;
        private System.Windows.Forms.Label otherSolutionsTitle;
        private System.Windows.Forms.Panel otherSolutionsCorePanel;
        private System.Windows.Forms.Label otherSolutionsLabel;
        private System.Windows.Forms.Label showFullTitle;
        private System.Windows.Forms.TextBox showFullTextBox;
        private System.Windows.Forms.Button showFullButton;
        private System.Windows.Forms.Button useBrutForce;
        private System.Windows.Forms.Label bruteForceTitle;
        private System.Windows.Forms.Panel bruteForceCorePanel;
        private System.Windows.Forms.Label bruteForceText;
        private System.Windows.Forms.CheckBox tryToFindMoreSolutions;
        private System.Windows.Forms.Label timeMVG;
        private System.Windows.Forms.Label timeBinary;
        private System.Windows.Forms.Label timeBruteForce;
        private System.Windows.Forms.Label timeMVGText;
        private System.Windows.Forms.Label timeBinaryText;
        private System.Windows.Forms.Label timeBruteForceText;
    }
}

