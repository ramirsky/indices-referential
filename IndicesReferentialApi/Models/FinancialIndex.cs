using System;
namespace IndicesReferentialApi.Models
{
    public class FinancialIndex
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string ReturnType { get; set; }
    }
}

