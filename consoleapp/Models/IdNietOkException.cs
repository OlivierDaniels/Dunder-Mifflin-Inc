using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class IdNietOkException:Exception
    {
        public IdNietOkException() : base("De nummer is niet ok") 
        { 
        
        }
    }
}
