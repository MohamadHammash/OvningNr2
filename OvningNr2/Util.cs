using System;
using System.Collections.Generic;
using System.Text;

namespace OvningNr2
{
   public static class  Util
    {
        public static string AskForString()
        {
            bool success = false;
            string answer;

            do
            {
                Console.WriteLine();
                answer = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine("You must enter something");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }

        public static int AskForInteger()
        {
            bool ok = false;
            int choise;
            do
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out choise))
                {

                    ok = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid choise! ");
                }

            }
            while (!ok);
            return choise;
        }

        


    }
}