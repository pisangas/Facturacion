using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionWebApi.Models
{
    public class JSGridResponse <T> where T : class
    {
        public IEnumerable<T> data { get; set; }
        public int itemsCount { get; set; }
    }
}