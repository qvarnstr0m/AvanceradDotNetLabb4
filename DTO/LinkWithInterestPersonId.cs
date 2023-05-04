namespace AvanceradDotNetLabb4.DTO
{
    public class LinkWithInterestPersonId
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int FkInterestPersonId { get; set; }
    }
}
