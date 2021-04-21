using System.Collections.Generic;

namespace AdventureWorks.Common.Security
{
    public partial class SecurityPolicy
    {
        public const string Administrator = "Administrator";
        public const string SampleSecurityPolicyForReads = "SampleSecurityPolicyForReads";
        public const string SampleSecurityPolicyForWrites = "SampleSecurityPolicyForWrites";

        public string Name { get; set; }
        public string Description;
        public List<SecurityRequirement> Permissions { get; set; }

        public SecurityPolicy(string name)
        {

        }

        public SecurityPolicy(string name, string description, List<SecurityRequirement> permissions)
        {
            Description = description;
            Name = name;
            Permissions = permissions;
        }
    }
}