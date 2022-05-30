using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnglishCheckers;
namespace CheckersForms
{
    public class EnglishCheckersUI
    {
        private FormGame m_FormGame;
        private readonly FormGameSettings m_FormGameSettings = new FormGameSettings();
        private GameManager m_GameManger;

        public void SetGame()
        {
            m_FormGameSettings.ShowDialog();
            if (m_FormGameSettings.DialogResult == DialogResult.OK)
            {
                runGame();
            }
        }

        private void runGame()
        {
            m_GameManger = new GameManager(m_FormGameSettings.BoardSize, m_FormGameSettings.IsTwoPlayerMode,
                                           m_FormGameSettings.Player1Name, m_FormGameSettings.Player2Name);

        }
    }
}
