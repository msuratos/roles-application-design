using System;

using Enumtest.helpers;

namespace Enumtest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Roles tab application");

            var roles = new Guid[] 
                {
                    new Guid("12345678-9012-3456-7890-123456789012"),
                    new Guid("12345678-9012-3456-7890-123456789013") 
                };

            #region Testing GetValidTabsForRoles method in RoleEnumHelper class

            var tabs = RoleEnumHelper.GetValidTabsForRoles(roles);

            Console.WriteLine("User has access to the following tabs:");
            foreach(var tab in tabs)
            {                
                Console.WriteLine($"    {tab}");
            }

            #endregion

            #region Testing CanRoleAccessTab method in RoleEnumHelper class

            if (RoleEnumHelper.CanRoleAccessTab(roles[0], Tabs.Tab3))
                Console.WriteLine($"Role {roles[0]} can access {Tabs.Tab3}");
            else
                Console.WriteLine($"Role {roles[0]} can't access {Tabs.Tab3}");

            #endregion
        }
    }
}
