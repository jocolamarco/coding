using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // width of the building.
        int H = int.Parse(inputs[1]); // height of the building.
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);

        int counter = 0;
        int X = 0;
        int Y = 0;
        int first_try = 1;

        int Xprev = 0;
        int Yprev = 0;
		
		W--;
        H--;
		
		//capture min and max values to reduce area
		int min_X = 0;
		int max_X = W;
		int min_Y = 0;
		int max_Y = H;



        // game loop
        while (counter <= N)
        {
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            Console.Error.WriteLine("Width: " + W);
            Console.Error.WriteLine("Height: " + H);
            Console.Error.WriteLine("Direction: " + bombDir);
            Console.Error.WriteLine("1Batman Prev Pos: " + Xprev + " " + Yprev);
			Console.Error.WriteLine("1Batman Min Pos: " + min_X + " " + min_Y);
			Console.Error.WriteLine("1Batman Max Pos: " + max_X + " " + max_Y);
            Console.Error.WriteLine("1Batman Pos: " + X0 + " " + Y0);


            // Going Left on the X axis
            if (bombDir == "L" || bombDir == "DL" || bombDir == "UL")
            {
                max_X = X0;

                if (Xprev > X)
                {
                    Xprev = min_X;
                }
                else
                {
                    Xprev = max_X;					
                }

            }

            // Going Right on the X axis
            if (bombDir == "R" || bombDir == "DR" || bombDir == "UR")
            {
                min_X = X0;

                if (Xprev < X)
                {
                    Xprev = max_X;
                }
                else
                {
                    Xprev = min_X;
                }
            }

            // Going Up on the Y axis
            if (bombDir == "U" || bombDir == "UL" || bombDir == "UR")
            {
                max_Y = Y0;

                if (Yprev > Y)
                {
                    Yprev = min_Y;
                }
                else
                {
                    Yprev = max_Y;
                }
            }

            // Going Down on the Y axis
            if (bombDir == "D" || bombDir == "DR" || bombDir == "DL")
            {
                min_Y = Y0;

                if (Yprev < Y)
                {
                    Yprev = max_Y;
                }
                else
                {
                    Yprev = min_Y;
                }
            }
            
            Console.Error.WriteLine("2Batman Prev Pos: " + Xprev + " " + Yprev);
			Console.Error.WriteLine("2Batman Min Pos: " + min_X + " " + min_Y);
			Console.Error.WriteLine("2Batman Max Pos: " + max_X + " " + max_Y);
            Console.Error.WriteLine("2Batman Pos: " + X0 + " " + Y0);

            switch (bombDir)
            {
                case "U":
                    X = X0;
                    Y = Y0 - (int)Math.Round((Y0 - min_Y) / 2.0, 0, MidpointRounding.AwayFromZero);
                    break;

                case "UR":
                    X = X0 - (int)Math.Round((X0 - max_X) / 2.0, 0, MidpointRounding.AwayFromZero);
                    Y = Y0 - (int)Math.Round((Y0 - min_Y) / 2.0, 0, MidpointRounding.AwayFromZero);
                    break;

                case "R":
                    X = X0 - (int)Math.Round((X0 - max_X) / 2.0, 0, MidpointRounding.AwayFromZero);
                    Y = Y0;
                    break;

                case "DR":
                    X = X0 - (int)Math.Round((X0 - max_X) / 2.0, 0, MidpointRounding.AwayFromZero);
                    Y = Y0 - (int)Math.Round((Y0 - max_Y) / 2.0, 0, MidpointRounding.AwayFromZero);
                    break;

                case "D":
                    X = X0;
                    Y = Y0 - (int)Math.Round((Y0 - max_Y) / 2.0, 0, MidpointRounding.AwayFromZero);
                    break;

                case "DL":
                    X = X0 - (int)Math.Round((X0 - min_X) / 2.0, 0, MidpointRounding.AwayFromZero);
                    Y = Y0 - (int)Math.Round((Y0 - max_Y) / 2.0, 0, MidpointRounding.AwayFromZero);
                    break;

                case "L":
                    X = X0 - (int)Math.Round((X0 - min_X) / 2.0, 0, MidpointRounding.AwayFromZero);
                    Y = Y0;
                    break;

                case "UL":
                    X = X0 - (int)Math.Round((X0 - min_X) / 2.0, 0, MidpointRounding.AwayFromZero);
                    Y = Y0 - (int)Math.Round((Y0 - min_Y) / 2.0, 0, MidpointRounding.AwayFromZero);
                    break;

            }
            Console.Error.WriteLine("Batman Target: " + X + " " + Y);

            Xprev = X0;
            Yprev = Y0;

            X0 = X;
            Y0 = Y;

            counter++;            
            
            // the location of the next window Batman should jump to.
            Console.WriteLine(X + " " + Y);
        }
    }
}