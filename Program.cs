using System;

using Enumtest.helpers;

namespace Enumtest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            foreach(var tab in RoleHelper.GetValidTabsForRoles(new string[] { "Role1", "Role2" }))
            {
                Console.WriteLine($"Tab: {tab}");
            }
        }
    }
}
