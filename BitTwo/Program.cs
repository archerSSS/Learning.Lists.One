﻿using System;
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
            LinkedList2 l = new LinkedList2();
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(3));
            l.AddInTail(new Node(4));

            Console.WriteLine(l.head.value);
            Console.WriteLine(l.head.next.value);
            Console.WriteLine(l.head.next.next.value);

            Console.ReadKey();
        }
    }
}
