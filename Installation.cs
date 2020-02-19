using System;

namespace OrderByWithNull
{
    public class Installation
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public DateTime? InstallationDate { get; set; }
    }
}