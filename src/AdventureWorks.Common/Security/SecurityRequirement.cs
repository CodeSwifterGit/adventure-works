namespace AdventureWorks.Common.Security
{
    public partial class SecurityRequirement
    {
        public const string AdministratorTasks = "AdministratorTasks";
        public const string ReadTasks = "ReadTasks";
        public const string WriteTasks = "WriteTasks";

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
