namespace AdressBookApp.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public string Description { get; set; }
    }
}
