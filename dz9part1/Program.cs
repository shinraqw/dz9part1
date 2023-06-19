namespace dz9part1
{
    delegate bool Delegate1(int number);

    internal class Program
    {
        static void Main(string[] args)
        {
            int a;
            do
            {
                Console.Write("Enter task : ");
                a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        int[] array = new int[10];
                        Random random = new Random();
                        Console.Write("Array: ");
                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i] = random.Next(100);
                            Console.Write(array[i] + " ");
                        }

                        Delegate1 evenFilter = Even;
                        int[] evenNumbers = Sort(array, evenFilter);
                        Console.WriteLine("\nEven numbers:");
                        Show(evenNumbers);

                        Delegate1 oddFilter = Odd;
                        int[] oddNumbers = Sort(array, oddFilter);
                        Console.WriteLine("Odd numbers:");
                        Show(oddNumbers);

                        Delegate1 primeFilter = Prime;
                        int[] primeNumbers = Sort(array, primeFilter);
                        Console.WriteLine("Prime numbers:");
                        Show(primeNumbers);

                        Delegate1 fibonacciFilter = Fib;
                        int[] fibonacciNumbers = Sort(array, fibonacciFilter);
                        Console.WriteLine("Fibonacci numbers:");
                        Show(fibonacciNumbers);
                        break;
                    case 2:
                        Action time = Time;
                        Action date = Date;
                        Action day = Day;
                        time();
                        date();
                        day();
                        Predicate<double[]> triangle = Triangle;
                        Console.Write(" size 1 of triangle: ");
                        double s1 = int.Parse(Console.ReadLine());
                        Console.Write(" size 2 of triangle: ");
                        double s2 = int.Parse(Console.ReadLine());
                        Console.Write(" size 3 of triangle: ");
                        double s3 = int.Parse(Console.ReadLine());
                        double[] sides = { s1, s2, s3 };
                        if (triangle(sides))
                        {
                            double area1 = TriangleArea(sides);
                            Console.WriteLine($"Triangle area: {area1}");
                        }
                        Console.Write("width of rectangle: ");
                        double width = int.Parse(Console.ReadLine());
                        Console.Write("height of rectangle: ");
                        double height = int.Parse(Console.ReadLine());
                        double area2 = RectangleArea(width, height);
                        Console.WriteLine($"Rectangle area: {area2}");
                        break;
                    case 3:
                        int num, pin, bal, num1, num2, num3;
                        string PIB, enddate;
                        Console.Write(" number card: ");
                        num = int.Parse(Console.ReadLine());
                        Console.Write(" PIB: ");
                        PIB = Console.ReadLine();
                        Console.Write("end date card: ");
                        enddate = Console.ReadLine();
                        Console.Write(" pin card: ");
                        pin = int.Parse(Console.ReadLine());
                        Console.Write(" start balance: ");
                        bal = int.Parse(Console.ReadLine());
                        CreditCard myCard = new CreditCard();
                        myCard.CardNumber = num;
                        myCard.CardOwnerName = PIB;
                        myCard.ExpirationDate = enddate;
                        myCard.Pin = pin;
                        myCard.CreditLimit = 5000;
                        myCard.Balance = bal;
                        myCard.Output();
                        do
                        {
                            Console.Write("\nMenu:1 - Add  2 - Spend  3 - Show balanc 4 - Start credit 5 - Change PIN 0 - Exit  ");
                            int choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 0:
                                    Environment.Exit(0);
                                    break;
                                case 1:
                                    Console.Write("Enter value of money to add: ");
                                    num1 = int.Parse(Console.ReadLine());
                                    myCard.AddMoney(num1);
                                    Console.WriteLine("Your balance: " + myCard.Balance);
                                    break;
                                case 2:
                                    Console.Write("Enter value of money to spend: ");
                                    num2 = int.Parse(Console.ReadLine());
                                    myCard.SpendMoney(num2);
                                    Console.WriteLine("Your balance: " + myCard.Balance);
                                    break;
                                case 3:
                                    Console.WriteLine("Your balance: " + myCard.Balance);
                                    break;
                                case 4:
                                    myCard.StartCredit();
                                    break;
                                case 5:
                                    Console.Write("Enter new pin: ");
                                    num3 = int.Parse(Console.ReadLine());
                                    myCard.ChangePin(num3);
                                    myCard.Output();
                                    break;
                                default:
                                    Console.WriteLine("Error!");
                                    break;
                            }
                        } while (true);
                        break;
                    default:
                        Console.WriteLine("Error!");
                        break;
                }
            } while (a < 1 || a > 3);
        }

        //Task 1
        static bool Even(int number)
        {
            return number % 2 == 0;
        }

        static bool Odd(int number)
        {
            return number % 2 != 0;
        }

        static bool Prime(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        static bool Fib(int number)
        {
            if (number == 0 || number == 1)
                return true;
            int a = 0;
            int b = 1;
            int c = a + b;
            while (c <= number)
            {
                if (c == number)
                    return true;
                a = b;
                b = c;
                c = a + b;
            }
            return false;
        }

        static int[] Sort(int[] array, Delegate1 filter)
        {
            int[] result = new int[array.Length];
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (filter(array[i]))
                {
                    result[count] = array[i];
                    count++;
                }
            }
            Array.Resize(ref result, count);
            return result;
        }

        static void Show(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }




        //Task 2
        static void Time()
        {
            Console.WriteLine($"Time= {DateTime.Now.ToShortTimeString()}");
        }

        static void Date()
        {
            Console.WriteLine($"Date= {DateTime.Now.ToShortDateString()}");
        }

        static void Day()
        {
            Console.WriteLine($"Day of week= {DateTime.Now.DayOfWeek}");
        }

        static bool Triangle(double[] sides)
        {
            double a = sides[0];
            double b = sides[1];
            double c = sides[2];

            return a + b > c && b + c > a && c + a > b;
        }

        static double TriangleArea(double[] sides)
        {
            double a = sides[0];
            double b = sides[1];
            double c = sides[2];

            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        static double RectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}