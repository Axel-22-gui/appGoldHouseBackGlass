using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ErrorResponse
    {
        public int codigo { get; set; }
        public string mensaje { get; set; }
        public Object cursor { get; set; }
    }
}
