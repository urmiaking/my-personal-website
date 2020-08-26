using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Utilities
{
    public class Generator
    {
        public static string GenerationUniqueName() => Guid.NewGuid().ToString().Replace("-", "");
    }
}
