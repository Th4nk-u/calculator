using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace For_loop_test
{
    internal class Program
    {
        public static double AddMethod(double value1, double value2)
        {
            return value1 + value2;
        }

        public static double SubtractMethod(double value1, double value2)
        {
            return value1 - value2;
        }
        public static double MultiplyMethod(double value1, double value2)
        {
            return value1 * value2;
        }

        public static double DivideMethod(double value1, double value2)
        {
            return value1 / value2;
        }

        

        static void Main(string[] args)
        {
            Console.WriteLine("c# calculator foreach concept");
            Console.WriteLine("single type math symbol only");
            bool sequence = true;
            bool sequenceL = true; //equation left side
            bool sequenceR = true; // equation Right side
            bool sequenceC = true; // equation center side
            bool intro = true;
            bool LeftEmpty = false;
            bool RightEmpty = false;
            char[] chStr;
            int i = 0;
            int i1 = 0;
            int Slocation = 0;
            int Alocation = 0;
            int Mlocation = 0;
            int Dlocation = 0;
            int counter = 0;

            double Ddouble1 = 0;
            double Ddouble2 = 0;
            double Ddouble3 = 0;
            var DnumL = "..";
            var DnumL001 = "..";
            var DnumL002 = "..";
            var DnumR001 = "..";
            var DnumR = "..";
            var DnumR1 = "..";
            var MnumL = "..";
            var MnumR = "..";
            var AnumL = "..";
            var AnumR = "..";
            var SnumL = "..";
            var SnumR = "..";
            bool deliminate = true;
            int MaxOut1 = 1;
            int MaxOut2 = 2;
            List<int> list = new List<int>();



            while (sequence)
            {
                Console.WriteLine("write down math equation");
                var equation = Console.ReadLine();

                sequenceL = true; sequenceR = true; sequenceC = true; LeftEmpty = false; RightEmpty = false;
                Slocation = 0; Alocation = 0; Mlocation = 0; Dlocation = 0;
                i = 0; i1 = 0; list.Clear(); 

                Console.WriteLine("restarted");

                if (equation.Contains("/"))                    
                {
                    Console.WriteLine("divide found");
                    DnumL = equation.Split('/')[0];
                    DnumR = equation.Split('/')[1];

                    // removing left side of divide equation
                    while (sequenceL)
                    {
                        chStr = DnumL.ToCharArray();

                        //locator
                        foreach (char s in chStr)
                        {
                            Console.WriteLine(s);
                            if (s == '/')
                            {
                                Console.Write("divide array location=");
                                Console.Write(i);
                                Dlocation = i;
                                Console.WriteLine(" ");
                            }
                            else if (s == '*')
                            {
                                Console.Write("multiply array location=");
                                Console.Write(i);
                                Mlocation = i;
                                Console.WriteLine(" ");
                            }

                            else if (s == '+')
                            {
                                Console.Write("add array location=");
                                Console.Write(i);
                                Alocation = i;
                                Console.WriteLine(" ");
                            }
                            else if (s == '-')
                            {
                                Console.Write("Substract array location=");
                                Console.Write(i);
                                Slocation = i;
                                Console.WriteLine(" ");
                            }
                            i++;

                        }

                        while (intro)
                        {
                            Console.WriteLine("start divide intro left");                            
                            MaxOut1 = Math.Max(Mlocation, Alocation);
                            MaxOut2 = Math.Max(MaxOut1, Slocation);                        

                            if (MaxOut2 < 1)
                            {
                                MaxOut1 = 0;
                                DnumL001 = DnumL;
                                LeftEmpty = true;
                            }
                            else if (MaxOut1 >= 1)
                            {
                                DnumL001 = DnumL.Remove(MaxOut2 + 1);
                                Console.WriteLine(DnumL001);
                            }
                            
                            Console.WriteLine(DnumL001);
                            
                            intro = false;
                        }
                        if (DnumL.Contains('*'))
                        {
                            DnumL = DnumL.Remove(0, (MaxOut2 + 1));
                            Console.WriteLine(DnumL);
                        }

                        else if (DnumL.Contains('+'))
                        {
                            DnumL = DnumL.Remove(0, (MaxOut2 + 1));
                            Console.WriteLine(DnumL);
                        }

                        else if (DnumL.Contains('-'))
                        {
                            DnumL = DnumL.Remove(0, (MaxOut2 + 1));
                            Console.WriteLine(DnumL);
                        }       
                        
                        Mlocation = 0;
                        Alocation = 0;
                        Slocation = 0;                        
                        sequenceL = false;
                    }

                    //variable reset
                    intro = true;

                    //removing right side of divide equation
                    while (sequenceR)
                    {
                        chStr = DnumR.ToCharArray();
                        //locator
                        foreach (char s1 in chStr)
                        {
                            Console.WriteLine(s1);
                            if (s1 == '/')
                            {
                                Console.Write("divide array location=");
                                Console.Write(i1);
                                Dlocation = i1;
                                list.Add(i1);
                                Console.WriteLine(" ");
                            }
                            else if (s1 == '*')
                            {
                                Console.Write("multiply array location=");
                                Console.Write(i1);
                                Mlocation = i1;
                                list.Add(i1);
                                Console.WriteLine(" ");
                            }

                            else if (s1 == '+')
                            {
                                Console.Write("add array location=");
                                Console.Write(i1);
                                Alocation = i1;
                                Console.WriteLine(" ");
                                list.Add(i1);
                                
                            }
                            else if (s1 == '-')
                            {
                                Console.Write("Substract array location=");
                                Console.Write(i1);
                                Slocation = i1;
                                Console.WriteLine(" ");
                                list.Add(i1);
                            }


                            i1++;
                            
                        }
                        //checking equation empty

                        if (Mlocation == 0)
                        {
                            if (Alocation == 0)
                            {
                                if (Slocation == 0)
                                {
                                    list.Add(0);
                                }
                            }
                        }

                        while (intro)
                        {                            
                            Console.WriteLine("Right side equation");
                            Console.WriteLine(DnumR);
                            list.Sort();
                            counter = list[0];

                            if (counter < 1)
                            {
                                DnumR001 = DnumR;
                                RightEmpty = true;
                            }
                            else if (counter >= 1)
                            {
                                DnumR001 = DnumR.Remove(0, counter);
                                DnumR = DnumR.Remove(counter);
                                RightEmpty = false;
                            }

                            Console.WriteLine(DnumR001);
                            Console.WriteLine(DnumR);
                            intro = false;
                        }

                        sequenceR = false;
                        
                                                
                    }

                    intro = true;

                    while (sequenceC)
                    {
                        Ddouble3 = DivideMethod(Convert.ToDouble(DnumL), Convert.ToDouble(DnumR));
                        Console.WriteLine($"= {Ddouble3}");
                        if (LeftEmpty == false)
                        {
                            if (RightEmpty == false)
                            { 
                                DnumL002 = string.Concat(DnumL001, Ddouble3, DnumR001); 
                            }
                            else if (RightEmpty == true)
                            {
                                DnumL002 = string.Concat(DnumL001, Ddouble3);
                            }
                            
                        }
                        else if (LeftEmpty == true)
                        {
                            if (RightEmpty == true)
                            {
                                DnumL002 = Convert.ToString (Ddouble3);
                                sequence = false;
                            }
                            else if (RightEmpty == false)
                            {
                                DnumL002 = string.Concat(Ddouble3, DnumR001);
                                
                            }
                        }
                        equation = DnumL002;
                        //Console.WriteLine(DnumL002);
                        Console.WriteLine("divide finish");
                        sequenceC = false;
                        
                    }

                }

                else if (equation.Contains("*"))
                {
                    MnumL = equation.Split('*')[0];
                    MnumR = equation.Split('*')[1];

                    // removing left side of divide equation
                    while (sequenceL)
                    {
                        chStr = MnumL.ToCharArray();                        
                        Console.WriteLine("multiplication start");

                        //locator
                        foreach (char s in chStr)
                        {
                            Console.WriteLine(s);

                           if (s == '+')
                            {
                                Console.Write("add array location=");
                                Console.Write(i);
                                Alocation = i;
                                Console.WriteLine(" ");
                            }
                            else if (s == '-')
                            {
                                Console.Write("Substract array location=");
                                Console.Write(i);
                                Slocation = i;
                                Console.WriteLine(" ");
                            }
                            i++;

                        }

                        while (intro)
                        {
                            Console.WriteLine("split left, multiplication intro");
                            Console.WriteLine(MnumL);
                            MaxOut1 = Math.Max(Slocation, Alocation);
                            Console.WriteLine(MaxOut1);
                            if (MaxOut1 < 1)
                            {
                                DnumL001 = MnumL;
                                LeftEmpty = true;
                            }
                            else if (MaxOut1 >= 1)
                            {
                                DnumL001 = MnumL.Remove(MaxOut1 + 1);
                                Console.WriteLine(DnumL001);
                            }
                            intro = false;
                        }


                        if (MnumL.Contains('+'))
                        {
                            MnumL = MnumL.Remove(0, (MaxOut1 + 1));
                            Console.WriteLine(MnumL);
                        }

                        else if (MnumL.Contains('-'))
                        {
                            MnumL = MnumL.Remove(0, (MaxOut1 + 1));
                            Console.WriteLine(MnumL);
                        }                            
                        Alocation = 0;
                        Slocation = 0;
                        sequenceL = false;
                    }

                    //variable reset
                    intro = true;

                    while (sequenceR)
                    {
                        chStr = MnumR.ToCharArray();
                        //locator
                        foreach (char s1 in chStr)
                        {

                            if (s1 == '+')
                            {
                                Console.Write("add array location=");
                                Console.Write(i1);
                                Alocation = i1;
                                 Console.WriteLine(" ");
                                list.Add(i1);

                            }
                            else if (s1 == '-')
                            {
                                Console.Write("Substract array location=");
                                Console.Write(i1);
                                Slocation = i1;
                                Console.WriteLine(" ");
                                list.Add(i1);
                            }
                            i1++;
                        }

                        if (Alocation == 0)
                        {
                            if (Slocation == 0)
                            {               
                                list.Add(0);
                                Console.WriteLine('.');
                            }
                        }

                        while (intro)
                        {
                            Console.WriteLine("Right side equation");
                            Console.WriteLine(MnumR);
                            list.Sort();
                            counter = list[0];

                            if (counter < 1)
                            {
                                MaxOut1 = 0;
                                DnumR001 = MnumR;
                                RightEmpty = true;
                            }
                            else if (counter >= 1)
                            {
                                DnumR001 = MnumR.Remove(0, counter);
                                MnumR = MnumR.Remove(counter);
                                RightEmpty = false;
                            }
                            Console.WriteLine(DnumR001);
                            Console.WriteLine(MnumR);
                            intro = false;
                        }

                        sequenceR = false;


                    }

                    intro = true;

                    while (sequenceC)
                    {
                        Ddouble1 = Convert.ToDouble(MnumL);
                        Ddouble2 = Convert.ToDouble(MnumR);
                        Ddouble3 = Ddouble1 * Ddouble2;
                        Console.Write("=");
                        Console.Write(Ddouble1 * Ddouble2);
                        Console.WriteLine(" ");
                        if (!LeftEmpty)
                        {
                            if (!RightEmpty)
                            {
                                DnumL002 = string.Concat(DnumL001, Ddouble3, DnumR001);
                            }
                            else if (RightEmpty)
                            {
                                DnumL002 = string.Concat(DnumL001, Ddouble3);
                            }

                        }
                        else if (LeftEmpty)
                        {
                            if (RightEmpty)
                            {
                                DnumL002 = Convert.ToString(Ddouble3);
                                sequence = false;
                            }
                            else if (!RightEmpty)
                            {
                                DnumL002 = string.Concat(Ddouble3, DnumR001);

                            }
                        }
                        Console.WriteLine("multiplication finish");
                        equation = DnumL002;
                        sequenceC = false;
                        
                    }
                }

                else if (equation.Contains("+"))
                {
                    AnumL = equation.Split('+')[0];
                    AnumR = equation.Split('+')[1];

                    // removing left side of divide equation
                    while (sequenceL)
                    {
                        chStr = AnumL.ToCharArray();
                        Console.WriteLine("Addition start");

                        //locator
                        foreach (var s in chStr)
                        {
                            Console.WriteLine(s);

                            if (s == '-')
                            {
                                Console.Write("Substract array location=");
                                Console.Write(i);
                                Slocation = i;
                                Console.WriteLine(" ");
                            }
                            i++;
                        }

                        while (intro)
                        {
                            Console.WriteLine("split left, addition intro");
                            MaxOut1 = Math.Max(0, Slocation);
                            //MaxOut2 = Math.Max(MaxOut1, Slocation);
                            Console.WriteLine(MaxOut1);
                            if (MaxOut1 < 1)
                            {
                                //MaxOut1 = 0;
                                DnumL001 = AnumL;
                                LeftEmpty = true;
                            }
                            else if (MaxOut1 >= 1)
                            {
                                DnumL001 = AnumL.Remove(MaxOut1 + 1);
                                Console.WriteLine(DnumL001);
                            }
                            intro = false;

                        }

                        /*
                        if (MnumL.Contains('*'))
                        {
                            MnumL = MnumL.Remove(0, (MaxOut2 + 1));
                            Console.WriteLineMDnumL);
                        }
                        */

                        if (AnumL.Contains('+'))
                        {
                            AnumL = AnumL.Remove(0, (MaxOut2 + 1));
                            Console.WriteLine(AnumL);
                        }

                        else if (AnumL.Contains('-'))
                        {
                            AnumL = AnumL.Remove(0, (MaxOut2 + 1));
                            Console.WriteLine(AnumL);
                        }
                        sequenceL = false;
                        Mlocation = 0;
                        Alocation = 0;
                        Slocation = 0;

                    }

                    //variable reset
                    intro = true;



                    //removing right side of divide equation
                    while (sequenceR)
                    {
                        chStr = AnumR.ToCharArray();
                        //locator
                        foreach (char s1 in chStr)
                        {
                            Console.WriteLine(s1);

                            if (s1 == '-')
                            {
                                Console.Write("Substract array location=");
                                Console.Write(i1);
                                Slocation = i1;
                                Console.WriteLine(" ");
                                list.Add(i1);
                            }
                            i1++;

                        }

                        //checking equation empty
                        if (Mlocation == 0)
                        {
                            if (Alocation == 0)
                            {
                                if (Slocation == 0)
                                {
                                    list.Add(0);
                                }
                            }
                        }

                        while (intro)
                        {
                            Console.WriteLine("Right side equation");
                            Console.WriteLine(AnumR);
                            list.Sort();
                            counter = list[0];

                            if (counter < 1)
                            {
                                MaxOut1 = 0;
                                DnumR001 = AnumR;
                                RightEmpty = true;
                            }
                            else if (counter >= 1)
                            {
                                DnumR001 = AnumR.Remove(0, counter);
                                AnumR = AnumR.Remove(counter);
                                RightEmpty = false;
                            }
                            Console.WriteLine(DnumR001);
                            Console.WriteLine(AnumR);
                            intro = false;
                        }
                        if (AnumR.Contains('-'))
                        {
                            DnumR = AnumR.Remove(Slocation);
                            Console.WriteLine(AnumR);
                        }
                        
                        sequenceR = false;


                    }

                    intro = true;

                    while (sequenceC)
                    {
                        Ddouble3 = MultiplyMethod(Convert.ToDouble(AnumL), Convert.ToDouble(AnumR));
                        Console.Write("=");
                        Console.Write(Ddouble1 + Ddouble2);
                        Console.WriteLine(" ");
                        if (LeftEmpty == false)
                        {
                            if (RightEmpty == false)
                            {
                                DnumL002 = string.Concat(DnumL001, Ddouble3, DnumR001);
                            }
                            else if (RightEmpty == true)
                            {
                                DnumL002 = string.Concat(DnumL001, Ddouble3);
                            }

                        }
                        else if (LeftEmpty == true)
                        {
                            if (RightEmpty == true)
                            {
                                DnumL002 = Convert.ToString(Ddouble3);
                                sequence = false;
                            }
                            else if (RightEmpty == false)
                            {
                                DnumL002 = string.Concat(Ddouble3, DnumR001);

                            }
                        }
                        //Console.WriteLine(DnumL002);
                        sequenceC = false;
                        sequence = false;
                    }
                }

                else if (equation.Contains("-"))
                {
                    SnumL = equation.Split('-')[0];
                    SnumR = equation.Split('-')[1];

                    // removing left side of divide equation
                    while (sequenceL)
                    {
                        chStr = SnumL.ToCharArray();
                        Console.WriteLine("Addition start");

                        //locator
                        foreach (char s in chStr)
                        {
                            Console.WriteLine(s);
                            if (s == '-')
                            {
                                Console.Write("Substract array location=");
                                Console.Write(i);
                                Slocation = i;
                                Console.WriteLine(" ");
                            }
                            i++;

                        }

                        while (intro)
                        {
                            Console.WriteLine("split left, addition intro");
                            MaxOut1 = Math.Max(0, Slocation);
                            Console.WriteLine(MaxOut1);
                            if (MaxOut1 < 1)
                            {
                                DnumL001 = SnumL;
                                LeftEmpty = true;
                            }
                            else if (MaxOut1 >= 1)
                            {
                                DnumL001 = SnumL.Remove(MaxOut1 + 1);
                                Console.WriteLine(DnumL001);
                            }
                            intro = false;

                        }


                        if (SnumL.Contains('+'))
                        {
                            SnumL = SnumL.Remove(0, (MaxOut2 + 1));
                            Console.WriteLine(SnumL);
                        }

                        else if (SnumL.Contains('-'))
                        {
                            SnumL = SnumL.Remove(0, (MaxOut2 + 1));
                            Console.WriteLine(SnumL);
                        }
                        sequenceL = false;
                        Mlocation = 0;
                        Alocation = 0;
                        Slocation = 0;

                    }

                    //variable reset
                    intro = true;



                    //removing right side of divide equation
                    while (sequenceR)
                    {
                        chStr = SnumR.ToCharArray();
                        //locator
                        foreach (char s1 in chStr)
                        {
                            Console.WriteLine(s1);

                            if (s1 == '-')
                            {
                                Console.Write("Substract array location=");
                                Console.Write(i1);
                                Slocation = i1;
                                Console.WriteLine(" ");
                                list.Add(i1);
                            }
                            i1++;

                        }

                        //checking equation empty
                        if (Mlocation == 0)
                        {
                            if (Alocation == 0)
                            {
                                if (Slocation == 0)
                                {
                                    list.Add(0);
                                }
                            }
                        }

                        while (intro)
                        {
                            Console.WriteLine("Right side equation");
                            Console.WriteLine(SnumR);
                            list.Sort();
                            counter = list[0];

                            if (counter < 1)
                            {
                                MaxOut1 = 0;
                                DnumR001 = SnumR;
                                RightEmpty = true;
                            }
                            else if (counter >= 1)
                            {
                                DnumR001 = SnumR.Remove(0, counter);
                                DnumR = SnumR.Remove(counter);
                                RightEmpty = false;
                            }
                            Console.WriteLine(DnumR001);
                            Console.WriteLine(SnumR);
                            intro = false;
                        }
                        if (SnumR.Contains('-'))
                        {
                            SnumR = SnumR.Remove(Slocation);
                            Console.WriteLine(SnumR);
                        }

                        sequenceR = false;


                    }

                    intro = true;

                    while (sequenceC)
                    {
                        Ddouble3 = SubtractMethod(Convert.ToDouble(SnumL), Convert.ToDouble(SnumR));
                        Console.Write("=");
                        Console.Write(Ddouble1 + Ddouble2);
                        Console.WriteLine(" ");
                        if (LeftEmpty == false)
                        {
                            if (RightEmpty == false)
                            {
                                DnumL002 = string.Concat(DnumL001, Ddouble3, DnumR001);
                            }
                            else if (RightEmpty == true)
                            {
                                DnumL002 = string.Concat(DnumL001, Ddouble3);
                            }

                        }
                        else if (LeftEmpty == true)
                        {
                            if (RightEmpty == true)
                            {
                                DnumL002 = Convert.ToString(Ddouble3);
                            }
                            else if (RightEmpty == false)
                            {
                                DnumL002 = string.Concat(Ddouble3, DnumR001);
                            }
                        }
                        sequenceC = false;
                        sequence = false;
                    }
                }

            }
            Console.ReadKey ();
        }
    }
}
