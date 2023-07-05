using System;

namespace Ex02
{
    public class GameBoard
    {
        public enum eGameStatus
        {
            Tie, Win, Play, Quit
        }

        // Data Members:
        private static int s_NumOfFilledFrames;
        private readonly int r_Size;
        private Frame[,] m_Board;
        private SequenceCounter[] m_CountSequenceInRows;
        private SequenceCounter[] m_CountSequenceInColumns;

        public Frame[,] Board
        {
            get
            {
                return m_Board;
            }
        }

        public int Size
        {
            get
            {
                return r_Size;
            }
        }

        public GameBoard(int i_Size)
        {
            m_Board = new Frame[i_Size, i_Size];
            r_Size = i_Size;
            s_NumOfFilledFrames = 0;
            initBoard();
        }

        public void UpdateGameStatus(out char o_WinningSymbol, ref eGameStatus io_GameStatus)
        {
            if (IsVictory(out o_WinningSymbol))
            {
                io_GameStatus = eGameStatus.Win;
            }
            else if (IsBoardFull())
            {
                io_GameStatus = eGameStatus.Tie;
            }
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
                frame.State = Frame.eFrameState.Available;
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

        public bool IsFrameAvailable(int i_Height, int i_Width)
        {
            if (m_Board[i_Height - 1, i_Width - 1].State == Frame.eFrameState.Available)
            {
                return true;
            }

            return false;
        }

        public void AssignSymbolToFrame(int i_Height, int i_Width, char i_Symbol)
        {
            Frame.eFrameState symbol;

            if (i_Symbol == 'X')
            {
                symbol = Frame.eFrameState.X;
                m_CountSequenceInRows[i_Height - 1].CounterX++;
                m_CountSequenceInColumns[i_Width - 1].CounterX++;
            }
            else
            {
                symbol = Frame.eFrameState.O;
                m_CountSequenceInRows[i_Height - 1].CounterO++;
                m_CountSequenceInColumns[i_Width - 1].CounterO++;
            }

            m_Board[i_Height - 1, i_Width - 1].State = symbol;
            s_NumOfFilledFrames++;
        }

        public void MakeRandomTurn(char i_Symbol)
        {
            Random random = new Random();
            int currentSlot = 1, availableFrames, selectedSlot;
            int? height = null, width = null;

            availableFrames = (r_Size * r_Size) - s_NumOfFilledFrames;
            selectedSlot = random.Next(1, availableFrames);
            foreach (Frame frame in m_Board)
            {
                if (frame.State == Frame.eFrameState.Available)
                {
                    if (currentSlot == selectedSlot)
                    {
                        height = frame.Height;
                        width = frame.Width;
                        break;
                    }

                    currentSlot++;
                }
            }

            AssignSymbolToFrame(height.Value + 1, width.Value + 1, i_Symbol);
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
                    if (m_CountSequenceInRows[i].CounterX == r_Size || m_CountSequenceInColumns[i].CounterX == r_Size) // Found a Row or Column of X so the winning symbol will be O.
                    {
                        o_WinningSymbol = 'O';
                        v_IsVictory = true;
                        break;
                    }

                    if (m_CountSequenceInRows[i].CounterO == r_Size || m_CountSequenceInColumns[i].CounterO == r_Size)
                    // Found a Row or Column of O so the winning symbol will be X.
                    {
                        o_WinningSymbol = 'X';
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
            if (checkDiagonalStrike(Frame.eFrameState.X, true, out o_WinningSymbol)
               || checkDiagonalStrike(Frame.eFrameState.X, false, out o_WinningSymbol)
               || checkDiagonalStrike(Frame.eFrameState.O, true, out o_WinningSymbol)
               || checkDiagonalStrike(Frame.eFrameState.O, false, out o_WinningSymbol))
            {
                v_IsVictory = true;
            }

            return v_IsVictory;
        }

        private bool checkDiagonalStrike(Frame.eFrameState i_State, bool i_IsMainDiagonal, out char o_WinningSymbol)
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

        private char enumSymbolToChar(Frame.eFrameState i_State)
        {
            char charResult;

            switch (i_State)
            {
                case Frame.eFrameState.X: // Found a Row or Column of X so the winning symbol will be O.
                    charResult = 'O';
                    break;

                case Frame.eFrameState.O:  // Found a Row or Column of O so the winning symbol will be X.
                    charResult = 'X';
                    break;

                default:
                    charResult = ' ';
                    break;
            }

            return charResult;
        }
    }
}
