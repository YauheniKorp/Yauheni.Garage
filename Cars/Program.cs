using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Cars

{
    class Program
    {
        static void Main(string[] args)
        {

            Display();
            Console.ReadLine();

        }

        public static void Create()
        {
            var connectionString = "Data Source=DESKTOP-CLNKJLP\\SQLEXPRESS;Database=Cars;Trusted_Connection=False;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection())
            {
                Console.Write("Connecting to SQL Server ... ");
                conn.ConnectionString = connectionString;
                conn.Open();
                Console.Write("Enter Id ");
                var Id = Console.ReadLine();
                Console.Write("Enter Name ");
                var Name = Console.ReadLine();
                Console.Write("Enter Model ");
                var Model = Console.ReadLine();
                Random random = new Random();
                int Year = random.Next(2009, 2020); 
                var command = new SqlCommand("insert into dbo.Auto(Id, Name, Model, Year) values (@Id, @Name, @Model, @Year)", conn);
                Console.WriteLine($"{Id}, {Name}, {Model}, {Year}");
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Model", Model);
                command.Parameters.AddWithValue("@Year", Year);
                command.ExecuteNonQuery();
                Console.WriteLine("Done.");
                Console.WriteLine("Do you want to create one more? Enter yes or no: ");
                string Decision = Convert.ToString(Console.ReadLine());
                Decision.ToLower();
                if (Decision == "yes")
                {
                    Create();
                }
                else
                {
                    Console.WriteLine($"GoodBye");
                    return;
                }
            }
        }

        private static void Delete()
        {
            var connectionString = "Data Source=DESKTOP-CLNKJLP\\SQLEXPRESS;Database=Cars;Trusted_Connection=False;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection())
            {
                Console.Write("Connecting to SQL Server ...\n");
                conn.ConnectionString = connectionString;
                conn.Open();
                Console.WriteLine($"Do you want to delete string? Enter yes or no ");
                string Decision = Convert.ToString(Console.ReadLine());
                Decision.ToLower();
                if (Decision == "yes")
                {
                    Console.Write("Enter Id which you want to delete ");
                    var Id = Console.ReadLine();
                    var command = new SqlCommand("delete dbo.Auto where Id=@Id", conn);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done.");
                    Console.WriteLine("Do you want to delete one more? Enter yes or no: ");
                    string Decision1 = Convert.ToString(Console.ReadLine());
                    Decision1.ToLower();
                    if (Decision1 == "yes")
                    {
                        Delete();
                    }
                    else
                    {
                        Console.WriteLine($"GoodBye");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"GoodBye");
                    return;
                }
                Console.ReadLine();
            }
        }

        private static void Update()
        {
            var connectionString = "Data Source=DESKTOP-CLNKJLP\\SQLEXPRESS;Database=Cars;Trusted_Connection=False;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection())
            {
                Console.Write("Connecting to SQL Server ...\n");
                conn.ConnectionString = connectionString;
                conn.Open();
                Console.Write("Enter Id which you want to update ");
                var Id = Console.ReadLine();
                Console.Write("Enter new Name ");
                var Name = Console.ReadLine();
                Console.Write("Enter new Model ");
                var Model = Console.ReadLine();
                Console.Write("Enter new Year ");
                var Year = Console.ReadLine();
                var command = new SqlCommand("update dbo.Auto set Name=@name, Model=@Model, Year=@Year where Id=@Id", conn);
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Model", Model);
                command.Parameters.AddWithValue("@Year", Year);
                command.ExecuteNonQuery();
                Console.WriteLine("Done.");
            }
        }

        private static void Display()
        {
            var connectionString = "Data Source=DESKTOP-CLNKJLP\\SQLEXPRESS;Database=Cars;Trusted_Connection=False;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection())
            {
                Console.Write("Connecting to SQL Server ... \n");
                conn.ConnectionString = connectionString;
                conn.Open();
                using (SqlCommand command = new SqlCommand("SELECT Id, Name, Model, Year FROM dbo.Auto GROUP BY Id, Name, Model, Year order by Name ", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.WriteLine(reader.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        private static void Sorting()
        {
            var connectionString = "Data Source=DESKTOP-CLNKJLP\\SQLEXPRESS;Database=Cars;Trusted_Connection=False;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection())
            {
                Console.Write("Connecting to SQL Server ... ");
                conn.ConnectionString = connectionString;
                conn.Open();
                var command = new SqlCommand("select Id from dbo.Auto order by Id", conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Done.");

            }

        }
    }
}
