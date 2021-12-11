using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.Model
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string Database { get; set; }
    }
}
