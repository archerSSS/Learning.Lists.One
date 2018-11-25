using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList2 l2 = new LinkedList2();
            l2.AddInTail(new Node(1));
            l2.AddInTail(new Node(2));
            l2.AddInTail(new Node(3));
            l2.AddInTail(new Node(4));

            Console.WriteLine(l2.head.value);
            Console.WriteLine(l2.head.next.value);
            Console.WriteLine(l2.head.next.next.value);

            Console.ReadKey();
        }
    }
}
