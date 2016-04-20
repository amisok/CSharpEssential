using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arg = { 5, 2, 6, 7, 3, 8, 4 };
            Tree tree = new Tree(arg);
            tree.GenTree();
            arg = tree.GetArray();
            for (int i = 0; i < arg.Length; i++)
            {
                Console.WriteLine(arg[i]);
            }

            Console.ReadKey();

        }
    }

    class Node
    {
        public int data;
        public Node left;
        public Node right;
    }

    class Tree
    {
        int[] array;

        public Tree(int[] arg)
        {
            array = arg;
            head.data = array[0];
            head.left = null;
            head.right = null;
        }

        Node head = new Node();

        public void GenTree()
        {
            for (int i = 1; i < array.Length; i++)
            {
                Node n = new Node();
                n.data = array[i];
                Add(n);
            }
        }

        public void Add(Node n)
        {
            Node current = head;
            while (true)
            {
                if (n.data <= current.data)
                {
                    if (current.left != null)
                    {
                        current = current.left;
                    }
                    else
                    {
                        current.left = n;
                        break;
                    }
                }
                else
                {
                    if (current.right != null)
                    {
                        current = current.right;
                    }
                    else
                    {
                        current.right = n;
                        break;
                    }
                }
            }
        }

        int[] sortArray;
        int count;

        public int[] GetArray()
        {
            sortArray = new int[array.Length];
            count = 0;
            DoNext(head);
            return sortArray;
        }

        public void DoNext(Node current)
        {
            if (current != null)
            {
                DoNext(current.left);
                sortArray[count++] = current.data;
                DoNext(current.right);
            }
        }
    }
}


