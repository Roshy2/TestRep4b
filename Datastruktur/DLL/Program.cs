using System;
using DLL.models;

namespace DLL
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Elias", "Rist", new DateTime(2000, 4, 24));
            //Person p1 = new Person("Elias", "Rist", new DateTime(2000, 4, 24));
            Person p2 = new Person("Emil", "Rost", new DateTime(2000, 8, 28));
            Person p3 = new Person("Tobias", "Flöckinger", new DateTime(2000, 8, 3));
            Person p4 = new Person("Thomas", "Mairer", new DateTime(2000, 3, 3));
            //Person p5 = new Person("Rudolf", "Materhorn", new DateTime(1999, 3, 3));
            
            DoubleLinkedList<Person> dll = new DoubleLinkedList<Person>();
            
            dll.Add(p);
            dll.Add(p2);
            dll.Add(p3);
            dll.Add(p4);
            
            /*
            --------------------------------------------------------------------
            //Personen können gespeichert und abgerufen werden
            DoubleLinkedListItem<Person> item = new DoubleLinkedListItem<Person>(p3,null,null);
            Console.WriteLine(item);
            --------------------------------------------------------------------
            */
            /*
            ---------------------------------------------------------------------
            //Methode Add Test
            DoubleLinkedList<Person> dll = new DoubleLinkedList<Person>();
            
            if (dll.Add(p))
            {
                Console.WriteLine("Person wurde hinzugefügt!");
            }
            else
            {
                Console.WriteLine("Person konnte nicht hinzugefügt werden.");
            }
            if (dll.Add(new Person("Tobias", "Flöckinger", new DateTime(2000, 8, 12))))
            {
                Console.WriteLine("Person wurde hinzugefügt!");
            }
            else
            {
                Console.WriteLine("Person konnte nicht hinzugefügt werden.");
            }
            Console.WriteLine("komplette DLL ausgegeben.");
            Console.WriteLine(dll);
            --------------------------------------------------------------------
            */

            //Methode Remove Test
            if (dll.Remove(p4)){
                Console.WriteLine(" letztes Item wurde  gelöscht");
            }
            else
            {
                Console.WriteLine("wurde nicht gefunden ");
            }
            Console.WriteLine(dll);

            Console.ReadKey();
        }
    }
}
