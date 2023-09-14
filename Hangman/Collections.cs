using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Collections
    {
        static void CollectionsMain(string[] args)
        {
            // Lists
            var names = new List<string>();
            names[0] = "Bo";
            names.Add("Steve");
            names.Add("Ann");

            foreach(var name in names)
            {
                Console.WriteLine(name);
            }

            // Queues
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine(queue.Dequeue());  //prints 1

            // Stack
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            Console.WriteLine(stack.Pop()); // prints 2

            //Dictionary
            var people = new Dictionary<string, int>();
            people.Add("bo", 30);
            people.Add("Steve", 45);
            Console.WriteLine(people["bo"]); // prints 30
        }
    }
}
