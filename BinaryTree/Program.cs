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
            foreach (int i in arg)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();

        }
    }

    class Node
    {
        public int data;
        public Node left;
        public Node right;
        public Node parent;
        public bool visited;
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
                        n.parent = current;
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
                        n.parent = current;
                        current.right = n;
                        break;
                    }
                }
            }
        }

        public int[] GetArray()
        {
            int[] sortArray = new int[array.Length];
            /*
             * Has to be implemented.
             */
            return sortArray;
        }
    }
}
