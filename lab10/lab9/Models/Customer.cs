namespace Lab9.Models
{
    public class Customer
    {
        public int CustomerId { get; set; } 
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty; 
        public string EmailAddress { get; set; } = string.Empty; 
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
