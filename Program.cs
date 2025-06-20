using System.Collections;
namespace Practice
{
    internal class Program
    {
        public delegate void Del1(); // create the delegate
        public delegate int Del2(int a, int b);
        static void Main(string[] args) //generic type
        {
            IntegerStack stack = new IntegerStack(4);
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());

            StringStack stack1 = new StringStack(3);
            stack1.Push("faisalkhan");
            stack1.Push("shahidkhan");
            stack1.Push("fatimakhan");
            //stack1.Push("saif"); //overflow

            //Console.WriteLine(stack1.Pop());
            //Console.WriteLine(stack1.Pop());
            //Console.WriteLine(stack1.Pop());
            //Console.WriteLine(stack1.Pop()); // underflow

            MyStack<int> stack2 = new MyStack<int>(5);

            stack2.Push(1);
            stack2.Push(2);
            stack2.Push(3);
            stack2.Push(4);
            stack2.Push(5);

            //Console.WriteLine(stack2.Pop());
            //Console.WriteLine(stack2.Pop());
            //Console.WriteLine(stack2.Pop());

            MyStack<string> stack3 = new MyStack<string>(5);

            stack3.Push("faisalkhan");
            stack3.Push("shahidkhan");
            stack3.Push("fatima");
            stack3.Push("sara");
            stack3.Push("ammi");

            //Console.WriteLine(stack3.Pop());
            //Console.WriteLine(stack3.Pop());
            //Console.WriteLine(stack3.Pop());


        }

        static void Main2() // collection
        {
            ArrayList al = new ArrayList();
            al.Add("faisalkhan");
            al.Add(25);
            al.Add(2599.0);
            al.Add(true);
            al.Insert(0, "Mohammad");
            //al.RemoveAt(1);
            //al.Remove("Mohammad");

            ArrayList al1 = new ArrayList();
            al1.Add(10);
            al1.Add(20);
            //al.AddRange(al1);
            //al.InsertRange(0, al1);

            ArrayList al2 = new ArrayList();
            al2 = (ArrayList)al.Clone();

            Console.WriteLine(al.Contains("Faisalkhan")); // false -> F capital
            //foreach (object elemet in al)
            //{
            //    Console.WriteLine(elemet);
            //}
            Console.WriteLine(al.Count + " " + al.Capacity);
            al.TrimToSize();
            Console.WriteLine(al.Count + " " + al.Capacity);
        }

        static void Main3() //collection
        {
            //Hashtable objDictionary = new Hashtable();
            SortedList objDictionary = new SortedList();
            objDictionary.Add(50, "Isha");
            objDictionary.Add(30, "Shriram");
            objDictionary.Add(10, "Shubham");
            objDictionary.Add(20, "Rohan");
            objDictionary.Add(40, "Ritik");

            objDictionary[60] = "Vikram";
            objDictionary[50] = "changed value";

            //objDictionary.Remove(60); //key
            //objDictionary.RemoveAt(0); //index

            //foreach (DictionaryEntry item in objDictionary)
            //{
            //    Console.WriteLine(item.Key);
            //    Console.WriteLine(item.Value);
            //}


            //Console.WriteLine(objDictionary.GetByIndex(0)); //value at index 0
            //Console.WriteLine(objDictionary.GetKey(2));//key at index 0
            IList keys = objDictionary.GetKeyList();
            //foreach (object key in keys)
            //{
            //    Console.WriteLine(key);
            //}
            IList value = objDictionary.GetValueList();
            //foreach (object v in value)
            //{
            //    Console.WriteLine(v);
            //}
            //objDictionary.IndexOfKey(key);
            //objDictionary.IndexOfValue(value);

            ICollection keys2 = objDictionary.Keys;
            foreach (object key in keys2)
            {
                Console.WriteLine(key);
            }
            ICollection values2 = objDictionary.Values;

            //objDictionary.SetByIndex(index, value);

        }

        static void Main4() //delegate
        {
            //Del1 d1 = new Del1(Display);
            //d1();
            //Del1 d2 = new Del1(Show);
            //d2();
            //short synatx
            //Del1 d3 = Display;
            //d3();
            //Del1 d4 = Show;
            //d4();

            Del1? d5 = Display;
            //d5();
            d5 += Show; // MultiCastDelegate
            d5 += Display;
            d5 += Show;
            d5 -= Show;
            d5 -= Show;
            d5 -= Display;
            d5 -= Display;
            if (d5 != null)
                d5();
            else
                Console.WriteLine("null value");
        }

        static void Main5() //delegate
        {
            //create object of the Delegate
            Del2 d2 = Add;
            int res = d2(10, 20);

            d2 += Sub;
            res = d2(100, 50);

            d2 += Add;
            res = d2(200, 100);
            

            Class1 c = new Class1();
            d2 += c.Mul; // non static method of the other class
            res = d2(2, 3);

            d2 += Class1.Div; // static method of other class
            res = d2(10, 5);
            Console.WriteLine(res);
        }

        static void Main6() // call multiple method with one delegate
        {
            Del1 d1 = (Del1)Delegate.Combine(new Del1(Display), new Del1(Show), new Del1(Display), new Del1(Show));
            //d1(); // multiple method call with one delegate;

            Console.WriteLine(MathOperation(Add, 100,200));
            Console.WriteLine(MathOperation(Sub, 50,20));

        }

        static void Main7() // inbuilt delegate
        {
            //void with zero paramter 
            Action a1 = Display;
            a1();
            Action a2 = Show;
            a2();

            // void with paramter
            Action<string, string> a3 = Display;
            a3("faisalkhan", "pathan");

            // non void RT and parameter
            Func<int, int, int> a4 = Add;
            Console.WriteLine(a4(90, 90));

            Func<int, bool> a5 = IsEven;
            Console.WriteLine(a5(110));

            // non void with one RT bool
            Predicate<int> a6 = IsEven;
            Console.WriteLine(a6(19));
            
        }

        static void Main8() // anonymouse method
        {
            Func<int, int, int> a1 = delegate(int a, int b)
             {
                return a + b;
             };
            Console.WriteLine(a1(999, 1));

            Action a2 = delegate ()
            {
                Console.WriteLine("Display");
            };
            a2();

            Action a3 = delegate ()
            {
                Console.WriteLine("Show");
            };
            a3();

            Func<int, int, int> a4 = delegate (int a, int b)
            {
                return a - b;
            };
            Console.WriteLine(a4(500,500));

            Func<string, string, string> a5 = delegate (string a, string b)
            {
                return a + " " + b;
            };
            Console.WriteLine(a5("shahidkhan", "pathan"));

            Func<string> a6 = delegate ()
            {
                return DateTime.Now.ToLongDateString()+" "+ DateTime.Now.ToLongTimeString();
            };
            Console.WriteLine(a6());

            Func<int, bool> a7 = delegate (int a)
            {
                return a % 2 == 0;
            };
            Console.WriteLine(a7(75));

            Predicate<int> a8 = delegate (int a)
            {
                return a % 2 == 0;
            };
            Console.WriteLine(a8(99));
        }

        static void Main9() // lamda function
        {
            Action a1 = () => Console.WriteLine("Display"); a1();
            Action a2 = () => Console.WriteLine("Show"); a2();
            Func<int, int, int> a3 = (a, b) => a + b; Console.WriteLine(a3(6,6));
            Func<int, int, int> a4 = (a, b) => a - b; Console.WriteLine(a4(16,6));
            Func<string, string, string> a5 = (a,b) =>  a+" " + b;  Console.WriteLine(a5("sarakhan" ,"pathan"));
            Func<string> a6 = () => DateTime.Now.ToLongTimeString(); Console.WriteLine(a6());
            Func<int, bool> a7 = a => a % 2 == 0; Console.WriteLine(a7(20));
            Predicate<int> a8 = a => a % 2 == 0; Console.WriteLine(a8(100));

        }
        static void Display()
        {
            Console.WriteLine("Display");
        }
        static void Show()
        {
            Console.WriteLine("Show");
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

         static int Sub(int a, int b)
        {
            return a - b;
        }

        // pass the function in function and call with delegate
        static int MathOperation(Del2 d2, int a, int b)
        {
            return d2(a, b);
        }

        static void Display(string s1, string s2)
        {
            Console.WriteLine(s1 +" "+s2);
        }

        static string GetTime()
        {
            return DateTime.Now.ToLongTimeString();
        }

        static bool IsEven(int a)
        {
            return a % 2 == 0;
        }

    }

     
    class IntegerStack
    {
        int[] arr;

        public IntegerStack(int size)
        {
            arr = new int[size];
        }
        int pos = -1;

        public void Push(int element)
        {
            if (pos != (arr.Length - 1))
            {
                arr[++pos] = element;
            }
            else
            {
                Console.WriteLine("stack overflow");
            }
        }

        public int Pop()
        {
            if (pos == -1)
            {
                Console.WriteLine("stack under flow");
                return -1;
            }
            else
            {
                return arr[pos--];
            }
        }
    }

    class StringStack
    {
        string[] arr;

        public StringStack(int size)
        {
            arr = new string[size];
        }
        int pos = -1;

        public void Push(string element)
        {
            if (pos != (arr.Length - 1))
            {
                arr[++pos] = element;
            }
            else
            {
                Console.WriteLine("stack overflow");
            }
        }

        public string Pop()
        {
            if (pos == -1)
            {
                //Console.WriteLine("stack under flow");
                return "stack under flow";
            }
            else
            {
                return arr[pos--];
            }
        }
    }

    class MyStack<T>
    {
        T[] arr;

        public MyStack(int size)
        {
            arr = new T[size];
        }
        int pos = -1;

        public void Push(T element)
        {
            if (pos != (arr.Length - 1))
            {
                arr[++pos] = element;
            }
            else
            {
                Console.WriteLine("stack overflow");
            }
        }

        public T Pop()
        {
            if (pos == -1)
            {
                //Console.WriteLine("stack under flow");
                //return -1;
                throw new Exception("stack underflow");
            }
            else
            {
                return arr[pos--];
            }
        }
    }

    public class Class1
    {
        public int Mul(int x, int y)
        {
            return x * y;
        }

        public static int Div(int x, int y)
        {
            return x / y;
        }
    }
    
}

    
