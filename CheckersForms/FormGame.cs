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
        private ButtonSquare m_buttonSquarePressed;

        public event Action<Coordinate, Coordinate> MoveChosen;

        public FormGame(GameManager i_GameManager)
        {
            InitializeComponent();
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
            int height = groupBox1.Height +  (m_ButtonSquaresBoard[0,0].Height * m_ButtonSquaresBoard.GetLength(0));
            int width = m_ButtonSquaresBoard[0, 0].Width * m_ButtonSquaresBoard.GetLength(0);
            return new Size(width + 6, height + 6);
        }

        private void initBoard(Board i_GameBoard)
        {
            int boardSize = i_GameBoard.Size;
            m_ButtonSquaresBoard = new ButtonSquare[boardSize, boardSize];
            for(int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    m_ButtonSquaresBoard[i,j] = new ButtonSquare(new Coordinate(i, j));
                    Square currentSquare = i_GameBoard.GetSquare(new Coordinate(i, j));

                    if (currentSquare.Coin == null)
                    {
                        if((i + j) % 2 == 0)
                        {
                            m_ButtonSquaresBoard[i, j].Enabled = false;
                        }
                    }
                    else
                    {
                        m_ButtonSquaresBoard[i, j].Text = (currentSquare.Coin.Type == eCoinType.Player1Coin)
                                                        ? k_Player1Coin.ToString()
                                                        : k_Player2Coin.ToString();
                    }
                    m_ButtonSquaresBoard[i, j].CheckedChanged += new EventHandler(this.buttonSquare_CheckedChanged);
                    m_ButtonSquaresBoard[i, j].Left = this.Left + (j * m_ButtonSquaresBoard[i, j].Width) + 3;
                    m_ButtonSquaresBoard[i, j].Top = groupBox1.Bottom + (i * m_ButtonSquaresBoard[i, j].Height) + 3;
                    this.Controls.Add(m_ButtonSquaresBoard[i,j]);
                }
            }
        }

        private void buttonSquare_CheckedChanged(object sender, EventArgs e)
        {
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
                }
            }
        }

        private void OnMoveChosen(Coordinate i_Source, Coordinate i_Destination)
        {
            if(MoveChosen != null)
            {
                MoveChosen.Invoke(i_Source, i_Destination);
            }
        }
    }
}
