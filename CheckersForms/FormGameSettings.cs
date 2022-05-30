using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CheckersForms
{
    public partial class FormGameSettings : Form
    {
        public string Player1Name
        {
            get
            {
                return textBoxPlayer1Name.Text;
            }
        }

        public int BoardSize { get; private set; }

        public string Player2Name
        {
            get
            {
                return textBoxPlayer2Name.Text;
            }
        }

        public bool IsTwoPlayerMode
        {
            get
            {
                return checkBoxPlayer2.Checked;
            }
        }

        public FormGameSettings()
        {
            InitializeComponent();
            BoardSize = 6;
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButtonCheckedChanged = sender as RadioButton;

            if(radioButtonCheckedChanged.Checked)
            {
                BoardSize = int.Parse(radioButtonCheckedChanged.Tag.ToString());
            }
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as CheckBox).Checked)
            {
                textBoxPlayer2Name.Enabled = true;
                textBoxPlayer2Name.Text = null;
                buttonDone.Enabled = false;
            }
            else
            {
                textBoxPlayer2Name.Enabled = false;
                textBoxPlayer2Name.Text = "[Computer]";
            }
        }

        private void textBoxPlayerName_TextChanged(object sender, EventArgs e)
        {
            buttonDone.Enabled = !string.IsNullOrEmpty((sender as TextBox).Text);
        }
    }
}
