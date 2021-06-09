using System.Collections.Generic;
using System.Linq;

namespace AdventureWorks.Common.Security
{
    public static class SecurityPoliciesFactory
    {
        private static List<SecurityPolicy> _policies;

        public static List<SecurityPolicy> Policies =>
            _policies ??= new List<SecurityPolicy>{
new SecurityPolicy(SecurityPolicy.Administrator, "Administrators", new List<SecurityRequirement>{
SecurityRequirementsFactory.Permissions.FirstOrDefault(p => p.Name == SecurityRequirement.AdministratorTasks)
}),
new SecurityPolicy(SecurityPolicy.SampleSecurityPolicyForReads, "Sample Security Policy for Reads", new List<SecurityRequirement>{
SecurityRequirementsFactory.Permissions.FirstOrDefault(p => p.Name == SecurityRequirement.ReadTasks)
}),
new SecurityPolicy(SecurityPolicy.SampleSecurityPolicyForWrites, "Sample Security Policy for Writes", new List<SecurityRequirement>{
SecurityRequirementsFactory.Permissions.FirstOrDefault(p => p.Name == SecurityRequirement.WriteTasks)
})
            };
    }
}
