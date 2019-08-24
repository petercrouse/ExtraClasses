namespace ExtraClasses.Domain.Entities
{
    public class Booking
    {
        public long BookingId { get; set; }
        public long ExtraClassId { get; set; }
        public int StudentId { get; set; }
        public double BookingPrice { get; set; }

        public Student Student { get; set; }
        public ExtraClass ExtraClass { get; set; }
    }
}
