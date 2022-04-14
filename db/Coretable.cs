using System;
using System.Collections.Generic;

#nullable disable

namespace my.netCore2pm.db
{
    public partial class Coretable
    {
        internal int id;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string College { get; set; }
    }
}
