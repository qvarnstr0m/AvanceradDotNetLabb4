namespace AvanceradDotNetLabb4.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public InterestPerson FkInterestPerson { get; set; }
    }
}
