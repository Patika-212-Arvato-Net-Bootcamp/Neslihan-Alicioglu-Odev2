namespace ODEV_2.Models
{
    public class Bootcamp 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public int HowWeeks { get; set; }

        public string Teacher { get; set; }

        public bool IsDefault { get; set; }

        public List<User> Users { get; set; }

    }
}
