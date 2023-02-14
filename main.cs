using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace pj1
{
    internal class symbol_check_method
    {
        static int MyMethod(int x)
        {
            if (x < 2)
            {
                return 5 + x;
            }
            else
            {
                return x = 0;
            }
        }

        //symbol location checker 
        static (int, int, int, int) LocationCheck(string strEmpty1)

        {
            char[] chStr = strEmpty1.ToCharArray();
            int i = 0; int dl = 0; int ml = 0; int al = 0; int sl = 0;

            foreach (char s in chStr)
            {
                //Console.WriteLine(s);
                if (s == '/')
                {
                    dl = i;
                }
                else if (s == '*')
                {
                    ml = i;
                }

                else if (s == '+')
                {
                    al = i;
                }
                else if (s == '-')
                {
                    sl = i;
                }
                i++;

            }

            return (dl, ml, al, sl);
        }

        //symbol sort
        static List<int> SymbolSorter(string equationV)
        {
            var (dlM, mlM, alM, slM) = LocationCheck(equationV);
            List<int> list = new List<int>();

            list.Add(dlM);
            list.Add(mlM);
            list.Add(alM);
            list.Add(slM);
            list.Sort();
            return (list);
        }

        //check for other symbols
        static bool SymbolCheck(string equationV)
        {
            bool anySymbol = false;
            bool b1 = equationV.Contains("+");
            bool b2 = equationV.Contains("-");
            bool b3 = equationV.Contains("*");
            bool b4 = equationV.Contains("/");


            if (b1 == false && b2 == false && b3 == false && b4 == false)
            {
                anySymbol = false;
            }
            else
            {
                anySymbol = true;
            }
            return anySymbol;

        }

        static string numTransfer(double LowAnswer, string equationV, bool SymbolTrueL, bool SymbolTrueR, string ModValueL1, string ModValueR1)
        {
            if (SymbolTrueL == false & SymbolTrueR == false)
            {
                equationV = Convert.ToString(LowAnswer);
            }

            else if (SymbolTrueL == false && SymbolTrueR == true)
            {
                equationV = string.Concat(LowAnswer, ModValueR1);
            }

            else if (SymbolTrueL == true && SymbolTrueR == true)
            {
                equationV = string.Concat(ModValueL1, LowAnswer, ModValueR1);
            }

            else if (SymbolTrueL == true && SymbolTrueR == false)
            {
                equationV = string.Concat(ModValueL1, LowAnswer);
            }
            return equationV;
        }

        //equation operator method
        public static double DivideMethod(string value1, string value2)
        {
            return Convert.ToDouble(value1) / Convert.ToDouble(value2);
        }
        public static double MultiplyMethod(string value1, string value2)
        {
            return Convert.ToDouble(value1) * Convert.ToDouble(value2);
        }
        public static double AddMethod(string value1, string value2)
        {
            return Convert.ToDouble(value1) + Convert.ToDouble(value2);
        }
        public static double SubstractMethod(string value1, string value2)
        {
            return Convert.ToDouble(value1) - Convert.ToDouble(value2);
        }


        static void Main(string[] args)
        {
            bool SymbolTrueL = true;
            bool SymbolTrueR = true;
            bool start = true;
            var Lvalue = "..";
            var ModValueL = "..";
            var ModValueL1 = "..";
            var ModValueR1 = "..";
            var ModValueR = "..";
            var Rvalue = "..";
            bool LeftSide = true;
            bool RightSide = true;
            double LowAnswer = 0;
            List<int> list = new List<int>();
            //Console.WriteLine(MyMethod(1)); 
            Console.WriteLine("write and equation");
            string equationV = Console.ReadLine();

            while (start == true)
            {
                if (equationV.Contains("/"))
                {
                    Console.WriteLine("Divide operation");
                    Lvalue = equationV.Split('/')[0];
                    Rvalue = equationV.Split('/')[1];
                    LeftSide = true; RightSide = true;

                    while (LeftSide == true)
                    {
                        SymbolTrueL = SymbolCheck(Lvalue);
                        if (SymbolTrueL == true)
                        {
                            list = SymbolSorter(Lvalue);
                            ModValueL = Lvalue.Substring(list[3] + 1);
                            ModValueL1 = Lvalue.Remove(list[3] + 1);
                        }
                        else if (SymbolTrueL == false)
                        {
                            ModValueL = Lvalue;
                        }
                        list.Clear();
                        LeftSide = false;
                    }

                    while (RightSide == true)
                    {
                        SymbolTrueR = SymbolCheck(Rvalue);
                        if (SymbolTrueR == true)
                        {
                            list = SymbolSorter(Rvalue);
                            ModValueR = Rvalue.Remove(list[0] + 1);
                            ModValueR1 = Rvalue.Substring(list[0]+1);
                        }
                        else if (SymbolTrueR == false)
                        {
                            ModValueR = Rvalue;
                        }
                        list.Clear();
                        RightSide = false;
                    }

                    LowAnswer = DivideMethod(ModValueL, ModValueR);

                    equationV = numTransfer(LowAnswer, equationV, SymbolTrueL, SymbolTrueR, ModValueL1, ModValueR1);
                    Console.WriteLine(equationV);
                }

                else if (equationV.Contains("*"))
                {
                    Console.WriteLine("multiply operation");
                    Lvalue = equationV.Split('*')[0];
                    Rvalue = equationV.Split('*')[1];
                    LeftSide = true; RightSide = true;

                    while (LeftSide == true)
                    {
                        SymbolTrueL = SymbolCheck(Lvalue);
                        if (SymbolTrueL == true)
                        {
                            list = SymbolSorter(Lvalue);
                            ModValueL = Lvalue.Substring(list[3] + 1);
                            ModValueL1 = Lvalue.Remove(list[3] + 1);
                        }
                        else if (SymbolTrueL == false)
                        {
                            ModValueL = Lvalue;
                        }
                        list.Clear();
                        LeftSide = false;
                    }

                    while (RightSide == true)
                    {
                        SymbolTrueR = SymbolCheck(Rvalue);
                        if (SymbolTrueR == true)
                        {
                            list = SymbolSorter(Rvalue);
                            ModValueR = Rvalue.Remove(list[0] + 1);
                            ModValueR1 = Rvalue.Substring(list[0] + 1);
                        }
                        else if (SymbolTrueR == false)
                        {
                            ModValueR = Rvalue;
                        }
                        list.Clear();
                        RightSide = false;
                    }

                    LowAnswer = MultiplyMethod(ModValueL, ModValueR);

                    equationV = numTransfer(LowAnswer, equationV, SymbolTrueL, SymbolTrueR, ModValueL1, ModValueR1);
                    Console.WriteLine(equationV);
                }

                else if (equationV.Contains("+"))
                {
                    Console.WriteLine("addition operation");
                    Lvalue = equationV.Split('+')[0];
                    Rvalue = equationV.Split('+')[1];
                    LeftSide = true; RightSide = true;

                    while (LeftSide == true)
                    {
                        SymbolTrueL = SymbolCheck(Lvalue);
                        if (SymbolTrueL == true)
                        {
                            list = SymbolSorter(Lvalue);
                            ModValueL = Lvalue.Substring(list[3] + 1);
                            ModValueL1 = Lvalue.Remove(list[3] + 1);
                        }
                        else if (SymbolTrueL == false)
                        {
                            ModValueL = Lvalue;
                        }
                        list.Clear();
                        LeftSide = false;
                    }

                    while (RightSide == true)
                    {
                        SymbolTrueR = SymbolCheck(Rvalue);
                        if (SymbolTrueR == true)
                        {
                            list = SymbolSorter(Rvalue);
                            ModValueR = Rvalue.Remove(list[0] + 1);
                            ModValueR1 = Rvalue.Substring(list[0]+1);
                        }
                        else if (SymbolTrueR == false)
                        {
                            ModValueR = Rvalue;
                        }
                        list.Clear();
                        RightSide = false;
                    }

                    LowAnswer = AddMethod(ModValueL, ModValueR);

                    equationV = numTransfer(LowAnswer, equationV, SymbolTrueL, SymbolTrueR, ModValueL1, ModValueR1);
                    Console.WriteLine(equationV);
                }

                else if (equationV.Contains("-"))
                {
                    Console.WriteLine("substract operation");
                    Lvalue = equationV.Split('-')[0];
                    Rvalue = equationV.Split('-')[1];
                    LeftSide = true; RightSide = true;

                    while (LeftSide == true)
                    {
                        SymbolTrueL = SymbolCheck(Lvalue);
                        if (SymbolTrueL == true)
                        {
                            list = SymbolSorter(Lvalue);
                            ModValueL = Lvalue.Substring(list[3] + 1);
                            ModValueL1 = Lvalue.Remove(list[3] + 1);
                        }
                        else if (SymbolTrueL == false)
                        {
                            ModValueL = Lvalue;
                        }
                        list.Clear();
                        LeftSide = false;
                    }

                    while (RightSide == true)
                    {
                        SymbolTrueR = SymbolCheck(Rvalue);
                        if (SymbolTrueR == true)
                        {
                            list = SymbolSorter(Rvalue);
                            ModValueR = Rvalue.Remove(list[0] + 1);
                            ModValueR1 = Rvalue.Substring(list[0]+1);
                        }
                        else if (SymbolTrueR == false)
                        {
                            ModValueR = Rvalue;
                        }
                        list.Clear();
                        RightSide = false;
                    }

                    LowAnswer = SubstractMethod(ModValueL, ModValueR);

                    equationV = numTransfer(LowAnswer, equationV, SymbolTrueL, SymbolTrueR, ModValueL1, ModValueR1);
                    Console.WriteLine(equationV);
                }

                
                start = SymbolCheck(equationV);
            }

            Console.Read();

        }
    }
}