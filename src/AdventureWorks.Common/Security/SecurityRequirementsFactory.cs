using System.Collections.Generic;

namespace AdventureWorks.Common.Security
{
    public static class SecurityRequirementsFactory
    {
        private static List<SecurityRequirement> _permissions;

        public static List<SecurityRequirement> Permissions =>
            _permissions ??= new List<SecurityRequirement>
            {

            };
    }
}