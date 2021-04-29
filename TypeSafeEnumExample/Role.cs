namespace TypeSafeEnumExample
{
    public class Role : TypeSafeEnum<Role>
    {
        public static readonly Role Admin = new Role(1, nameof(Admin));
        public static readonly Role Developer = new Role(2, nameof(Developer));
        public static readonly Role User = new Role(3, nameof(User));
            
        private Role(int value, string name) : base(value, name) { }

        public static bool HasAbsolutePower(Role role)
        {
            return role.Value == Admin.Value;
        }

        public bool HasAbsolutePower()
        {
            return HasAbsolutePower(this);
        }
    }
}