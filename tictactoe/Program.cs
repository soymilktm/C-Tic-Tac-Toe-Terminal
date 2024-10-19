// this is the one we stick with !!!! wooohooo 
// we should probably use a 2D array

// Fill array with Empty, 0 (o) or 1 (x) (could be any 3 value)

//    [1][1] |   [1][2]  |  [1][3]
// ----------------------------------
//    [2][1] |   [2][2]  |  [2][3]
//-----------------------------------
//    [3][1] |   [3][2]  |  [3][3]

// win conditions: 
// ROW: [1][1] OR [2][2] OR [3][3] 
// COL: [1][1] OR [2][2] OR [3][3] 
// DIA: [1][3],[2][2],[3][1] OR [1][1],[2][2],[3][3]

// BOT LEVEL: Easy (place mark randomly)

// method>>>>>> not sure of this method feel free to change if better methods exist hahahah
//1. player insert data
//2. search
//3. insert (random)
//4. update


// 2D Enum array
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

GridState[,] gardfile = new GridState[3,3] {{GridState.E,GridState.E,GridState.E},
                                            {GridState.E,GridState.E,GridState.E},
                                            {GridState.E,GridState.E,GridState.E}};
bool Player1Turn = true;
int PlayerTurn = 0;
bool PlayerWin = false;
bool Bot_Win = false;
bool GameEnd = false;


if(PlayerTurn<= 9 || PlayerWin == false || Bot_Win == false){
    while(Player1Turn == true && GameEnd == false){

        PrintGrid();
        Player1Input();
        Player1Turn = !Player1Turn;
        BotTurn();
        PlayerWin = WinConditions(GridState.X);
        Bot_Win = WinConditions(GridState.O);

        if (PlayerWin == true){
            Console.WriteLine(" you're win !!! woohoo c: ");
            PrintGrid();
            GameEnd = true;        
        }
        if (Bot_Win == true){
            Console.WriteLine(" you're lose !!! boohoo :c");
            PrintGrid();
            GameEnd = true; 
        }

        PlayerTurn++;

    }
}
else
    return;
        

void Player1Input(){

int Row, Col;

Console.WriteLine("Enter Row: ");
Row = int.Parse(Console.ReadLine());

Console.WriteLine("Enter Column: ");
Col = int.Parse(Console.ReadLine());
 
            if(gardfile[Row,Col] == GridState.E){
                gardfile[Row,Col] = GridState.X;
            }
            else {
                Console.WriteLine("oopsie !!! spot is taken !!! >:c");
                Player1Input();
            }    
}

void PrintGrid(){
    Console.WriteLine("     0      1      2");
    string Empty, Space = " ";
    
    for( int i = 0; i<3; i++){
        Console.Write("   │");
        for ( int j = 0; j<3; j++){
            Console.Write("  " + gardfile[i,j] + "  " + "│");
            }
        Console.WriteLine("    ");
        Console.WriteLine( i + "  " + "┼─────┼─────┼─────┼");
           
    }
}


bool WinConditions(GridState mark){
    
    // Check Diagonials (left and right)
    if (gardfile[0,2] == mark && gardfile[1,1] == mark && gardfile[2,0] == mark){
       
        return true;
    }
    if (gardfile[0,0] == mark && gardfile[1,1] == mark && gardfile[2,2] == mark){
       
        return true;
    }

    // Check rows
    for(int i = 0; i < gardfile.GetLength(0);i++){
        if (gardfile[0,i] == mark && gardfile[1,i] == mark && gardfile[2,i] == mark){ 
            return true;
        }
    }

    // check columns
    for(int j = 0; j < gardfile.GetLength(0);j++){
            if (gardfile[j,0] == mark && gardfile[j,1] == mark && gardfile[j,2] == mark)
            { 
                return true;
            }
        }
    return false;
} 


void BotTurn(){

while (Player1Turn == false){

Random randX = new Random();
Random randY = new Random();
int RandX = randX.Next(3);
int RandY = randY.Next(3);

    if(gardfile[RandX,RandY] == GridState.E){
            gardfile[RandX,RandY] = GridState.O;
            Player1Turn = !Player1Turn;
            }
    else {  //recursive :00000
        BotTurn();
        }
    }
}
//Enum Definition:
public enum GridState {E, X, O} 