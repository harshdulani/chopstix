/*current build goal:

game in basic working condition.

Goal:
add clapToDivide
add x where value is 0

*/
using System;


namespace additionGame
{
    public class game
    {
        /*hands:	
        			0=1L, 1=1R
					2=2L, 3=2R
		*/
        static int[] p = { 1, 1, 1, 1 };

        //flag denotes turns taken. 0 is player 1, 1 is player 2. value is modded every move();
        static int flag = 0;

        //ch denote hands in corresp. w/ flag.
        static int ch1, ch2;

        /*
        			src and targ are replacements for pointers from c.
        			calculated values of them are used to point to different hands.
		*/

		static int src = 0, targ = 2;

        //code

        void clrscr()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        }


        void scores()
        {
            Console.WriteLine("\n\tScores are:\n\t:Player 2:");
            Console.WriteLine("\nLeft={0}\t\tRight={1}", p[2], p[3]);//player 2
            Console.WriteLine("\n\t   x");
            Console.WriteLine("\nLeft={0}\t\tRight={1}", p[0], p[1]);//player 1
            Console.WriteLine("\n\t:Player 1:");
            if (flag == 1)
                Console.WriteLine("\n\nPlayer 2's Turn!");
            else
                Console.WriteLine("\n\nPlayer 1's Turn!");
        }


        void move()
        {
        	if (flag == 1)
            {
            	src = 2 + ch1;
            	targ = 0 + ch2;
            }
            else
            {
            	src = 0 + ch1;
            	targ = 2 + ch2;
            }

    		/*
    		if flag is 1 then go in for player 2 
				else goto player 1
    		if ch is 1 then go in for right hand 
				else goto left hand
			*/

            //add points to target hand.
        	p[targ] += p[src];

            //make hand 0 when reaching 5
            if ((p[targ] > 5) || (p[targ] % 5 == 0))
                p[targ] %= 5;

			//flip flag to change turn
            flag++;
            flag %= 2;

            if (p[0] == 0 && p[1] == 0)
                Console.WriteLine("\nPlayer 2 Wins!");
            else if (p[2] == 0 && p[3] == 0)
                Console.WriteLine("\nPlayer 1 Wins!");
            else
                prompt();

        }


        void prompt()
        {
            clrscr();
            Console.WriteLine("\t:Addition game:\n\n");
            scores();
            Console.WriteLine("\n\nSelect Source Hand. \n\nEnter 0 for Left, 1 for Right:\n");
            ch1 = Convert.ToInt16(Console.ReadLine());
       
            Console.WriteLine("\nSelect target Hand. \n\nEnter 0 for Left, 1 for Right\n");
            ch2 = Convert.ToInt16(Console.ReadLine());

            

            move();
        }
        public static void Main()
        {
            game n = new game();
            n.prompt();
        }
    }
}