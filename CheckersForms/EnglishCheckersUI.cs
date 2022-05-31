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
            m_GameManger.GameIsOver += new Action<eGameStatus>(this.GameManager_GameIsOver);
            m_GameManger.InvalidMoveAttempted += new Action(this.GameManager_InvalidMoveAttempted);
            m_GameManger.MoveMade += new Action<Move>(this.GameManager_MoveMade);
            m_FormGame.ShowDialog();
        }

        private void FormGame_MoveChosen(Coordinate i_Source, Coordinate i_Destination)
        {
            eGameStatus gameStatusAfterMove = m_GameManger.InitiateMove(i_Source, i_Destination);
            ///remember - handle computer move!
            ///handleStatus(gameStatusAfterMove);
        }

        private void GameManager_MoveMade(Move i_MoveMade)
        {
            m_FormGame.UpdateFormGameBoard(m_GameManger.GameBoard);
        }

        private void GameManager_InvalidMoveAttempted()
        {
            MessageBox.Show("Please Try Again...", "Invalid Move", MessageBoxButtons.OK);
        }

        private void GameManager_GameIsOver(eGameStatus i_Status)
        {
            string winnerName;
            string message;
            if(i_Status != eGameStatus.Tie)
            {
                winnerName = getWinnerName(i_Status);
                message = winnerName + "wins!";
            }
            else
            {
                message = "It's a Tie!";
            }
            message += Environment.NewLine + "Another round?";

            DialogResult dialogResult = MessageBox.Show(message, "Game Over!", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                m_GameManger.InitiateGame();
                m_FormGame.UpdateFormGameBoard(m_GameManger.GameBoard);
                updateFormGamePoints();
            }
            else if (dialogResult == DialogResult.No)
            {
                m_FormGame.Close();
            }
        }

        private void updateFormGamePoints()
        {
            m_FormGame.UpdatePointsByGame();
        }
        private string getWinnerName(eGameStatus i_Status)
        {
            string winnerName;
            if(i_Status == eGameStatus.ActivePlayerWins)
            {
                winnerName = m_GameManger.ActivePlayer.Name;
            }
            else
            {
                winnerName = m_GameManger.NextPlayer.Name;
            }

            return winnerName;
        }
        private void handleStatus(eGameStatus i_GameStatus)
        {
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
