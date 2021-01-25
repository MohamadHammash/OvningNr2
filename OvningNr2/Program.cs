using System;
using System.Collections.Generic;

namespace OvningNr2
{
    class Program
    {

        static void Main(string[] args)
        {
            SecondAssignment();// The whole assignment in one method.
            CmdBreak();     // a break so the program doesn't immediately closes when it's finished
                            //while using Command prompt instead of Visual studio.

        }

        private static void CmdBreak()
        {
            Console.WriteLine(".");
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void SecondAssignment()
        {
            do      // loop the following methods if the user's input id invalid
            {
                ShowMainMenu(); // This method is used to show the main menu

                UserAction();   // This method contains the switch statement
            }
            while (!PriceCategory.right);
        }

        private static void UserAction()
        {
            int choise = Util.AskForInteger(); //make sure the user enters an integer otherwise 
                                               //loop back and ask the user to enter a number


            switch (choise)
            {
                case 0:     //if the user enters "0" the program will exit.
                    Environment.Exit(0);
                    break;
                case 1: //if the user enters "1" the program will navigate to the Cinema Menu.
                    CinemaMenu(); // this method is the cinema menu

                    break;
                case 2:  //if the user enters "2" the program will navigate to the words Menu.
                    WordMenu();

                    break;
                case 3: //if the user enters "3" the program will navigate to the Sentence splitter menu.
                    SplitterPicker();

                    break;
                default: // if the user has another input the program will ask the user to enter a valid choise.
                    PriceCategory.right = false;
                    Console.WriteLine("Please enter a valid number");
                    break;
            }
        }

        private static void SplitterPicker()
        {
            bool wordsCount = false; // to be used to check that the user enter minimum 3 words

            do // loop if the user enters less than 3 words.
            {
                Console.WriteLine("Please enter a sentence of minimum 3 words!");
                string sentence = Console.ReadLine();
                //string strTrim = sentence.Trim();
                // string[] wordArr = sentence.Trim().Split(' ');
                string[] wordArr = sentence.Split(' '); // make the users input an array of strings and split
                                                        // the words everytime the user enters a space ' '.

                if (wordArr.Length < 3) // check if the user input is less than 3 words
                {
                    wordsCount = false; // if so repeat and ask for minimum of 3 words
                }
                else                    // if it's not
                {
                    wordsCount = true; // continue

                    Console.WriteLine($"The Third word is: {wordArr[2]}"); // print the third word in the user's input
                    foreach (var wordsIn in wordArr)
                    {
                        Console.WriteLine($"word: {wordsIn}"); // print the words in seperate lines
                    }

                    //foreach (var wordsIn in wordArr)
                    //{
                    //    for (int i = 1; i < wordArr.Length; i++)  // I tried here to numerate the words in the user's input
                    //    {                                         // But it was a bummer :D 

                    //Console.WriteLine($"word number {i}. {wordsIn}");
                    //    }

                    //}
                }

            }
            while (!wordsCount);
        }

        private static void WordMenu() // this method does the 2nd part of the assignment
        {                               // which is basically prints the user's input 10 times on the same line
            Console.WriteLine("Please enter a word of your choise");
            bool oneWord;       // here i added an extra code to make sure the user enters only one word :D
            do
            {

                string userInput = Util.AskForString();
                string[] userArr = userInput.Split(' ');
                if (userArr.Length > 1)
                {
                    oneWord = false;
                    Console.WriteLine("Please enter only one word");
                }
                else
                {
                    oneWord = true;
                    for (int i = 1; i < 11; i++)
                    {
                        Console.Write($" {i}. { userInput}"); // count and print the input 10 times with numeration :D
                    }
                }
            } while (!oneWord);
        }

        private static void CinemaMenu()
        {
            Console.WriteLine("Welcome to The cinema menu,");

            Console.WriteLine("Please enter the number of Visitors");

            //1. How many visitors (getinput from user)
            bool notZero; // to be used to check if number of visitor is 0
            do
            {
                int numberOfVisitors = Util.AskForInteger();
                if (numberOfVisitors < 1) // is number of visitors is less than 1? 
                {
                    notZero = false; // if so please reenter a valid number.
                    Console.WriteLine("Please enter a valid number of visitors");
                }
                else
                {
                    notZero = true;

                    var VisitorList = new List<Visitors>();
                    //2. Loop on nr of visitors
                    for (int i = 1; i <= numberOfVisitors; i++)
                    {
                        //3. What age? Later Name....
                        Console.WriteLine($"Please Enter the ages of visitor number: {i }");
                        int ageOfVisitors = Util.AskForInteger();
                        //  ok = false;
                        Console.WriteLine($"Plese Enter the name of visitor number: {i}");
                        Visitors.nameOfVisitor = Util.AskForString();

                        // var name = Util.AskForString();
                        //Visitors visitor = new Visitors();    // Tried to have a similar output to:
                        //visitor.nameOfVisitor = name;        // The total entry price for: Mohamad, Dimitris, And David is: 360 kr.  
                        //VisitorList.Add(visitor);            // Didn't work out :D
                        
                        //4. Check price
                        if (ageOfVisitors > 4 && ageOfVisitors < 20)
                        {
                            //5.a Add price
                            PriceCategory.TotalPrice += PriceCategory.TeenPrice;
                            Console.WriteLine($"Ungdomspris: {PriceCategory.TeenPrice} kr");
                        }
                        else if (ageOfVisitors > 64 && ageOfVisitors <= 100)
                        {
                            //5.b Add price
                            PriceCategory.TotalPrice += PriceCategory.SenoirPrice;
                            Console.WriteLine($"Pensionärspris: {PriceCategory.SenoirPrice} kr");

                        }
                        else if (ageOfVisitors < 5 || ageOfVisitors > 100)
                        {
                            //5.c Add price
                            PriceCategory.TotalPrice += PriceCategory.FreePrice;
                            Console.WriteLine("You are welcome to enter the cinema for free");
                        }
                        else
                        {
                            //5.d Add price
                            PriceCategory.TotalPrice += PriceCategory.StandardPrice;
                            Console.WriteLine($"Standardpris: {PriceCategory.StandardPrice} kr");
                        }
                        // 6. Print Price
                    }
                    if (numberOfVisitors == 1)
                    {
                        //Visitors name = new Visitors();
                        Console.WriteLine($"Welcome Mr/Mrs {Visitors.nameOfVisitor} The entry price for you is:  {PriceCategory.TotalPrice} kr  ");
                    }
                    else
                    {
                        //foreach (var v in VisitorList)
                        //{
                        //    for (int i = 0; i < VisitorList.Count -1; i++)
                        //    {
                        //        Console.WriteLine(VisitorList.ToArray()[i]); 
                                                //THE REST OF THE CODE ABOVE TO PRINT NAMES. 
                                                    
                        //    }
                            //Console.Write($"{v.nameOfVisitor}, ");
                        //stringbuilder
                            
                        //}


                        Console.WriteLine($"The total entry price for all {numberOfVisitors} people  is: {PriceCategory.TotalPrice} kr");
                        //}

                    }
                }


            }
            while (!notZero);
        }


        private static void ShowMainMenu() // the name of the method tells actually everything :D
        {
            Console.WriteLine("Welocme to the main menu!");
            Console.WriteLine("Please Press '1' if you'd like to go to the cinema menu ");
            Console.WriteLine("Please press '2' if you'd like to go to word repeater menu");
            Console.WriteLine("Please press '3' if you'd like to go to Sentence splitter menu");
            Console.WriteLine("To exit the program please press '0'");
        }



    }
}
