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
        private int m_SizeChosen;
        private string m_Player1Name;
        private string m_Player2Name = "Computer";
        private bool m_IsHumanOpponent = false;
        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            m_Player1Name = textBoxPlayer1Name.Text;
            if(checkBoxPlayer2.Checked)
            {
                m_Player2Name = textBoxPlayer2Name.Text;
                m_IsHumanOpponent = true;
            }
            this.Close();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButtonCheckedChanged = sender as RadioButton;

            if(radioButtonCheckedChanged.Checked)
            {
                m_SizeChosen = int.Parse(radioButtonCheckedChanged.Tag.ToString());
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

        private void textBoxPlayer1Name_TextChanged(object sender, EventArgs e)
        {
            buttonDone.Enabled = !string.IsNullOrEmpty(textBoxPlayer1Name.Text);
        }

        private void textBoxPlayer2Name_TextChanged(object sender, EventArgs e)
        {
            buttonDone.Enabled = !string.IsNullOrEmpty(textBoxPlayer2Name.Text);
        }

        private void textBoxPlayer1Name_KeyPress(object sender, KeyPressEventArgs e) //refactor
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
