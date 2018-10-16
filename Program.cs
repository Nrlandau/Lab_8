using System;
using System.IO;

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
        static void Main(string[] args)
        {
            string filePath = "C:\\Code\\Files\\Lab8\\People.txt";
            StreamReader sr = new StreamReader(filePath);
            int totalLength = int.Parse(sr.ReadLine());
            Person [] people = new Person[totalLength];
            MakePeople(sr, people);
            DisplayPeople(people);



        }
    }
}
