namespace AvanceradDotNetLabb4.Models
{
    public class InterestPerson
    {
        public int Id { get; set; }
        public Interest FkInterest { get; set; }
        public Person FkPerson { get; set; }
    }
}
