using System;
using System.Collections.Generic;
using System.Linq;

namespace Enumtest.helpers
{
    #region Enum Role Helper
    [Flags]
    internal enum Roles { Empty = 0, Role1 = 1, Role2 = 2, Role3 = 4 };

    [Flags]
    internal enum Tabs { Empty = 0, Tab1 = 1, Tab2 = 2, Tab3 = 4 };

    internal static class RoleEnumHelper
    {
        internal static ICollection<string> GetValidTabsForRoles(string[] roles)
        {
            var allTabsEnum = Enum.GetValues(typeof(Tabs)).Cast<Tabs>().ToList();
            ICollection<string> tabsList = new List<string>();
            Tabs tabsEnum = Tabs.Empty;

            foreach (var role in roles)
            {
                if (Enum.TryParse<Roles>(role, out Roles roleEnum))
                {
                    switch (roleEnum)
                    {
                        case Roles.Role1:
                            tabsEnum |= Tabs.Tab1 | Tabs.Tab2;
                            break;
                        case Roles.Role2:
                            tabsEnum |= Tabs.Tab1 | Tabs.Tab3;
                            break;
                    }
                }
            }

            tabsList = ConvertEnumToList(tabsEnum);

            return tabsList;
        }

        private static IList<string> ConvertEnumToList(Tabs tabs) {
            var tabsList = new List<string>();

            foreach (var tab in Enum.GetValues<Tabs>())
            {
                if ((tab & tabs) != 0) tabsList.Add(tab.ToString());
            }

            return tabsList;
        }
    }
    #endregion

    #region Struct Role Helper
    internal struct RoleStruct
    {
        internal const string Role1 = "l;kjsdf8";
        internal const string Role2 = "l;kjsdf8";
        internal const string Role3 = "l;kjsdf8";
    }

    internal static class RoleStructHelper 
    {
        internal static ICollection<string> GetValidTabsForRole(string[] roles)
        {
            foreach (var role in roles)
            {
                
            }
        }
    }
    #endregion
}