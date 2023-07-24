using DataBaseCourseWork.TestDataGenerator;

namespace DataBaseCourseWork.ConsoleAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var generator = new Generator())
            {
                generator.Run();
            }
        }
    }
}
