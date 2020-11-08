using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Hello
{
    static void Main (){
        // Initialize array for board
        char[] board = new char[9];
        char[] checkboard = new char[9];

        int turns = 0;
        bool check;

        // Create char for player and insert start player X
        char player;
        player = 'X';

        // Create variable to to hold input from player on where they want to place
        ConsoleKeyInfo play;

        // Set initial board.
        board[0] = '1';
        board[1] = '2';
        board[2] = '3';
        board[3] = '4';
        board[4] = '5';
        board[5] = '6';
        board[6] = '7';
        board[7] = '8';
        board[8] = '9';

        // Start while loop which calls all the methods for the game to run
        while (turns < 9)
        {
            Console.Clear();
            Console.WriteLine("Welcome to tic tac toe 2 player game!");
            Console.WriteLine($"Player {player} type the field number you want to place on: \n");

            // Have a board equal to the current board to check after insertplay() if the board changed
            // initialize string for checkboard and board so that the checkboard can be set equal to the board without changing with it
            string strcheckboard;
            string strboard = new string(board);
            strcheckboard = String.Copy(strboard);
            checkboard = strcheckboard.ToCharArray();

            // Call method printboard that gets send the current board array and refreshes the screen
            printboard(board);

            // Get key from player - (true) hides the input
            play = Console.ReadKey(true);

            // Send board array to insertplay method which returns the new array board with the play send via play.KeyChar
            board = insertplay(play.KeyChar, player, board);

            // Call checkwin method which checks if the current player has won and print win message if so
            if (checkwin(board, player)){
                Console.Clear();
                Console.WriteLine($"Congratulations player {player} won!");
                Console.WriteLine("Press a key to exit...\n");
                printboard(board);
                Console.ReadKey();
                Environment.Exit(0);
                break;
            }

            // Get bool depen on if the board has changed(player made legit mode) or not (player did not make a legit move so dont change player)
            check = board.SequenceEqual(checkboard);
            if (!(check)){
                // Change current player
                player = changeplayer(player);
                // increase turns variable to exit while loop when 9 plays done which means draw
                // done inside the check if board has changed to only increment when valid turn
                turns++;
            }
        }
        Console.Clear();
        Console.WriteLine("The game ended in a draw");
        Console.WriteLine("Press a key to exit...");
        printboard(board);
        Console.ReadKey();
    }

    // method to compare array currently using the sequenceequal()
    // static bool checkeqboard(char[] board, char[] checkboard){
    //     for(int i=0; i < checkboard.Length; i++){
    //         if(board[i] != checkboard[i]){
    //             return false;
    //         }
    //     }
    //         return true;
    // }


    static void printboard(char[] arr)
    {
        Console.WriteLine($"       [{arr[0]}] [{arr[1]}] [{arr[2]}]");
        Console.WriteLine($"       [{arr[3]}] [{arr[4]}] [{arr[5]}]");
        Console.WriteLine($"       [{arr[6]}] [{arr[7]}] [{arr[8]}]");
    }

    // send chosen field to place to checkvalid() to see if it already has either X or O
    // if it does not make the selected field equal to currentplayer
    static char[] insertplay(char place, char cplayer, char[] arr)
    {
        switch(place){
            case '1':
                if (checkvalid(arr[0])){
                    arr[0] = cplayer;
                }
                break;
            case '2':
                if (checkvalid(arr[1])){
                    arr[1] = cplayer;
                }
                break;
            case '3':
                if (checkvalid(arr[2])){
                    arr[2] = cplayer;
                }
                break;
            case '4':
                if (checkvalid(arr[3])){
                    arr[3] = cplayer;
                }
                break;
            case '5':
                if (checkvalid(arr[4])){
                    arr[4] = cplayer;
                }
                break;
            case '6':
                if (checkvalid(arr[5])){
                    arr[5] = cplayer;
                }
                break;
            case '7':
                if (checkvalid(arr[6])){
                    arr[6] = cplayer;
                }
                break;
            case '8':
                if (checkvalid(arr[7])){
                    arr[7] = cplayer;
                }
                break;
            case '9':
                if (checkvalid(arr[8])){
                    arr[8] = cplayer;
                }
                break;
            default:
                Console.WriteLine("Please select between the valid fields with a number!\nPress a key to continue...");
                Console.ReadKey();
                break;
        }

        return arr;
    }
    // if the field already has either a X or O return false to insertplay()
    static bool checkvalid(char checkplay){
        if(checkplay == 'X' || checkplay == 'O'){
            Console.WriteLine("You can't place there you stupid!\nPress a key to continue...");
            Console.ReadKey();
            return false;
        }
        else{
            return true;
        }

    }

    static char changeplayer(char player)
    {
        if ( player == 'X' ){
            player = 'O';
        }
        else{
            player = 'X';
        }
        return player;
    }
    // Method to check each row if the current players char is present 3 in a row
    // returns true if the current player has won
    static bool checkwin(char[] arr, char player)
    {
        if(arr[0] == player && arr[1] == player && arr[2] == player){
            return true;
        }
        else if (arr[3] == player && arr[4] == player && arr[5] == player){
            return true;
        }
        else if (arr[6] == player && arr[7] == player && arr[8] == player){
            return true;
        }
        else if (arr[0] == player && arr[3] == player && arr[6] == player){
            return true;
        }
        else if (arr[1] == player && arr[4] == player && arr[7] == player){
            return true;
        }
        else if (arr[2] == player && arr[5] == player && arr[8] == player){
            return true;
        }
        else if (arr[0] == player && arr[4] == player && arr[8] == player){
            return true;
        }
        else if (arr[2] == player && arr[4] == player && arr[6] == player){
            return true;
        }
        else{
            return false;
        }
    }
}
