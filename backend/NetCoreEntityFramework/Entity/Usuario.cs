using System;

namespace NetCoreEntityFramework.Entity
{
    public class Usuario
    {
        public Usuario(string userName)
        {
            UserName = userName;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}
