namespace AdventureWorks.Common.Security
{
    public partial class SecurityRequirement
    {


        public string Name { get; set; }
        public string Description { get; set; }

        public SecurityRequirement()
        {

        }

        public SecurityRequirement(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
