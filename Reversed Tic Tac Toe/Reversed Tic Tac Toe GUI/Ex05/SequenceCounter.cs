using System;

namespace ReverseTicTacToe
{
    public struct SequenceCounter
    {
        private int m_CounterX;
        private int m_CounterO;

        public int CounterX
        {
            get
            {
                return m_CounterX;
            }

            set
            {
                m_CounterX = value;
            }
        }

        public int CounterO
        {
            get
            {
                return m_CounterO;
            }

            set
            {
                m_CounterO = value;
            }
        }
    } 
}
