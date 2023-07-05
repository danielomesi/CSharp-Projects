using System;

namespace Ex02
{
    public class Player
    {
        // Data Members:
        private readonly string m_Nickname;
        private readonly char m_Symbol;
        private int m_NumOfVictories;

        public Player(string i_Nickname, char i_Symbol)
        {
            m_Nickname = i_Nickname;
            m_Symbol = i_Symbol;
            m_NumOfVictories = 0;
        }

        public string Nickname
        {
            get
            {
                return m_Nickname;
            }
        }

        public char Symbol
        {
            get
            {
                return m_Symbol;
            }
        }

        public int NumOfVictories
        {
            get
            {
                return m_NumOfVictories;
            }

            set
            {
                m_NumOfVictories = value;
            }
        }
    }
}
