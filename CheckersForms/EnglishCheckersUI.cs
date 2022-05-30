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
            m_FormGame = new FormGame(m_GameManger);
            m_FormGame.MoveChosen += new Action<Coordinate, Coordinate>(this.FormGame_MoveChosen);
            m_FormGame.ShowDialog();
        }

        private void FormGame_MoveChosen(Coordinate i_Source, Coordinate i_Destination)
        {
            eGameStatus gameStatusAfterMove = m_GameManger.InitiateMove(i_Source, i_Destination);

            handleStatus(gameStatusAfterMove);

        }

        private void handleStatus(eGameStatus i_GameStatus)
        {
            if (i_GameStatus == eGameStatus.InvalidMove)
            {
                ///message and handle
            }
            else
            {
                ///visual change when valid move
            }
            
            if (i_GameStatus == eGameStatus.ActivePlayerWins)
            {
                ///message and handle
            }
            else if (i_GameStatus == eGameStatus.Tie)
            {
                ///message and handle
            }

            if (!m_GameManger.ActivePlayer.IsHumanPlayer)
            {
                Coordinate source;
                Coordinate destination;
                i_GameStatus = m_GameManger.InitiateComputerMove(out source, out destination);
                ///send this change to the form ??
            }
        }
    }
}
