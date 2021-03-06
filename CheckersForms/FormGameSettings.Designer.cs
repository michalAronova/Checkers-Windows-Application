
namespace EnglishCheckersUI
{
    partial class FormGameSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameSettings));
            this.radioButtonSize6 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize8 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize10 = new System.Windows.Forms.RadioButton();
            this.groupBoxSizeChoice = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.groupBoxSizeChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonSize6
            // 
            this.radioButtonSize6.AutoSize = true;
            this.radioButtonSize6.Checked = true;
            this.radioButtonSize6.Location = new System.Drawing.Point(6, 25);
            this.radioButtonSize6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSize6.Name = "radioButtonSize6";
            this.radioButtonSize6.Size = new System.Drawing.Size(67, 24);
            this.radioButtonSize6.TabIndex = 0;
            this.radioButtonSize6.TabStop = true;
            this.radioButtonSize6.Tag = "6";
            this.radioButtonSize6.Text = "6 x 6";
            this.radioButtonSize6.UseVisualStyleBackColor = true;
            this.radioButtonSize6.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonSize8
            // 
            this.radioButtonSize8.AutoSize = true;
            this.radioButtonSize8.Location = new System.Drawing.Point(79, 25);
            this.radioButtonSize8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSize8.Name = "radioButtonSize8";
            this.radioButtonSize8.Size = new System.Drawing.Size(67, 24);
            this.radioButtonSize8.TabIndex = 1;
            this.radioButtonSize8.Tag = "8";
            this.radioButtonSize8.Text = "8 x 8";
            this.radioButtonSize8.UseVisualStyleBackColor = true;
            this.radioButtonSize8.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonSize10
            // 
            this.radioButtonSize10.AutoSize = true;
            this.radioButtonSize10.Location = new System.Drawing.Point(152, 25);
            this.radioButtonSize10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSize10.Name = "radioButtonSize10";
            this.radioButtonSize10.Size = new System.Drawing.Size(85, 24);
            this.radioButtonSize10.TabIndex = 2;
            this.radioButtonSize10.Tag = "10";
            this.radioButtonSize10.Text = "10 x 10";
            this.radioButtonSize10.UseVisualStyleBackColor = true;
            this.radioButtonSize10.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBoxSizeChoice
            // 
            this.groupBoxSizeChoice.Controls.Add(this.radioButtonSize6);
            this.groupBoxSizeChoice.Controls.Add(this.radioButtonSize10);
            this.groupBoxSizeChoice.Controls.Add(this.radioButtonSize8);
            this.groupBoxSizeChoice.Location = new System.Drawing.Point(36, 28);
            this.groupBoxSizeChoice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxSizeChoice.Name = "groupBoxSizeChoice";
            this.groupBoxSizeChoice.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxSizeChoice.Size = new System.Drawing.Size(240, 55);
            this.groupBoxSizeChoice.TabIndex = 3;
            this.groupBoxSizeChoice.TabStop = false;
            this.groupBoxSizeChoice.Text = "Choose Board Size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Player 1:";
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(36, 178);
            this.checkBoxPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(95, 24);
            this.checkBoxPlayer2.TabIndex = 1;
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // textBoxPlayer1Name
            // 
            this.textBoxPlayer1Name.Location = new System.Drawing.Point(134, 136);
            this.textBoxPlayer1Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPlayer1Name.Name = "textBoxPlayer1Name";
            this.textBoxPlayer1Name.Size = new System.Drawing.Size(210, 26);
            this.textBoxPlayer1Name.TabIndex = 0;
            this.textBoxPlayer1Name.TextChanged += new System.EventHandler(this.textBoxPlayerName_TextChanged);
            // 
            // textBoxPlayer2Name
            // 
            this.textBoxPlayer2Name.Enabled = false;
            this.textBoxPlayer2Name.Location = new System.Drawing.Point(134, 175);
            this.textBoxPlayer2Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPlayer2Name.Name = "textBoxPlayer2Name";
            this.textBoxPlayer2Name.Size = new System.Drawing.Size(210, 26);
            this.textBoxPlayer2Name.TabIndex = 2;
            this.textBoxPlayer2Name.Text = "[Computer]";
            this.textBoxPlayer2Name.TextChanged += new System.EventHandler(this.textBoxPlayerName_TextChanged);
            // 
            // buttonDone
            // 
            this.buttonDone.Enabled = false;
            this.buttonDone.Location = new System.Drawing.Point(269, 226);
            this.buttonDone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 31);
            this.buttonDone.TabIndex = 3;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // FormGameSettings
            // 
            this.AcceptButton = this.buttonDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 275);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.textBoxPlayer2Name);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxSizeChoice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormGameSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.groupBoxSizeChoice.ResumeLayout(false);
            this.groupBoxSizeChoice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonSize6;
        private System.Windows.Forms.RadioButton radioButtonSize8;
        private System.Windows.Forms.RadioButton radioButtonSize10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer1Name;
        private System.Windows.Forms.TextBox textBoxPlayer2Name;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.GroupBox groupBoxSizeChoice;
    }
}