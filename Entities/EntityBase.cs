using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Entities
{
    public class EntityBase
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
