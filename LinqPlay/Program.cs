using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqPlay
{
    public class Program
    {
        static void Main(string[] args)
        {
            string sentence = "I love cats";
            int[] numbers = { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };
            string[] catNames = { "Tomato", "Fennel", "Scout", "Chester", "Kitcat", "Oreo", "Jumpy", "Hairy" };

            // Simple linq example
            var getTheNumbers = from n in numbers
                                where n < 5
                                orderby n descending
                                select n;


            // This does the same thing, but with more code
            List<int> newNumbers = new List<int>();

            foreach(var num in numbers)
            {
                if (num < 5)
                {
                    newNumbers.Add(num);
                }
            }

            var oddNumbers = numbers.Where(n => n % 2 == 1);

            //System.Console.WriteLine(string.Join(", ", getTheNumbers));
            //System.Console.WriteLine(string.Join(", ", newNumbers));

            var catsWithAnO = from c in catNames
                              where (c.Contains("o")) && (c.Length < 5)
                              select c;

            var longCatNameO = from c in catNames
                               where c.Length > 5
                               where c.Contains("o")   //another way instead of using &&
                               select c;

            // System.Console.WriteLine(string.Join(", ", catsWithAnO));

            List<Person> people = new List<Person>()
            {
                new Person("Steve", 180, 70, Gender.Male),
                new Person("Sussie", 140, 30, Gender.Female),
                new Person("Alex", 185, 23, Gender.Male),
                new Person("Sarah", 135, 39, Gender.Female),
                new Person("Nikki", 110, 25, Gender.Female),
                new Person("Tim", 150, 60, Gender.Male),
                new Person("Mike", 170, 33, Gender.Male),
            };

            var fourCharPeople = from p in people
                                 where (p.Name.Length == 4)
                                 orderby p.Name, p.Weight
                                 select p;                  // could also select just their name
                                                            // using select p.Name

            //foreach (var item in fourCharPeople)
            //{
            //    Console.WriteLine($"Name: {item.Name}, Weight: {item.Weight}");
            //}

            var genderGroup = from p in people
                              group p by p.Gender;

            var simpleGrouping = people.Where(p => p.Weight > 140)
                                       .GroupBy(p => p.Gender);

            //foreach (var item in simpleGrouping)
            //{
            //    Console.WriteLine($"Gender: {item.Key}");

            //    foreach (var p in item)
            //    {
            //        Console.WriteLine($"{p.Name}");
            //    }
            //}

            var alphbeticalGroup = people.OrderBy(p => p.Name)
                                         .GroupBy(p => p.Name[0]);

            //foreach (var item in alphbeticalGroup)
            //{
            //    Console.WriteLine($"{item.Key}");

            //    foreach (var p in item)
            //    {
            //        Console.WriteLine($" {p.Name}");
            //    }
            //}

            var multiKey = people.GroupBy(p => new { p.Gender, p.Weight })
                                 .OrderBy(p => p.Count());

            foreach (var item in multiKey)
            {
                Console.WriteLine($"{item.Key}");

                foreach (var p in item)
                {
                    Console.WriteLine($" {p.Name}");
                }
            }


            List<Warrior> warriors = new List<Warrior>()
            {
                new Warrior() {Height = 100},
                new Warrior() {Height = 80},
                new Warrior() {Height = 100},
                new Warrior() {Height = 70}
            };

            List<int> shortWarriors = warriors.Where(h => h.Height <= 80)
                                        .Select(h => h.Height)
                                        .ToList();

            // warriors.ForEach(w => Console.WriteLine(w.Height));

            List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer("Steve", "Charleston", 25),
                new Buyer("Willie", "Johns Island", 24),
                new Buyer("Linda", "James Island", 23),
                new Buyer("Claire", "Mt. P", 26),
                new Buyer("Cindy", "Charleston", 28),
                new Buyer("Marshall", "Johns Island", 38),
                new Buyer("Floral", "James Island", 32),
                new Buyer("Wilson", "Mt. P", 24)
            };

            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier("Wendy", "Johns Island", 26),
                new Supplier("Jen", "Charleston", 25),
                new Supplier("Mike", "Mt. P", 24),
                new Supplier("Mel", "James Island", 23)
            };

            var innerJoin = suppliers.Join(buyers, s => s.District, b => b.District,
                (s, b) => new
                {
                    SupplierName = s.Name,
                    BuyerName = b.Name,
                    s.District
                });

            //foreach (var item in innerJoin)
            //{
            //    Console.WriteLine($"District: {item.District}, Supplier: {item.SupplierName}, Buyer: {item.BuyerName}");
            //}

            var innerJoin2 = from s in suppliers
                             orderby s.District
                             join b in buyers on s.District equals b.District
                             select new
                             {
                                 SupplierName = s.Name,
                                 BuyerName = b.Name,
                                 b.District
                             };
            //foreach (var item in innerJoin2)
            //{
            //    Console.WriteLine($"District: {item.District}, Supplier: {item.SupplierName}, Buyer: {item.BuyerName}");
            //}

            var compositeJoin = suppliers.Join(buyers,
                                               s => new { s.District, s.Age },
                                               b => new { b.District, b.Age },
                                               (s, b) => new
                                               {
                                                   SupplierName = s.Name,
                                                   BuyerName = b.Name,
                                                   s.District,
                                                   s.Age
                                                });

            object[] mix = { 1, "string", 'd', new List<int>() { 1, 2, 3, 4 }, "dd", new List<int>() { 5, 2, 3, 4}, 't', "Hello Dog", 1, 2, 3, 4 };

            var allIntegers = mix.OfType<int>();

        }


        private static int[] StringToIntArray(string array)
        {
            int[] arrayFromString = array.Split(' ')
                                         .Select(element => int.Parse(element))
                                         .ToArray();

            return arrayFromString;
        }
    }
}
