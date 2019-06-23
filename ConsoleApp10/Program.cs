using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class BinPoint
    {
        public char data;
        public BinPoint left,
                        right;
        public BinPoint()
        {
            data = ' ';
            left = null;
            right = null;
        }
        public BinPoint(char d)
        {
            data = d;
            left = null;
            right = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinPoint head=null;
            Console.WriteLine("Введите количество элементов дерева");
            int h = NaturalAndZeroCheck();
            if (h != 0)
            {
                head = IdealTree(h, head);
                Console.WriteLine("Дерево введено");
            }
            else Console.WriteLine("Tree is empty");
            ShowTree(head, 0);
            TreeDestroyer(ref head);
            if (head == null) { Console.WriteLine("Three destroyed"); }
            Console.ReadLine();
        }
        static void ShowTree(BinPoint p, int l)
        {
            if (p != null)
            {
                ShowTree(p.left, l + 3);
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(p.data);
                ShowTree(p.right, l + 3);
            }
            //else Console.WriteLine("Дерево пустое");
        }
        static BinPoint IdealTree(int size, BinPoint p)
        {
            BinPoint r;
            int nl, nr;
            if (size == 0) { p = null; return p; }
            else
            {
                nl = size / 2;
                nr = size - nl - 1;
                Console.WriteLine("введите элемент дерева");
                bool ok = false;
                char number;
                string s = Console.ReadLine();
                do
                {
                    ok = char.TryParse(s, out number);
                    if (ok == false)
                    {
                        Console.WriteLine("Incorrect element");
                        s = Console.ReadLine();
                    }
                    else if ((s == " ") || (s == "\t"))
                    {
                        Console.WriteLine("Введён пробел/таб, он будет обозначен как _");
                        number = '_';
                    }
                    //else if(s=="")
                    //{
                    //    Console.WriteLine
                    //}
                } while (!ok);
                r = new BinPoint(number);
                r.left = IdealTree(nl, r.left);
                r.right = IdealTree(nr, r.right);
                return r;
            }

        }
        static int NaturalAndZeroCheck()
        {
            int n;
            bool ok = false;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string s = Console.ReadLine();
            do
            {
                ok = int.TryParse(s, out n);
                if (ok == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Введите натуральное число");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    s = Console.ReadLine();
                }
                else
                {
                    if (n < 0)
                    {
                        ok = false;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Введите натуральное число");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        s = Console.ReadLine();
                    }
                }
            } while (!ok);
            return (n);
        }
        static void TreeDestroyer(ref BinPoint head)
        {
            if (head.left != null)
            {
                TreeDestroyer(ref head.left);
            }
            if (head.right != null)
            {
                TreeDestroyer(ref head.right);
            }
            Console.WriteLine("Element {0} destroying", head.data);
            head = null;
        }
    }
}
