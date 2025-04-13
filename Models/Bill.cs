namespace api.Models
{
    public class Bill
    {
        public string BillID { get; set; }=string.Empty;
        public DateTime CreatAt { get; set; }
        public bool StatusPayment { get; set; } = false;
    }
}