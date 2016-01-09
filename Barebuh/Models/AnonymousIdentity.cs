using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barebuh.Models
{
    public class AnonymousIdentity : CustomIdentity
    {
        public AnonymousIdentity()
            : base(String.Empty, String.Empty, new string[] {})
        {
            
        }
    }
}
