namespace TitleAnalyzer.Client
{
    partial class MainForm
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
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.listBoxSimilarities = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Location = new System.Drawing.Point(15, 282);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(516, 48);
            this.buttonAnalyze.TabIndex = 0;
            this.buttonAnalyze.Text = "Click to analyze data";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // listBoxSimilarities
            // 
            this.listBoxSimilarities.FormattingEnabled = true;
            this.listBoxSimilarities.Location = new System.Drawing.Point(15, 41);
            this.listBoxSimilarities.Name = "listBoxSimilarities";
            this.listBoxSimilarities.Size = new System.Drawing.Size(516, 225);
            this.listBoxSimilarities.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "The most similar image titles (shown by pairs):";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 346);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxSimilarities);
            this.Controls.Add(this.buttonAnalyze);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title Analyzer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.ListBox listBoxSimilarities;
        private System.Windows.Forms.Label label1;
    }
}

