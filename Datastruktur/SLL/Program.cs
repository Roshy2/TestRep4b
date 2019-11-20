using System;
using SLL.models;



namespace SLL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Klasse Person Testen
            Person p = new Person("Elias", "Rist", new DateTime(2000, 4, 24));
            Person p2 = new Person("Elias", "Rost", new DateTime(2000, 8, 28));
            Person p3 = new Person("Tobias", "Flöckinger", new DateTime(2000, 8, 3));
            Person p4 = new Person("Thomas", "Mairer", new DateTime(2000, 3, 3));
            Person p5 = new Person("Rudolf", "Materhorn", new DateTime(1999, 3, 3));
            SingleLinkedList<Person> sll = new SingleLinkedList<Person>();
            sll.Add(p);
            sll.Add(p2);
            sll.Add(p3);
            sll.Add(p4);
            /*
            Person PersonToFind = sll.Find(p3).Item;
            Person PersonToFind2 = sll.Find(p4).Item;

            Console.WriteLine(PersonToFind);
            Console.WriteLine(PersonToFind2);
            */
            Console.WriteLine(sll);
            sll.Change(p4, p5);
            Console.WriteLine(sll);
            

            

            /*
            bool isStartItem;
            SingleLinkedListItem<Person> personBefore = sll.FindItemBeforeItemToFind(p2 , out isStartItem);
            if (isStartItem)
            {
                Console.WriteLine("Es existiert kein Eintrag vor dem gesuchten Eintrag");
                Console.WriteLine("Die gesuchte Person ist im Starteintrag enthalten");
            }else if(personBefore != null)
            {
                Console.WriteLine("Item vor gesuchter Person existiert");
                Console.WriteLine("Person vor der gesuchten Person lautet:");
                Console.WriteLine(personBefore);
            }
            else
            {
                Console.WriteLine("gesuchte Person ist in diser Liste nicht enthalten");
            }

            
            if (sll.Remove(null))
            {
                Console.WriteLine("Person wurde entfernt");
            }
            else
            {
                Console.WriteLine("Person wurde nicht entfernt - Parameter = null");
            }

            if (sll.Remove(p))
            {
                Console.WriteLine("Person wurde entfernt");
            }
            else
            {
                Console.WriteLine("Person wurde nicht entfernt - Liste ist leer");
            }
            sll.Add(p);
            sll.Add(p2);
            sll.Add(p3);
            sll.Add(p4);
            //1. fall
            if (sll.Remove(p4))
            {
                Console.WriteLine("Person wurde entfernt -  Eintrag dazwischen  wurde entfernt");
            }
            else
            {
                Console.WriteLine("Person wurde nicht entfernt - Letzter dazwischen ");
            }

            Console.WriteLine(sll);
            */
            //Console.WriteLine(p);

            /*
            Person p2 = new Person("Elias", "Rist", new DateTime(2000, 4, 24));
            Person p3 = new Person("Tobias", "Flöckinger", new DateTime(2000, 8, 3));

            if (p == p2)
            {
                Console.WriteLine("p und p2 sind gleich: ==");
            }
            else
            {
                Console.WriteLine("p und p2 sind nicht gleich: ==");
            }
            if (p.Equals(p2))
            {
                Console.WriteLine("p und p2 sind gleich: Equals");
            }
            else
            {
                Console.WriteLine("p und p2 sind nicht gleich: Equals");
            }
            if (p == p3)
            {
                Console.WriteLine("p und p3 sind gleich: ==");
            }
            else
            {
                Console.WriteLine("p und p3 sind nicht gleich: ==");
            }
            if (p.Equals(p3))
            {
                Console.WriteLine("p und p3 sind gleich: Equals");
            }
            else
            {
                Console.WriteLine("p und p3 sind nicht gleich: Equals");
            }
            Console.ReadKey();
            */
            /*
            //Klasse SingleLinkedListItem testen
            //generische Klasse verwenden
            SingleLinkedListItem<Person> item = new SingleLinkedListItem<Person> ( p, null);
            //Console.WriteLine(item);

            //Klasse SLL Testen
            //Methode Add() testen
            SingleLinkedList<Person> singleLL = new SingleLinkedList<Person>();
            if (singleLL.Add(p))
            {
                Console.WriteLine("Person wurde hinzugefügt!");
            }
            else
            {
                Console.WriteLine("Person konnte nicht hinzugefügt werden.");
            }

            if (singleLL.Add(new Person("Tobias", "Flöckinger", new DateTime(2000, 8, 12))))
            {
                Console.WriteLine("Person wurde hinzugefügt!");
            }
            else
            {
                Console.WriteLine("Person konnte nicht hinzugefügt werden.");
            }
            Console.WriteLine( "komplette SLL ausgegeben");
            Console.WriteLine(singleLL);
            */
            Console.ReadKey();
        }
    }
}
