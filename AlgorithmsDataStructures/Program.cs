using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList s_list = new LinkedList();
            Node n1 = new Node(12);
            Node n2 = new Node(15);
            Node n3 = new Node(17);
            s_list.AddInTail(n1);
            s_list.AddInTail(n2);
            s_list.AddInTail(new Node(128));
            s_list.AddInTail(new Node(13));
            s_list.AddInTail(new Node(12));

            Console.WriteLine(s_list.head.value);
            Console.WriteLine(s_list.head.next.value);
            Console.WriteLine(s_list.head.next.next.value);

            Console.ReadKey();
        }
    }
}
