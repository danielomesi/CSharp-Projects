# Reverse Tic-Tac-Toe

## Technologies used

* IDE: Visual Studio 2019
* Programming language: C# 
* Framework: .NET 4.7.2
* GUI: WinForms


## Overview

Reverse Tic-Tac-Toe introduces a unique twist to the classic game by utilizing its familiar rules. 
In this variant, players take turns marking empty spaces on the board with their symbol, either X or O. 
However, the objective is different from traditional Tic-Tac-Toe. 
The player who manages to create a sequence of their symbol in a horizontal, vertical, or diagonal row becomes the **loser**, adding an intriguing challenge to the game.

### Settings Window


You have the flexibility to choose the board size when playing the game, ranging from the classic 3x3 board to a larger 10x10 board. 
This allows you to adapt the game to your preference and desired level of challenge. 
Additionally, you have the option to either play against the computer or engage in a two-player game, providing different gameplay experiences based on your preference for solo or competitive play.

<p align="center">
  <img src="https://github.com/RoyToledano/ReverseTicTacToe/assets/102805117/1ceb0c8b-e077-4abb-8490-95cfe4d69cd4" width="250">
  <img src="https://github.com/RoyToledano/ReverseTicTacToe/assets/102805117/a5b933ad-2854-4c1d-9924-d70f2df8edb3" width="247">
</p>

### Game Play

Once the program has received the specified settings, a window will appear displaying the requested board. 
Each empty cell within the board can be filled with either an X or an O, and once a cell contains a symbol, it cannot be filled again.

At the bottom of the window, you will find the names of the players along with their respective scores. 
The player whose name is displayed in bold font indicates that it is currently their turn to play, adding clarity and indicating the active player.

<p align="center" style="font-family: 'Bolt', sans-serif;">
    3X3 Game Board
</p>

<p align="center">
  <img src="https://github.com/RoyToledano/ReverseTicTacToe/assets/102805117/c9b196e4-2570-4665-8533-deae4016dd02" width="250">
</p>


<p align="center" style="font-family: 'Bolt', sans-serif;">
    5X5 Game Board
</p>

<p align="center">
  <img src="https://github.com/RoyToledano/ReverseTicTacToe/assets/102805117/4b7c3d07-8681-465b-bbba-48f0446c5c68" width="250">
</p>

### Win Or Tie

As mentioned earlier, the objective of the game is for one player to create a sequence of their symbol in a horizontal, vertical, or diagonal row, making the other player the winner. 
In the event of a win, the winner's score at the bottom of the window will be incremented by 1, acknowledging their victory.

If all the cells on the board are filled and no winner has been determined, a tie will be declared. In both cases, a small window will appear, prompting you for another round.

If you choose to continue playing, clicking on ```Yes``` will reset the board for a fresh round. However, if you decide to end the game, clicking on ```No``` will close the game, allowing you to exit gracefully.

<p align="center">
  <img src="https://github.com/RoyToledano/ReverseTicTacToe/assets/102805117/ae9f30b1-c59e-4803-b0c0-c437b0b00c79" width="250">
  <img src="https://github.com/RoyToledano/ReverseTicTacToe/assets/102805117/a1b494f2-578a-438e-8655-69dde8080606" width="246.5">
</p>

### Release
In the release window located on the right-hand side, you will find the option to download the final executable file of the game, as well as the accompanying source code. 
