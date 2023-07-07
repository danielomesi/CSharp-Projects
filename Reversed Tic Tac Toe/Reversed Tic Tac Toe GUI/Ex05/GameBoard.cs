using System;

namespace ReverseTicTacToe
{
    public class GameBoard
    {
        private const string k_SymbolX = "X";
        private const string k_SymbolO = "O";
        private const int k_FirstPlayerIndex = 0;
        private const int k_SecondPlayerIndex = 1;


        // Data Members:
        private static int s_NumOfFilledFrames;
        private readonly int r_Size;
        private Frame[,] m_Board;
        private int m_CurrentPlayerIndex = 0;
        private SequenceCounter[] m_CountSequenceInRows;
        private SequenceCounter[] m_CountSequenceInColumns;

        public Frame[,] Board
        {
            get
            {
                return m_Board;
            }

            set
            {
                m_Board = value;
            }
        }

        public int Size
        {
            get
            {
                return r_Size;
            }
        }

        public int CurrentPlayerIndex
        {
            get
            {
                return m_CurrentPlayerIndex;
            }

            set
            {
                m_CurrentPlayerIndex = value;
            }
        }

        public GameBoard(int i_Size)
        {
            m_Board = new Frame[i_Size, i_Size];
            r_Size = i_Size;
            s_NumOfFilledFrames = 0;
            initBoard();
        }

        public eGameStatus UpdateGameStatus(out char o_WinningSymbol)
        {
            eGameStatus gameStatus = eGameStatus.Play;

            if (IsVictory(out o_WinningSymbol))
            {
                gameStatus = eGameStatus.Win;
            }
            else if (IsBoardFull())
            {
                gameStatus = eGameStatus.Tie;
            }

            return gameStatus;
        }

        public bool IsBoardFull()
        {
            int maxFramesInBoard = r_Size * r_Size;
            bool v_IsBoardFull = false;

            if (s_NumOfFilledFrames == maxFramesInBoard)
            {
                v_IsBoardFull = true;
            }

            return v_IsBoardFull;
        }

        public void ClearBoard()
        {
            foreach (Frame frame in m_Board)
            {
                frame.State = eFrameState.Available;
            }

            for (int i = 0; i < r_Size; i++)
            // Implemented in 'for' and not 'foreach', in order to avoid implementing 4 foreach loops (using the index in this for loop).
            {
                m_CountSequenceInColumns[i].CounterO = 0;
                m_CountSequenceInColumns[i].CounterX = 0;
                m_CountSequenceInRows[i].CounterO = 0;
                m_CountSequenceInRows[i].CounterX = 0;
            }

            s_NumOfFilledFrames = 0;
        }

        private void initBoard()
        {
            for (int row = 0; row < r_Size; row++)
            {
                for (int columns = 0; columns < r_Size; columns++)
                {
                    m_Board[row, columns] = new Frame(row, columns);
                }
            }
            // init counters arrays to zero:
            m_CountSequenceInRows = new SequenceCounter[r_Size];
            m_CountSequenceInColumns = new SequenceCounter[r_Size];
        }

        public void MakeRegularTurn(int i_Height, int i_Width)
        {
            if(m_CurrentPlayerIndex == k_FirstPlayerIndex)
            {
                updateFrameStatus(i_Height, i_Width, eFrameState.X, k_SymbolX);
                invokeFrameUpdated(k_SymbolX, m_Board[i_Height, i_Width]);
            }
            else
            {
                updateFrameStatus(i_Height, i_Width, eFrameState.O, k_SymbolO);
                invokeFrameUpdated(k_SymbolO, m_Board[i_Height, i_Width]);
            }

            switchTurnIndex();
        }

        private void invokeFrameUpdated(string i_Text, Frame i_Frame)
        {
            if(i_Frame.FrameUpdated != null)
            {
                i_Frame.FrameUpdated.Invoke(i_Text);
            }
        }

        public void MakeRandomTurn()
        {
            Random random = new Random();
            int currentSlot = 1, availableFrames, selectedSlot;

            availableFrames = (r_Size * r_Size) - s_NumOfFilledFrames;
            selectedSlot = random.Next(1, availableFrames);
            foreach (Frame frame in m_Board)
            {
                if (frame.State == eFrameState.Available)
                {
                    if (currentSlot == selectedSlot)
                    {
                        updateFrameStatus(frame.Height, frame.Width, eFrameState.O, k_SymbolO);
                        invokeFrameUpdated(k_SymbolO, frame);
                        switchTurnIndex();
                        break;
                    }

                    currentSlot++;
                }
            }
        }

        private void updateFrameStatus(int i_Height, int i_Width, eFrameState i_Symbol, string i_Text)
        {
            Frame frame = m_Board[i_Height, i_Width];

            if(frame.State == eFrameState.Available)
            {
                frame.State = i_Symbol;
            }

            if(i_Symbol == eFrameState.X)
            {
                m_CountSequenceInRows[i_Height].CounterX++;
                m_CountSequenceInColumns[i_Width].CounterX++;
            }
            else
            {
                m_CountSequenceInRows[i_Height].CounterO++;
                m_CountSequenceInColumns[i_Width].CounterO++;
            }

            s_NumOfFilledFrames++;
        }

        public bool IsVictory(out char o_WinningSymbol)
        {
            bool v_IsVictory = false;

            if (isDiagonalStrike(out o_WinningSymbol))
            {
                v_IsVictory = true;
            }
            else
            {
                for (int i = 0; i < r_Size; i++)
                {
                    if (m_CountSequenceInRows[i].CounterX == r_Size || m_CountSequenceInColumns[i].CounterX == r_Size) 
                    // Found a Row or Column of X so the winning symbol will be O.
                    {
                        o_WinningSymbol = char.Parse(k_SymbolO);
                        v_IsVictory = true;
                        break;
                    }

                    if (m_CountSequenceInRows[i].CounterO == r_Size || m_CountSequenceInColumns[i].CounterO == r_Size)
                    // Found a Row or Column of O so the winning symbol will be X.
                    {
                        o_WinningSymbol = char.Parse(k_SymbolX);
                        v_IsVictory = true;
                        break;
                    }
                }
            }

            return v_IsVictory;
        }

        private bool isDiagonalStrike(out char o_WinningSymbol)
        {
            bool v_IsVictory = false;

            //checking if exists Main Diagonal X or Main Diagonal O or  Secondary Diagonal X or Secondary Diagonal O
            if (checkDiagonalStrike(eFrameState.X, true, out o_WinningSymbol)
               || checkDiagonalStrike(eFrameState.X, false, out o_WinningSymbol)
               || checkDiagonalStrike(eFrameState.O, true, out o_WinningSymbol)
               || checkDiagonalStrike(eFrameState.O, false, out o_WinningSymbol))
            {
                v_IsVictory = true;
            }

            return v_IsVictory;
        }

        private bool checkDiagonalStrike(eFrameState i_State, bool i_IsMainDiagonal, out char o_WinningSymbol)
        {
            bool v_isVictory = true;
            int j;

            for (int i = 0; i < r_Size; i++)
            {
                if (i_IsMainDiagonal)
                {
                    if (m_Board[i, i].State != i_State)
                    {
                        v_isVictory = false;
                        break;
                    }
                }
                else
                {
                    j = r_Size - i - 1;
                    if (m_Board[i, j].State != i_State)
                    {
                        v_isVictory = false;
                        break;
                    }
                }
            }

            o_WinningSymbol = enumSymbolToChar(i_State);

            return v_isVictory;
        }

        private char enumSymbolToChar(eFrameState i_State)
        {
            char charResult;

            switch (i_State)
            {
                case eFrameState.X: // Found a Row or Column of X so the winning symbol will be O.
                    charResult = char.Parse(k_SymbolO);
                    break;

                case eFrameState.O:  // Found a Row or Column of O so the winning symbol will be X.
                    charResult = char.Parse(k_SymbolX);
                    break;

                default:
                    charResult = ' ';
                    break;
            }

            return charResult;
        }

        private void switchTurnIndex()
        {
            if (m_CurrentPlayerIndex == k_FirstPlayerIndex)
            {
                m_CurrentPlayerIndex = k_SecondPlayerIndex;
            }
            else
            {
                m_CurrentPlayerIndex = k_FirstPlayerIndex;
            }
        }
    }
}
