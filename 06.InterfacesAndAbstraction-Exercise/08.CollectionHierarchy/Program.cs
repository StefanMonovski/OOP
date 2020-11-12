using System;
using System.Collections.Generic;
using _08.CollectionHierarchy.Collections;
using _08.CollectionHierarchy.Interfaces;

namespace _08.CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> addCollectionAddResults = new List<int>();
            List<int> addRemoveCollectionAddResults = new List<int>();
            List<int> myListAddResults = new List<int>();

            List<string> addRemoveCollectionRemoveResults = new List<string>();
            List<string> myListRemoveResults = new List<string>();

            string[] inputData = Console.ReadLine().Split();
            int removeOperationsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputData.Length; i++)
            {
                addCollectionAddResults.Add(addCollection.Add(inputData[i]));
                addRemoveCollectionAddResults.Add(addRemoveCollection.Add(inputData[i]));
                myListAddResults.Add(myList.Add(inputData[i]));
            }

            for (int i = 0; i < removeOperationsCount; i++)
            {
                addRemoveCollectionRemoveResults.Add(addRemoveCollection.Remove());
                myListRemoveResults.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", addCollectionAddResults));
            Console.WriteLine(string.Join(" ", addRemoveCollectionAddResults));
            Console.WriteLine(string.Join(" ", myListAddResults));
            Console.WriteLine(string.Join(" ", addRemoveCollectionRemoveResults));
            Console.WriteLine(string.Join(" ", myListRemoveResults));
        }
    }
}
