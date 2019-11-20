using System;
using Binary_Tree.models;

namespace Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();
            //bt.Add(20);
            //bt.Add(5);
            //bt.Add(30);
            //bt.Add(2);
            //bt.Add(5);
            //bt.Add(6);
            //bt.Add(7);
            bt.AddRek(20);
            bt.AddRek(5);
            bt.AddRek(30);
            bt.AddRek(2);
            bt.AddRek(5);
            bt.AddRek(6);
            bt.AddRek(7);
            bt.AddRek(3);
            bt.AddRek(32);
            bt.AddRek(31);
            //bt.AddRek(28);
            //bt.AddRek(29);

            bt.Remove(32);
            bt.Remove(28);
            //bt.Remove(2);
            //bt.Remove(6);
            
            Console.WriteLine();

            //Console.WriteLine(bt.MinimumRecursiv(5));
            //Console.WriteLine(bt.MaximumRecursiv(5));
            Console.ReadKey();
        }
    }
}
