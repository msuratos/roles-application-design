using System;

using Enumtest.helpers;

namespace Enumtest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Roles tab application");

            var tabs = RoleEnumHelper.GetValidTabsForRoles(new Guid[] 
                {
                    new Guid("12345678-9012-3456-7890-123456789012"),
                    new Guid("12345678-9012-3456-7890-123456789013") 
                });

            foreach(var tab in tabs)
            {
                Console.WriteLine($"Tab: {tab}");
            }
        }
    }
}
