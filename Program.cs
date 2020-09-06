using System;

namespace TicTacToe
{

    class Program
    {
         
        // create the play board
        static char[,] setField = new char[,] 
            {
                { '1','2','3'},
                { '4','5','6'},
                { '7','8','9'},
            };

        // we need this to set it as an initial so we can reset the board everytime player has won
        static char[,] setFieldReset = new char[,]
            {
                { '1','2','3'},
                { '4','5','6'},
                { '7','8','9'},
            };





        static void Main(string[] args)
        {
            int player = 2; //player 1 starts
            int input = 0;
            bool inputCorrect = true;
            
            

            //run code as long as game runs
            do
            {
                

                if (player == 2 )
                {
                    player = 1;
                    InputXorO(player, input);
                }
                else if (player == 1 )
                {
                    player = 2;
                    InputXorO(player, input);
                }

                
                Board(); // the board is displayed and the value is updated

                #region

                //check winning condition
                char[] playerChars = { 'X','O'};

                foreach (char playerChar in playerChars)
                {
                    if ( ((setField[0,0] == playerChar) && (setField[0, 1] == playerChar) && (setField[0, 2] == playerChar)) ||
                        ((setField[1, 0] == playerChar) && (setField[1, 1] == playerChar) && (setField[1, 2] == playerChar)) ||
                        ((setField[2, 0] == playerChar) && (setField[2, 1] == playerChar) && (setField[2, 2] == playerChar)) ||
                        ((setField[0, 0] == playerChar) && (setField[1, 1] == playerChar) && (setField[2, 2] == playerChar)) ||
                        ((setField[2, 0] == playerChar) && (setField[1, 1] == playerChar) && (setField[0, 2] == playerChar)) ||
                        ((setField[0, 0] == playerChar) && (setField[1, 0] == playerChar) && (setField[2, 0] == playerChar)) ||
                        ((setField[0, 1] == playerChar) && (setField[1, 1] == playerChar) && (setField[2, 1] == playerChar)) ||
                        ((setField[0, 2] == playerChar) && (setField[1, 2] == playerChar) && (setField[2, 2] == playerChar))
                        )
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("\nPlayer 2 has won");
                        }
                        else
                        {
                            Console.WriteLine("\nPlayer 1 has won");
                        }
                        
                        Console.Write("Press key to reset the game");
                        Console.ReadKey();

                        //reset the board to start again
                        ResetField();


                        break;
                    }
                    ///check the draw condition
                    else if ( ((setField[0, 0] !='1') && (setField[0, 1] != '2') && (setField[0, 2] != '3') && (setField[1, 0] != '4')) &&
                         (setField[1, 1] != '5') && (setField[1, 2] != '6') && (setField[2, 0] != '7') && (setField[2, 1] != '8') && (setField[2, 2] != '9'))
                    {
                        Console.Write("It was a Draw!! Press a key to start again");
                        Console.ReadKey();

                        //reset the board to start again
                        ResetField();
                    }
                   
                }




                #endregion


                #region
                //tests if the field is already taken or not
                //run this loop as long as the input is incorret 
                do
                {
                    Console.Write("\n Player {0}: Choose your Field: ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                        Console.WriteLine("please enter a number!!"); ;
                    }


                    //checks if the input is correct, if it is, it is set to true else it will be false and exit the loop
                    if (input == 1 && setField[0,0] == '1')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 2 && setField[0, 1] == '2')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 3 && setField[0, 2] == '3')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 4 && setField[1, 0] == '4')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 5 && setField[1, 1] == '5')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 6 && setField[1, 2] == '6')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 7 && setField[2, 0] == '7')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 8 && setField[2, 1] == '8')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 9 && setField[2, 2] == '9')
                    {
                        inputCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("\n Incorrect input! Please use another field");
                        inputCorrect = false;
                    }

                    #endregion

                } while (!inputCorrect);




            } while (true);
             
        }



        public static void Board() 
        {
            Console.Clear(); //resets/cleans the screen
            Console.WriteLine("    |       |     ");
            Console.WriteLine("{0}   |  {1}    |  {2}  ", setField[0,0], setField[0, 1], setField[0, 2]);
            Console.WriteLine("----|-------|-----");
            Console.WriteLine("{0}   |  {1}    |  {2}  ", setField[1, 0], setField[1, 1], setField[1, 2]);
            Console.WriteLine("----|-------|-----");
            Console.WriteLine("{0}   |  {1}    |  {2}  ", setField[2, 0], setField[2, 1], setField[2, 2]);
            Console.WriteLine("    |       |     ");
            
        }


        public static void ResetField() 
        {
            setField = setFieldReset;
            Board();
        }


        public static void InputXorO(int player, int input) 
        {
            char playerSign = ' ';

            if (player == 1)
            {
                playerSign = 'X';
            }
            else if(player == 2)
            {
                playerSign = 'O';
            }


            switch (input)
            {
                //replace the playfield positions with the sign of player
                case 1:
                    setField[0, 0] = playerSign;
                    break;
                case 2:
                    setField[0, 1] = playerSign;
                    break;
                case 3:
                    setField[0, 2] = playerSign;
                    break;
                case 4:
                    setField[1, 0] = playerSign;
                    break;
                case 5:
                    setField[1, 1] = playerSign;
                    break;
                case 6:
                    setField[1, 2] = playerSign;
                    break;
                case 7:
                    setField[2, 0] = playerSign;
                    break;
                case 8:
                    setField[2, 1] = playerSign;
                    break;
                case 9:
                    setField[2, 2] = playerSign;
                    break;
                default:
                    break;
            }

        }
    }
}
