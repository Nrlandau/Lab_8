using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab8
{
    struct Person
    {
        public string name;
        public string hometown;
        public string favFood;
    }
    class Program
    {
        static void MakePeople(StreamReader file, Person[] people)
        {
            for(int i =0; i < people.Length; i++)
            {
                if((people[i].name = file.ReadLine()) == null)
                    throw new IndexOutOfRangeException();
                if((people[i].hometown = file.ReadLine())==null)
                    throw new IndexOutOfRangeException();
                if((people[i].favFood = file.ReadLine())==null)
                    throw new IndexOutOfRangeException();
            }
        }
        static void DisplayPeople(Person[] people)
        {
            int i =1;
            foreach(Person p in people)
            {
                System.Console.WriteLine("Name {3}:{0}\nHometown {3}:{1}\nFavoriteFood {3}:{2}",p.name,p.hometown,p.favFood,i);
                i++;
            }
        }
        static void DisplayPerson(Person p , int index)
        {
            string moreiInfo ="";
            bool isMore = true;
            System.Console.WriteLine("Student {0} is {1}. What would you like to know about {1}(enter \"Hometown\" or \"Favorite food\")",index,p.name);
            while(isMore)
            {
                moreiInfo = System.Console.ReadLine();
                if(moreiInfo.ToLower() == "hometown")
                {
                    System.Console.WriteLine("{0} is from {1} ",p.name,p.hometown);
                }
                else if(Regex.IsMatch(moreiInfo.ToLower(), @"food"))
                {
                    System.Console.WriteLine("{0} likes {1} ",p.name,p.favFood);
                }
                else
                {
                    System.Console.WriteLine("That data does not exist, please try again");
                    continue;
                }
                moreiInfo = "";
                while(!Regex.IsMatch(moreiInfo,@"^[yYNn]"))
                {
                    System.Console.WriteLine("Would you like to know more about {0}?(yes or no):",p.name);
                    moreiInfo = System.Console.ReadLine();
                }
                if(Regex.IsMatch(moreiInfo,@"^[yY]"))
                {
                    System.Console.WriteLine("What would you like to know about {0}(enter \"Hometown\" or \"Favorite food\")",p.name);
                }
                else
                    isMore = false;
            }
        }
        static bool UserInputLoop(Person[] people)
        {
            int stuNum;
            string repeat;
            try{
                System.Console.WriteLine("Enter a number 1-{0}", people.Length );
                stuNum = int.Parse(System.Console.ReadLine());
                DisplayPerson(people[stuNum-1],stuNum);
                repeat = "";
                while (!Regex.IsMatch(repeat, @"^[yYnN]"))
                {
                    System.Console.WriteLine("Enter another Username? (yes or no):");
                    repeat = System.Console.ReadLine();
                }
                if(Regex.IsMatch(repeat,@"^[nN]"))
                    return false;

            }
            catch( IndexOutOfRangeException)
            {
                System.Console.WriteLine("That number is not between {0} and {1}",1,people.Length);
            }
            catch (Exception)
            {
                System.Console.WriteLine("ERROR");
            }
            return true;

        }
        static void Main(string[] args)
        {
            string filePath;
            StreamReader sr;
            int totalLength = 0;
            Person [] people;
            while (true)
            {
                try 
                {
                    System.Console.WriteLine("Input a file");
                    filePath = System.Console.ReadLine();//"C:\\Code\\Files\\Lab8\\People.txt";
                    sr = new StreamReader(filePath);
                    totalLength = int.Parse(sr.ReadLine());
                    people = new Person[totalLength];
                    break;
                }
                catch (FileNotFoundException)
                {
                    System.Console.WriteLine("File cannot be found. ");
                }
                catch (UnauthorizedAccessException)
                {
                    System.Console.WriteLine("File connot be accessed. ");
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("Format Exception");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("UNKOWN ERROR");
                    throw ex;
                }
            }
            try
            { 
                MakePeople(sr, people);
            }
            catch(IndexOutOfRangeException)
            {
                System.Console.WriteLine("There are not enough Lines in the file.");
            }
            while (UserInputLoop(people));



        }
    }
}