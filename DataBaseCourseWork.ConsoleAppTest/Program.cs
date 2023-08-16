using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DataBaseCourseWork.TestDataGenerator;

namespace DataBaseCourseWork.ConsoleAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var generator = new Generator())
            {
                generator.Run();
            }

            //string query =
            //    "INSERT INTO Providers(Name,Address,DirectorName,PhoneNumber,BankId,BankAccountNumber,INN) VALUES (@Name,@Address,@DirectorName,@PhoneNumber,@BankId,@BankAccountNumber,@INN) SELECT SCOPE_IDENTITY();";

            //string pattern = @"@(\w+)";
            //var regex = new Regex(pattern);
            //var matches = regex.Matches(query);

            //foreach (Match match in matches)
            //{
            //    string word = match.Groups[1].Value;
            //    Console.WriteLine(word);
            //}
        }
    }
}
