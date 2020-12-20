using System;
using System.Collections.Generic;
using System.Linq;

namespace Enumtest.helpers
{
    [Flags]
    internal enum Tabs { Empty = 0, Tab1 = 1, Tab2 = 2, Tab3 = 4 };

    internal static class RoleEnumHelper
    {
        private enum RolesEnum { Role1, Role2, Role3 };

        private static IDictionary<Guid, RolesEnum> staticRoles = new Dictionary<Guid, RolesEnum>() {
            { new Guid("12345678-9012-3456-7890-123456789012"), RolesEnum.Role1 },
            { new Guid("12345678-9012-3456-7890-123456789013"), RolesEnum.Role2}
        };

        private static IEnumerable<string> ConvertEnumToList(Tabs tabs) {
            return Enum.GetValues(typeof(Tabs)).Cast<Tabs>().Where(t => (tabs & t) != 0).Select(r => r.ToString());
        }

        private static Tabs GetTabsForRole(Guid role) {
            Tabs tabsEnum = Tabs.Empty;

            switch (staticRoles.Single(s => s.Key == role).Value)
            {
                case RolesEnum.Role1:
                    tabsEnum |= Tabs.Tab1 | Tabs.Tab2;
                    break;
                case RolesEnum.Role2:
                    tabsEnum |= Tabs.Tab1 | Tabs.Tab3;
                    break;
            }

            return tabsEnum;
        }

        internal static bool CanRoleAccessTab(Guid role, Tabs tabs) {
            //TODO: Double check this conditional logic
            if (GetTabsForRole(role) != tabs)
                return false;

            return true;
        }

        internal static ICollection<string> GetValidTabsForRoles(Guid[] roles)
        {
            ICollection<string> tabsList = new List<string>();
            Tabs tabsEnum = Tabs.Empty;

            foreach (var role in roles)
            {
                if (staticRoles.Any(a => a.Key == role))
                {
                    tabsEnum = GetTabsForRole(role);
                }
            }

            tabsList = ConvertEnumToList(tabsEnum).ToList();

            return tabsList;
        }
    }
}