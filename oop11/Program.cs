using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayStr = { "June", "July", "May", "September", "November", "October", "December", "January", "February", "March", "April", "August" };
            var arrFind1 = arrayStr.Where(n => n.Length == 4).Select(n => n);
            var arrFind2 = arrayStr.Where(n => n == "June" || n == "July" || n == "December" || n == "January" || n == "February" || n == "August").Select(n => n);
            var arrFind3 = arrayStr.Where(n => n.Length >= 4 && n.Contains('u')).OrderBy(n => n).Select(n => n);

            Console.WriteLine("1 viborka");
            foreach (string s in arrFind1)
                Console.WriteLine(s);
            Console.WriteLine();
            Console.WriteLine("2 viborka");
            foreach (string s in arrFind2)
                Console.WriteLine(s);
            Console.WriteLine();
            Console.WriteLine("3 viborka");
            foreach (string s in arrFind3)
                Console.WriteLine(s);

            //2
            Circle one = new Circle(15, 20, 30);
            Circle two = new Circle();
            Circle Three = new Circle(50);
            Circle f = new Circle(30, 30, 5);
            List<Circle> circles = new List<Circle>();
            circles.Add(one);
            circles.Add(two);
            circles.Add(Three);
            circles.Add(f);

            int k;
            int b;
            Console.WriteLine("Uravnenie vigliadit kak k*x + b. Vvedite k");
            k = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Vvedite b");
            b = Int32.Parse(Console.ReadLine());

            var findCir1 = circles.Where(n => n.Y == k * n.X + b).Select(n => n);
            Console.WriteLine("Circle na zadannoi priamoi imeiut radius: ");
            foreach (Circle c in findCir1)
                Console.WriteLine(c.Radius);
            var findCirMin = circles.OrderBy(n => n.GetSquare(n.Radius)).Take(1);
            Console.WriteLine("Circle s min ploshiadiu imeet radius:");
            foreach (Circle c in findCirMin)
                Console.WriteLine(c.Radius);
            Console.WriteLine("Circle s max ploshiadiu imeet radius:");
            var findCirMax = circles.OrderByDescending(n => n.GetSquare(n.Radius)).Take(1);
            foreach (Circle c in findCirMax)
                Console.WriteLine(c.Radius);


            int r = 0;
            Console.WriteLine("Vvedite radius");
            r = Int32.Parse(Console.ReadLine());
            var findCirByRad = circles.Where(n => n.Radius == r).Select(n => n);
            Console.WriteLine("Circle zadannogo radiusa imeiut centre v tochke:");
            foreach (Circle c in findCirByRad)
                Console.WriteLine("(" + c.X + ", " + c.Y + ")");

            var findCirInFirst = circles.Where(n => n.X - n.Radius > 0 && n.Y - n.Radius > 0).Take(1);
            Console.WriteLine("1 v spiske circle, nahodiashiisia v 1 chetverti:");
            foreach (Circle c in findCirInFirst)
                Console.WriteLine("Centre circle v tochke (" + c.X + ", " + c.Y + "), radius = " + c.Radius);
            Console.WriteLine();

            var orderedBySquare = circles.OrderByDescending(n => n.GetSquare(n.Radius));
            Console.WriteLine("Ploshiadi uporiadochennih po ploshiadi circle:");
            foreach (Circle n in orderedBySquare)
                Console.WriteLine(n.GetSquare(n.Radius));
            Console.WriteLine();

            var my = circles.Except(circles.
                                Where(n => n.GetLength(n.Radius) < 200).
                                OrderBy(n => n.Radius).
                                ThenBy(n => n.Y).Union(circles.Take(1))).
                                Select(n => n.Radius);
            foreach (int n in my)
                Console.WriteLine(n);

            string[] names = { "Anna", "Max", "Olga", "Veronika" };
            int[] key = { 1, 4, 5, 7 };
            var sometype = names
            .Join(
            key,
            w => w.Length,
            q => q,
            (w, q) => new
            {
                id = w,
                length = string.Format("{0} ", q),
            });
            foreach (var item in sometype)
                Console.WriteLine(item);
            Console.ReadKey();
        }
    }
}