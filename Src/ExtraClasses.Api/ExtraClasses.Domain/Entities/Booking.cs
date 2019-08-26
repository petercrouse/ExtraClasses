namespace ExtraClasses.Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int ExtraClassId { get; set; }
        public int StudentId { get; set; }
        public double BookingPrice { get; set; }

        public Student Student { get; set; }
        public ExtraClass ExtraClass { get; set; }
    }
}
