namespace PracticeDay5
{
    internal class Program
    {
        static void Main1(string[] args) // exception prone code without handling // NRP,DBZ,FE
        {
            Class1 obj = new Class1();
            //obj = null;
            int x = Convert.ToInt32(Console.ReadLine());
            obj.P1 = 100 / x;
            Console.WriteLine(obj.P1);
        }

        static void Main2() //try with multiple catch 
        {
            try
            {
                Class1 obj = new Class1();
                //obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
            }
            catch (NullReferenceException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ArithmeticException ae) 
            {
                Console.WriteLine(ae.Message);
            }
            Console.WriteLine("bye bye");
        }

        static void Main3() //try with multiple catch and finally block
        {
            try
            {
                Class1 obj = new Class1();
                //obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
            }
            catch (NullReferenceException e1)
            {
                Console.WriteLine(e1.Message);
               
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                return; // still finally block is executed
               
            }
            catch (ArithmeticException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("ececuted every time");
            }
            Console.WriteLine("bye bye");

            /*
             line 68 will not execute if exception is not handled with try and catch or if return statument is there in any of the catch block

            finally block will execute either exception ocuure or not occure.
             */
        }

        static void Main4()// nested try block
        {
            Class1 obj = new Class1();
            try
            {
                //obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }

            catch (FormatException ex)
            {
                try
                {
                    Console.WriteLine("FormatException occurred. Enter only numbers");
                    int x = Convert.ToInt32(Console.ReadLine());
                    obj.P1 = 100 / x;
                    Console.WriteLine(obj.P1);
                }
                catch
                {
                    Console.WriteLine("nested try catch example");
                }
                finally
                {
                    Console.WriteLine("nested try finally example");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DBException occurred");
            }
            catch (Exception ex) //catches all unhandled exceptions
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("outer finally");

            }
            Console.ReadLine();
        }

        static void Main5() // custome exception
        {
            try
            {
                Class1 obj = new Class1();
                //obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("no exception");
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine("NullReference Exception");
                Console.WriteLine(nre.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Format exception");
                Console.WriteLine(fe.Message);
            }
            catch (ArithmeticException ae)
            {
                Console.WriteLine("Arithmatic exception");
                Console.WriteLine(ae.Message);
            }
            catch (ApplicationException aae)
            {
                Console.WriteLine("ApplicationException exception occure");
                Console.WriteLine(aae.Message);
            }
            catch (SystemException se)
            {
                Console.WriteLine("SystemException exception occure");
                Console.WriteLine(se.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("finnaly block:  over ");
            }
            Console.WriteLine("bye bye");
        }

        static void Main6() // partial class demo
        {
            PC pc = new PC();
            //Console.WriteLine(pc.i);
            //Console.WriteLine(pc.j);
            //Console.WriteLine(pc.k);
            //Console.WriteLine(pc.l);
            pc.Display();
        }

        static void Main7() // anonymous type
        {
            var i = 10;
            Console.WriteLine(i.GetType()); //System.Int32
            var x = 12.5;
            Console.WriteLine(x.GetType()); // System.Double
            var y = "Faisalkhan";
            Console.WriteLine(y.GetType()); // System.String



            var obj = new { a = "faisal", b = 25, c = 8.89, d = true };
            Console.WriteLine(obj.a); //faisal
            Console.WriteLine(obj.b); //25
            Console.WriteLine(obj.c); // 8.89
            Console.WriteLine(obj.d); //true
            Console.WriteLine(obj); // { a = "faisal", b = 25, c = 8.89, d = true }
            Console.WriteLine(obj.GetType()); // <>f__AnonymousType0`4[System.String,System.Int32,System.Double,System.Boolean]
        }

        static void Main8()
        {
            PC pc = new PC(); // call partial method call in constructor just to see that Show() method run or not which is partial method
            //pc.Show(); defualtly show method is private and we cant make it public, protected, internal
        }
    }

    //custom exception
    public class P1Exe : ApplicationException
    {
        public P1Exe(string msg) : base(msg)
        {

        }
    }

    public partial class PC
    {
        public PC()
        {
            Show(); // partial method call
        }
        public int i = 10;
        partial void Show(); // partial method declaration part
    }

    public partial class PC
    {
        public int j = 20;
        partial void Show() // partial method implimentation part
        {
            Console.WriteLine("in partial method show");
        }
    }

    public partial class PC
    {
       public  int k = 30;
    }
    public class Class1
    {
        int p1;

        public int P1
        {
            get { return p1; }
            set 
            {
                if (value > 100)
                {
                    throw new P1Exe("invalid p1");
                }
                p1 = value; 
            }
        }
    }
}
namespace PracticeDay5
{
    public partial class PC
    {
        public int l = 100;

        public void Display()
        {
            Console.WriteLine(i+" "+j+" "+k+" "+l);
        }
    }
}



