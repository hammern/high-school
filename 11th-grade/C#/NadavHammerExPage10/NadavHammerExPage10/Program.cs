using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage10
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> s = new Stack<int>();

            Random rand = new Random(0);

            for (int i = 0; i < 11; i++)
            {
                s.Push(rand.Next(10));
            }

            Console.WriteLine("Numbers in stack:");
            PrintStack(s);

            Console.WriteLine("Palindrom:");
            Stack<char> charStack = new Stack<char>();
            charStack.Push('a');
            charStack.Push('b');
            charStack.Push('c');
            charStack.Push('c');
            charStack.Push('b');
            charStack.Push('a');
            PrintCharStack(charStack);
            Console.WriteLine(CheckPalindrom(charStack));

            Console.WriteLine("Sequence Stack:");
            Stack<char> sequenceStack = new Stack<char>();
            sequenceStack.Push('G');
            sequenceStack.Push('K');
            sequenceStack.Push('K');
            sequenceStack.Push('K');
            sequenceStack.Push('A');
            sequenceStack.Push('G');
            sequenceStack.Push('G');
            sequenceStack.Push('R');
            PrintCharStack(sequenceStack);
            Stack<char> noSequences = RemoveSequences(sequenceStack);
            Console.WriteLine("No Sequences:");
            PrintCharStack(noSequences);

            Console.WriteLine("Count Char:");
            Stack<char> countChars = new Stack<char>();
            countChars.Push('K');
            countChars.Push('K');
            countChars.Push('K');
            countChars.Push('A');
            countChars.Push('G');
            countChars.Push('G');
            countChars.Push('A');
            countChars.Push('G');
            countChars.Push('R');
            Stack<CharCounter> count = CountChars(countChars);
            PrintCharCounterStack(count);

            Console.Read();
        }

        private static Stack<int> Clone(Stack<int> s)
        {
            Stack<int> clone = new Stack<int>();
            Stack<int> temp = new Stack<int>();
            int val = 0;

            while (!s.IsEmpty())
            {
                temp.Push(s.Pop());
            }
            while (!temp.IsEmpty())
            {
                val = temp.Pop();
                s.Push(val);
                clone.Push(val);
            }

            return clone;
        }

        private static Node<int> Add(Node<int> temp, int value)
        {
            if (temp == null)
            {
                temp = new Node<int>(value);
            }
            else
            {
                Node<int> iter = temp;
                while (iter.HasNext())
                {
                    iter = iter.Next;
                }

                Node<int> newNode = new Node<int>(value);
                iter.Next = newNode;
            }

            return temp;
        }

        private static void PrintStack(Stack<int> s)
        {
            Stack<int> iter = Clone(s);

            while (!iter.IsEmpty())
            {
                Console.WriteLine(iter.Pop());
            }
        }
        private static void PrintCharStack(Stack<char> s)
        {
            Stack<char> iter = CloneChars(s);

            while (!iter.IsEmpty())
            {
                Console.WriteLine(iter.Pop());
            }
        }

        private static bool CheckPalindrom(Stack<char> s)
        {
            Stack<char> iter = CloneChars(s);
            Stack<char> reverse = new Stack<char>();

            while (!iter.IsEmpty())
            {
                reverse.Push(iter.Pop());
            }
            iter = CloneChars(s);

            bool palindrom = true;
            while (!iter.IsEmpty())
            {
                if (iter.Pop() != reverse.Pop())
                {
                    palindrom = false;
                    break;
                }
            }

            return palindrom;
        }

        private static Stack<char> CloneChars(Stack<char> s)
        {
            Stack<char> clone = new Stack<char>();
            Stack<char> temp = new Stack<char>();
            char val;

            while (!s.IsEmpty())
            {
                temp.Push(s.Pop());
            }
            while (!temp.IsEmpty())
            {
                val = temp.Pop();
                s.Push(val);
                clone.Push(val);
            }

            return clone;
        }

        private static Node<char> AddChars(Node<char> temp, char value)
        {
            if (temp == null)
            {
                temp = new Node<char>(value);
            }
            else
            {
                Node<char> iter = temp;
                while (iter.HasNext())
                {
                    iter = iter.Next;
                }

                Node<char> newNode = new Node<char>(value);
                iter.Next = newNode;
            }

            return temp;
        }

        private static Stack<char> RemoveSequences(Stack<char> s)
        {
            Stack<char> temp = CloneChars(s);
            Stack<char> iter = new Stack<char>();
            Stack<char> noSequences = new Stack<char>();
            char nextLetter;

            while (!temp.IsEmpty())
            {
                iter.Push(temp.Pop());
            }

            char currentLetter = iter.Pop();

            while (!iter.IsEmpty())
            {
                nextLetter = iter.Pop();
                if (currentLetter != nextLetter)
                {
                    noSequences.Push(currentLetter);
                }
                currentLetter = nextLetter;
            }
            noSequences.Push(currentLetter);

            return noSequences;
        }

        private static Stack<CharCounter> CountChars(Stack<char> s)
        {
            Stack<char> copy = CloneChars(s);
            Stack<char> temp = new Stack<char>();
            Stack<CharCounter> counted = new Stack<CharCounter>();
            CharCounter currChar;

            while (!copy.IsEmpty())
            {
                currChar = new CharCounter(copy.Top());

                while (!copy.IsEmpty())
                {
                    char ch = copy.Pop();
                    if (ch == currChar.Letter)
                    {
                        currChar.Increase();
                    }
                    else
                    {
                        temp.Push(ch);
                    }
                }
                counted.Push(currChar);
                copy = CloneChars(temp);
                while (!temp.IsEmpty())
                {
                    temp.Pop();
                }
            }
            return counted;
        }

        private static void PrintCharCounterStack(Stack<CharCounter> s)
        {
            Stack<CharCounter> iter = CloneCharCounter(s);

            while (!iter.IsEmpty())
            {
                Console.WriteLine(iter.Pop());
            }
        }

        private static Stack<CharCounter> CloneCharCounter(Stack<CharCounter> s)
        {
            Stack<CharCounter> clone = new Stack<CharCounter>();
            Stack<CharCounter> temp = new Stack<CharCounter>();
            CharCounter val;

            while (!s.IsEmpty())
            {
                temp.Push(s.Pop());
            }
            while (!temp.IsEmpty())
            {
                val = temp.Pop();
                s.Push(val);
                clone.Push(val);
            }

            return clone;
        }
    }
}
