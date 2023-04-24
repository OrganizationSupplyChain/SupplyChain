namespace Invoice_Discounting.Models
{
    public class ReverseFactoringContractInvoice
    {
        public ContractInvoice ContractInvoice { get; set; }
        public string ContractName { get; set; }
        public string ContractNumber { get; set; }
        public decimal ContractAmount { get; set; }
        public int PaymentTenor { get; set; }
    }
}
