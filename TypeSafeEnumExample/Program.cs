using System;

namespace TypeSafeEnumExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var enumeration in Role.GetAll())
            {
                Console.WriteLine($"{enumeration.Value} | {enumeration.Name}");
            }

            foreach (var enumeration in TypeSafeEnum<Role>.GetAll())
            {
                Console.WriteLine($"{enumeration.Value} | {enumeration.Name}");
            }
            
            Console.WriteLine(Role.HasAbsolutePower(Role.Admin));
            Console.WriteLine(Role.HasAbsolutePower(Role.Developer));
            Console.WriteLine(Role.HasAbsolutePower(Role.User));
            
            Console.WriteLine(Role.Admin.HasAbsolutePower());
            Console.WriteLine(Role.Developer.HasAbsolutePower());
            Console.WriteLine(Role.User.HasAbsolutePower());
        }
    }
}