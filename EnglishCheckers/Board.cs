using System.Collections.Generic;

namespace EnglishCheckers
{
    public class Board
    {
        private Square[,] m_GameBoard;
        private int m_BoardSize;

        public Board(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            m_GameBoard = new Square[m_BoardSize, m_BoardSize];
            SetInitialBoard();
        }

        public void SetInitialBoard()
        {
            int numberOfInitialPlayerRows = (m_BoardSize / 2 - 1);

            for(int i = 0; i < m_BoardSize; i++)
            {
                if(i < numberOfInitialPlayerRows)
                {
                    setupRow(i, eCoinType.Player2Coin);
                }
                else if(i >= m_BoardSize - numberOfInitialPlayerRows)
                {
                    setupRow(i, eCoinType.Player1Coin);
                }
                else
                {
                    setRowCoordinates(i);
                }
            }
        }

        private void setupRow(int i_Row, eCoinType i_CoinType)
        {
            setRowCoordinates(i_Row);
            for(int i = 0; i < m_BoardSize; i++)
            {
                if(isACoinInitialSpot(i_Row, i))
                {
                    m_GameBoard[i_Row, i].Coin = new Coin(i_CoinType);
                }
            }
        }

        private void setRowCoordinates(int i_Row)
        {
            for(int i = 0; i < m_BoardSize; i++)
            {
                m_GameBoard[i_Row, i] = new Square();
                m_GameBoard[i_Row, i].Coordinate = new Coordinate(i_Row, i);
            }
        }

        private bool isACoinInitialSpot(int i_Row, int i_Column)
        {
            return (i_Row + i_Column) % 2 != 0;
        }

        public int Size
        {
            get
            {
                return m_BoardSize;
            }
        }

        public void GetCoordinateToCoinDictionaries(out Dictionary<Coordinate,Coin> o_Player1Coins, out Dictionary<Coordinate, Coin> o_Player2Coins)
        {
            o_Player1Coins = new Dictionary<Coordinate, Coin>();
            o_Player2Coins = new Dictionary<Coordinate, Coin>();
            foreach (Square square in m_GameBoard)
            {
                if(square.Coin != null)
                {
                    if(square.Coin.Type == eCoinType.Player1Coin)
                    {
                        o_Player1Coins.Add(square.Coordinate,square.Coin);
                    }
                    else
                    {
                        o_Player2Coins.Add(square.Coordinate,square.Coin);
                    }
                }
            }
        }

        public Square GetSquare(Coordinate i_Coordinate)
        {
            return m_GameBoard[i_Coordinate.Row, i_Coordinate.Column];
        }

        public void MoveCoin(Coordinate i_SourceCoordinate, Coordinate i_DestinationCoordinate)
        {
            Coin movingCoin = GetSquare(i_SourceCoordinate).Coin;

            SetSquare(i_DestinationCoordinate, movingCoin);
            SetSquare(i_SourceCoordinate, null);
        }

        public void RemoveCoin(Coordinate i_CoinCoordinate)
        {
            SetSquare(i_CoinCoordinate, null);
        }

        public List<Coordinate> GetDiagonalInDirection(Coordinate i_Coordinate, eDirection i_Direction)
        {
            List<Coordinate> diagonalCoordinates = new List<Coordinate>();
            int nextRow = (i_Direction == eDirection.Down) ? i_Coordinate.Row + 1 : i_Coordinate.Row - 1;

            if(nextRow >= 0 && nextRow < m_BoardSize)
            {
                if (i_Coordinate.Column - 1 >= 0)
                {
                    diagonalCoordinates.Add(new Coordinate(nextRow, i_Coordinate.Column - 1));
                }

                if (i_Coordinate.Column + 1 < m_BoardSize)
                {
                    diagonalCoordinates.Add(new Coordinate(nextRow, i_Coordinate.Column + 1));
                }
            }

            return diagonalCoordinates;
        }

        public bool checkIfLeftMove(Coordinate i_SourceCoordinate, Coordinate i_DestinationCoordinate)
        {
            return i_SourceCoordinate.Column - 1 == i_DestinationCoordinate.Column;
        }

        public void SetSquare(Coordinate i_Coordinate, Coin i_Coin)
        {
            m_GameBoard[i_Coordinate.Row, i_Coordinate.Column].Coin = i_Coin;
        }
    }
}