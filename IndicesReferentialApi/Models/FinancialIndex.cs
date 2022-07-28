namespace IndicesReferentialApi.Models
{
    public class FinancialIndex
    {
        public FinancialIndex(long id, string name, string currency, string returnType)
        {
            Id = id;
            Name = name;
            Currency = currency;
            ReturnType = returnType;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string ReturnType { get; set; }
    }
}

