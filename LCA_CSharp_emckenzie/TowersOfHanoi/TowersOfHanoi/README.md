--Code Plan--

The gameboard will be listed as a dictionary<string, stack(int)>. Tower A starts with a stack of {1, 2, 3, 4} while stacks B and C will be empty.

User will complete do while loop string from “Select a tower to move from” string to = “Select the tower you would like to move to” (both have .ToUpper() to match A B C). I used Gameboard[toTower].Push(fromPeg); to pop off the fromTower and push on top of the toTower. This is inside an if/else that checks if the ValidMove method is true. If method is false, it tells user ("Sorry, your move was invalid. Try again.").

MoveCheck: A bool method where a New stack<int> variable is taken from the user input. --If the user inputs equal one another, the move is illegal. --If the user input targets an empty stack to take from, the move is legal. --If the top number of the fromTower is greater than the top number in the toTower the move is illegal. --Otherwise, the move is legal.

WinCheck(): if (Cpegs.Count == 4) { WinGame =true; } else { WinGame = false; } and game will continue to play until true.
