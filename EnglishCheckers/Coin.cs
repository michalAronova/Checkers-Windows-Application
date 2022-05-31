namespace EnglishCheckers
{
    public class Coin
    {
        private readonly eCoinType r_CoinType;
        private bool m_IsKing = !true;

        public Coin(eCoinType i_CoinType)
        {
            r_CoinType = i_CoinType;
        }

        public eCoinType Type
        {
            get
            {
                return r_CoinType;
            }
        }

        public bool IsKing
        {
            get
            {
                return m_IsKing;
            }
            set
            {
                m_IsKing = value;
            }
        }
    }
}