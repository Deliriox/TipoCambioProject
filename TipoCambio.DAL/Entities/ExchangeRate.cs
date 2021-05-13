using System;
using System.Collections.Generic;

#nullable disable

namespace TipoCambio.Entities
{
    public partial class ExchangeRate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Rate { get; set; }
        public DateTime WhenObtained { get; set; }
    }
}
