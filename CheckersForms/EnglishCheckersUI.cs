using EnglishCheckers;
using System;
using System.Windows.Forms;
namespace EnglishCheckersUI
{
    public class EnglishCheckersUI
    {
        private FormGame m_FormGame;
        private readonly FormGameSettings r_FormGameSettings = new FormGameSettings();
        private GameManager m_GameManger;
        private readonly Timer r_Timer = new Timer();

        public EnglishCheckersUI()
        {
            r_Timer.Interval = 1000;
            r_Timer.Tick += new EventHandler(m_Timer_Tick);
        }

        public void SetGame()
        {
            r_FormGameSettings.ShowDialog();
            if (r_FormGameSettings.DialogResult == DialogResult.OK)
            {
                runGame();
            }
        }

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            r_Timer.Stop();
            m_GameManger.InitiateComputerMove();
            handleComputerMove();
            m_FormGame.ChangeEnableToAll(true);
        }

        private void runGame()
        {
            m_GameManger = new GameManager(r_FormGameSettings.BoardSize, r_FormGameSettings.IsTwoPlayerMode,
                                           r_FormGameSettings.Player1Name, r_FormGameSettings.Player2Name);
            m_FormGame = new FormGame(m_GameManger);
            m_FormGame.MoveChosen += new Action<Coordinate, Coordinate>(this.FormGame_MoveChosen);
            m_GameManger.GameIsOver += new Action<eGameStatus>(this.GameManager_GameIsOver);
            m_GameManger.InvalidMoveAttempted += new Action(this.GameManager_InvalidMoveAttempted);
            m_GameManger.MoveMade += new Action<Move>(this.GameManager_MoveMade);
            m_FormGame.ShowDialog();
        }

        private void FormGame_MoveChosen(Coordinate i_Source, Coordinate i_Destination)
        {
            m_GameManger.InitiateMove(i_Source, i_Destination);
            handleComputerMove();
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
            string winnerName = null;
            string message = null;

            if(i_Status != eGameStatus.Tie)
            {
                winnerName = getWinnerName(i_Status);
                message = winnerName + " wins!";
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
            int player1Points = m_GameManger.NextPlayer.CoinType == eCoinType.Player1Coin ? m_GameManger.NextPlayer.Points : m_GameManger.ActivePlayer.Points;
            int player2Points = m_GameManger.NextPlayer.CoinType == eCoinType.Player2Coin ? m_GameManger.NextPlayer.Points : m_GameManger.ActivePlayer.Points;

            m_FormGame.UpdatePointsByGame(player1Points, player2Points);
        }

        private string getWinnerName(eGameStatus i_Status)
        {
            string winnerName = null;

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
        
        private void handleComputerMove()
        {
            if (!m_GameManger.ActivePlayer.IsHumanPlayer)
            {
                r_Timer.Start();
                m_FormGame.ChangeEnableToAll(false);
            }
        }
    }
}
