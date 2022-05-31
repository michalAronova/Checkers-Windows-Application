using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnglishCheckers;

namespace CheckersForms
{
    public partial class FormGame : Form
    {
        private const char k_Player1Coin = 'X';
        private const char k_Player2Coin = 'O';
        private const char k_Player1King = 'K';
        private const char k_Player2King = 'U';
        private ButtonSquare[,] m_ButtonSquaresBoard;
        private readonly int r_BoardSize;
        private ButtonSquare m_buttonSquarePressed;

        public event Action<Coordinate, Coordinate> MoveChosen;

        public FormGame(GameManager i_GameManager)
        {
            InitializeComponent();
            r_BoardSize = i_GameManager.GameBoard.Size;
            initBoard(i_GameManager.GameBoard);
            this.ClientSize = calcClientSize();
            initNames(i_GameManager.ActivePlayer.Name, i_GameManager.NextPlayer.Name);
        }

        private void initNames(string i_Player1Name, string i_Player2Name)
        {
            this.labelPlayer1.Text = i_Player1Name;
            this.labelPlayer2.Text = i_Player2Name;
        }
        private Size calcClientSize()
        {
            int height = groupBox1.Height +  (m_ButtonSquaresBoard[0,0].Height * r_BoardSize);
            int width = m_ButtonSquaresBoard[0, 0].Width * r_BoardSize;
            return new Size(width + 6, height + 6);
        }

        private void initBoard(Board i_GameBoard)
        {
            m_ButtonSquaresBoard = new ButtonSquare[r_BoardSize, r_BoardSize];
            for(int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    m_ButtonSquaresBoard[i,j] = new ButtonSquare(new Coordinate(i, j));
                    m_ButtonSquaresBoard[i, j].CheckedChanged += new EventHandler(this.buttonSquare_CheckedChanged);
                    m_ButtonSquaresBoard[i, j].Left = this.Left + (j * m_ButtonSquaresBoard[i, j].Width) + 3;
                    m_ButtonSquaresBoard[i, j].Top = groupBox1.Bottom + (i * m_ButtonSquaresBoard[i, j].Height) + 3;
                    this.Controls.Add(m_ButtonSquaresBoard[i,j]);
                }
            }
            UpdateFormGameBoard(i_GameBoard);
        }

        public void UpdateFormGameBoard(Board i_GameBoard)
        {
            for(int i = 0; i < r_BoardSize; i++)
            {
                for(int j = 0; j < r_BoardSize; j++)
                {
                    Square currentSquare = i_GameBoard.GetSquare(new Coordinate(i, j));
                    if (currentSquare.Coin == null)
                    {
                        m_ButtonSquaresBoard[i, j].Text = String.Empty;
                        
                        if ((i + j) % 2 == 0)
                        {
                            m_ButtonSquaresBoard[i, j].Enabled = false;
                        }
                    }
                    else
                    {
                        if(currentSquare.Coin.IsKing)
                        {
                            m_ButtonSquaresBoard[i, j].Text = (currentSquare.Coin.Type == eCoinType.Player1Coin)
                                                                  ? k_Player1King.ToString()
                                                                  : k_Player2King.ToString();
                        }
                        else
                        {
                            m_ButtonSquaresBoard[i, j].Text = (currentSquare.Coin.Type == eCoinType.Player1Coin)
                                                                  ? k_Player1Coin.ToString()
                                                                  : k_Player2Coin.ToString();
                        }
                    }
                }
            }
        }

        private void buttonSquare_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as ButtonSquare).Checked)
            {
                (sender as ButtonSquare).BackColor = Color.SkyBlue;
            }
            else
            {
                (sender as ButtonSquare).BackColor = Color.White;
            }
            
            if (m_buttonSquarePressed == null)
            {
                m_buttonSquarePressed = sender as ButtonSquare;
            }
            else
            {
                if(m_buttonSquarePressed == sender)
                {
                    m_buttonSquarePressed = null;
                }
                else
                {
                    Coordinate source = m_buttonSquarePressed.Coordinate;
                    Coordinate destination = (sender as ButtonSquare).Coordinate;
                    OnMoveChosen(source, destination);
                    m_buttonSquarePressed.Checked = false;
                    (sender as ButtonSquare).Checked = false;
                    m_buttonSquarePressed = null;
                }
            }
        }

        public void UpdatePointsByGame(int i_Player1Points, int i_Player2Points)
        {
            labelPlayer1Score.Text = i_Player1Points.ToString();
            labelPlayer2Score.Text = i_Player2Points.ToString();
        }

        protected void OnMoveChosen(Coordinate i_Source, Coordinate i_Destination)
        {
            if(MoveChosen != null)
            {
                MoveChosen.Invoke(i_Source, i_Destination);
            }
        }
    }
}
