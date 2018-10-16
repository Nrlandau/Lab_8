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
                people[i].name = file.ReadLine();
                people[i].hometown = file.ReadLine();
                people[i].favFood = file.ReadLine();
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
                    System.Console.Write("{0} is from {1} ",p.name,p.hometown);
                }
                else if(Regex.IsMatch(moreiInfo.ToLower(), @"food"))
                {
                    System.Console.Write("{0} likes {1} ",p.name,p.favFood);
                }
                else
                {
                    System.Console.WriteLine("That data does not exist, please try again");
                    continue;
                }
                moreiInfo = "";
                while(!Regex.IsMatch(moreiInfo,"^[yYNn]"))
                {
                    System.Console.WriteLine("Would you like to know more?(yes or no):");
                    moreiInfo = System.Console.ReadLine();
                }
                if(Regex.IsMatch(moreiInfo,@"^[yY]"))
                {
                    System.Console.WriteLine("What would you like to know about {1}(enter \"Hometown\" or \"Favorite food\")");
                }
                else
                    isMore = false;
            }
        }
        static void UserInputLoop(Person[] people)
        {
            int stuNum;
            try{
                System.Console.WriteLine("Enter a number 1-{0}", people.Length );
                stuNum = int.Parse(System.Console.ReadLine());
                DisplayPerson(people[stuNum-1],stuNum);

            }
            catch (Exception)
            {
                System.Console.WriteLine("ERROR");
            }

        }
        static void Main(string[] args)
        {
            string filePath = "C:\\Code\\Files\\Lab8\\People.txt";
            StreamReader sr = new StreamReader(filePath);
            int totalLength = int.Parse(sr.ReadLine());
            Person [] people = new Person[totalLength];
            MakePeople(sr, people);
            UserInputLoop(people);



        }
    }
}
