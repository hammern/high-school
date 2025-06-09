using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEx
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] inText = System.IO.File.ReadAllLines(args[0]);
                int inTextCounter = 0;
                int outTextCounter = 0;
                for (int i = 0; i < inText.Length; i++)
                {
                    if (!(i % 2 == 0))
                    {
                        if (i == 1)
                        {
                            System.IO.File.AppendAllText(args[1], inText[i]);
                            outTextCounter++;
                        }
                        else
                        {
                            System.IO.File.AppendAllText(args[1], Environment.NewLine + inText[i]);
                            outTextCounter++;
                        }
                    }
                    inTextCounter++;
                }
                Console.WriteLine("There are {0} lines in the in file", inTextCounter);
                Console.WriteLine("There are {0} lines in the out file", outTextCounter);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
    }
}
