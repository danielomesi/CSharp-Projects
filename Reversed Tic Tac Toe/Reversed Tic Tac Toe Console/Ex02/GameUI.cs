using System;

namespace Ex02
{
    public class GameUI
    {
        // #defines:
        private const string k_ComputerName = "Computer";
        private const int k_NumOfPlayers = 2;
        private const int k_MinimumBoardSize = 3;
        private const int k_MaximumBoardSize = 9;
        private const int k_ChooseToQuit = 0;

        // Data Members:
        private Player[] m_Players = null;
        private GameBoard m_GameBoard = null;
        private bool m_IsSinglePlayer;

        public void StartGame()
        {
            bool isPlaying = true;
            getGameData(ref isPlaying);

            while (isPlaying)
            {
                manageASingleGame();
                checkIfNextGame(ref isPlaying);
                m_GameBoard.ClearBoard();
                Ex02.ConsoleUtils.Screen.Clear();
            }

            Console.WriteLine("Thank you for playing!");
            Console.ReadKey();
        }

        private void getGameData(ref bool io_IsPlaying)
        {
            printWelcome();
            int boardSize = getBoardSize();

            if (boardSize != 0 && createPlayers())
            {
                m_GameBoard = new GameBoard(boardSize);
                Ex02.ConsoleUtils.Screen.Clear();
            }
            else
            {
                io_IsPlaying = false;
            }
        }

        private void manageASingleGame()
        {
            GameBoard.eGameStatus gameStatus = GameBoard.eGameStatus.Play;
            int turnPlayerIndex = 0;
            char winningSymbol;

            while (gameStatus == GameBoard.eGameStatus.Play)
            {
                if (m_IsSinglePlayer == true && turnPlayerIndex == 1)
                // When playing against the computer, the player "computer" will always be the player in index 1.
                {
                    m_GameBoard.MakeRandomTurn(m_Players[turnPlayerIndex].Symbol);
                }
                else
                {
                    executeTurn(turnPlayerIndex, ref gameStatus);
                }

                m_GameBoard.UpdateGameStatus(out winningSymbol, ref gameStatus);
                Ex02.ConsoleUtils.Screen.Clear();
                handleGameStatus(gameStatus, winningSymbol, turnPlayerIndex);
                moveToNextPlayerTurn(ref turnPlayerIndex);
            }
        }

        private void checkIfNextGame(ref bool io_IsPlaying)
        {
            Console.WriteLine("Do you want to play another round?");
            Console.WriteLine("To play another round, type 'P'. To quit the game, type 'Q'");
            string input = Console.ReadLine();
            while (input != "Q" && input != "P")
            {
                Console.WriteLine("Wrong input! Try again");
                input = Console.ReadLine();
            }

            if (input == "Q")
            {
                io_IsPlaying = false;
            }
        }

        private void executeTurn(int i_PlayerIndex, ref GameBoard.eGameStatus io_GameStatus)
        {
            string playerNickname = m_Players[i_PlayerIndex].Nickname;
            char playerSymbol = m_Players[i_PlayerIndex].Symbol;
            int heightChoice, widthChoice;
            bool v_IsFrameAvailable = false;

            Console.WriteLine($"{playerNickname}, it is your turn");
            Console.WriteLine($"Please choose the frame to fill {playerSymbol}");
            displayBoard();
            getFrameIndexes(out heightChoice, out widthChoice, ref io_GameStatus);
            while (io_GameStatus == GameBoard.eGameStatus.Play && !v_IsFrameAvailable)
            {
                if (m_GameBoard.IsFrameAvailable(heightChoice, widthChoice))
                {
                    v_IsFrameAvailable = true;
                }
                else
                {
                    Console.WriteLine("Frame is taken! please try again");
                    getFrameIndexes(out heightChoice, out widthChoice, ref io_GameStatus);
                }
            }

            if (io_GameStatus == GameBoard.eGameStatus.Play)
            {
                m_GameBoard.AssignSymbolToFrame(heightChoice, widthChoice, playerSymbol);
            }
        }

        private void handleGameStatus(GameBoard.eGameStatus i_GameStatus, char i_WinningSymbol, int i_TurnPlayerIndex)
        {
            Player winner;

            switch(i_GameStatus)
            {
                case GameBoard.eGameStatus.Win:
                    winner = getPlayerBySymbol(i_WinningSymbol);
                    winner.NumOfVictories++;
                    displayBoard();
                    Console.WriteLine($"Congratulations, {winner.Nickname}! You won this round!");
                    printPlayersScore();
                    break;

                case GameBoard.eGameStatus.Tie:
                    displayBoard();
                    Console.WriteLine("What a drama, it is a tie!");
                    printPlayersScore();
                    break;

                case GameBoard.eGameStatus.Quit:
                    Console.WriteLine($"{m_Players[i_TurnPlayerIndex].Nickname} chose to quit this game round.");
                    break;
            }
        }

        private void moveToNextPlayerTurn(ref int io_TurnIndex)
        {
            if (io_TurnIndex == 0)
            {
                io_TurnIndex = 1;
            }
            else
            {
                io_TurnIndex = 0;
            }
        }

        private Player getPlayerBySymbol(char i_Symbol)
        {
            Player foundPlayer;

            if (m_Players[0].Symbol == i_Symbol)
            {
               foundPlayer = m_Players[0];
            }
            else
            {
                foundPlayer = m_Players[1];
            }

            return foundPlayer;
        }

        private void getFrameIndexes(out int o_Height, out int o_Width, ref GameBoard.eGameStatus io_GameStatus)
        {
            Console.WriteLine("Type row:");
            o_Height = getSingleNumInRange(1, m_GameBoard.Size);
            if (o_Height != k_ChooseToQuit)
            {
                Console.WriteLine("Type col:");
                o_Width = getSingleNumInRange(1, m_GameBoard.Size);
                if (o_Width == k_ChooseToQuit)
                {
                    io_GameStatus = GameBoard.eGameStatus.Quit;
                }
            }
            else
            {
                o_Width = 0;
                io_GameStatus = GameBoard.eGameStatus.Quit;
            }
        }

        private int getBoardSize()
        {
            Console.WriteLine("Please enter the board size");
            int numInput = getSingleNumInRange(k_MinimumBoardSize, k_MaximumBoardSize);

            return numInput;
        }

        private bool createPlayers()
        {
            bool v_IsPlaying = true;

            m_IsSinglePlayer = isSinglePlayer(ref v_IsPlaying);
            if(v_IsPlaying)  // If in single/multi player menu the input is "Q", v_IsPlaying == false.
            {
                getAndAnalyzePlayersData(ref v_IsPlaying);
            }
            
            return v_IsPlaying;
        }

        // The method also "analyzes" the players input names in order to quit if the input is "Q".
        private void getAndAnalyzePlayersData(ref bool io_IsPlaying)
        {
            string playerNickname;

            m_Players = new Player[k_NumOfPlayers];
            playerNickname = getPlayerNickname();
            if(playerNickname != "Q")
            {
                m_Players[0] = new Player(playerNickname, 'X');
                if(m_IsSinglePlayer)
                {
                    m_Players[1] = new Player(k_ComputerName, 'O');
                }
                else
                {
                    playerNickname = getPlayerNickname();
                    if(playerNickname != "Q")
                    {
                        m_Players[1] = new Player(playerNickname, 'O');
                    }
                    else
                    {
                        io_IsPlaying = false;
                    }
                }
            }
            else
            {
                io_IsPlaying = false;
            }
        }

        private int getSingleNumInRange(int i_Start, int i_End)
        {
            string strNum = Console.ReadLine();
            bool v_IsValid = false;
            int ?num = null;

            while (!v_IsValid)
            {
                if (strNum.Length != 0)
                {
                    num = strNum[0] - '0';
                    if (strNum.Length == 1 && strNum[0] == 'Q')
                    {
                        num = k_ChooseToQuit;
                        v_IsValid = true;
                    }
                    else if (strNum.Length == 1 && num >= i_Start && num <= i_End)
                    {
                        v_IsValid = true;
                    }
                }

                if (!v_IsValid)
                {
                    Console.WriteLine("Wrong input! Please try again");
                    strNum = Console.ReadLine();
                }
            }

            return num.Value;
        }

        private bool isSinglePlayer(ref bool io_IsPlaying)
        {
            bool v_IsSinglePlayer = false;
            int choice;

            Console.WriteLine("Please type your choice:");
            Console.WriteLine("1 - play in single player mode");
            Console.WriteLine("2 - play in two players mode");
            choice = getSingleNumInRange(1, 2);
            if (choice == 1)
            {
                v_IsSinglePlayer = true;
            }
            else if(choice == k_ChooseToQuit)
            {
                io_IsPlaying = false;
            }

            return v_IsSinglePlayer;
        }

        private string getPlayerNickname()
        {
            string nameInput;

            Console.WriteLine("Please enter your nickname: ");
            nameInput = Console.ReadLine();
            while(nameInput == "Computer")
            {
                Console.WriteLine("The nickname 'Computer' is not allowed, Please try again");
                nameInput = Console.ReadLine();
            }

            return nameInput;
        }

        private void printWelcome()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("                                                ");
            Console.WriteLine("Welcome to Reversed Tic Tac Toe Game!      ");
            Console.WriteLine("                                                ");
            Console.WriteLine(" Get ready for an exciting adventure!  ");
            Console.WriteLine("                                                ");
            Console.WriteLine("*************************************\n");
            Console.WriteLine("For your information, you can quit");
            Console.WriteLine("the game anytime by typing 'Q'\n");
        }

        private void displayBoard()
        {
            char symbol;

            Console.Write("   ");
            for (int i = 1; i <= m_GameBoard.Size; i++)
            {
                Console.Write($"  {i} ");
            }

            Console.WriteLine();
            for (int i = 0; i < m_GameBoard.Size; i++)
            {
                Console.Write($"  {i + 1}");
                for (int j = 0; j < m_GameBoard.Size; j++)
                {
                    symbol = getSymbol(i, j);
                    Console.Write($"| {symbol} ");
                }

                Console.WriteLine($"|");
                Console.Write("   ");
                printLineSeparator();
            }
        }

        private void printPlayersScore()
        {
            Console.WriteLine("\nScores:");
            Console.WriteLine($"{m_Players[0].Nickname} - {m_Players[0].NumOfVictories}");
            Console.WriteLine($"{m_Players[1].Nickname} - {m_Players[1].NumOfVictories}\n");
        }

        private char getSymbol(int i_Height, int i_Width)
        {
            char resSymbol;
            Frame.eFrameState currentState = m_GameBoard.Board[i_Height, i_Width].State;

            switch(currentState)
            {
                case Frame.eFrameState.X:
                    resSymbol = 'X';
                    break;
                case Frame.eFrameState.O:
                    resSymbol = 'O';
                    break;
                default:
                    resSymbol = ' ';
                    break;
            }

            return resSymbol;
        }

        private void printLineSeparator()
        {
            int lineSize = 1 + (4 * m_GameBoard.Size);

            for (int k = 0; k < lineSize; k++)
            {
                Console.Write("=");
            }

            Console.WriteLine();
        }
    }
}
