using System;

namespace EFCoreWithoutDI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CreateDatabase();
        }

        // use only without migrations
        private static void CreateDatabase()
        {
            using (var context = new BooksContext())
            {
                bool created = context.Database.EnsureCreated();
                Console.WriteLine($"database created: {created}");
            }
        }
    }
}
