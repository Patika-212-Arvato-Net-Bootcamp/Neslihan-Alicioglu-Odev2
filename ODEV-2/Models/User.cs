namespace ODEV_2.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public bool IsDefault { get; set; }=false;  

        public bool IsConfirmBootcamp { get; set; }=false;

        public Bootcamp Bootcamp { get; set; }
    }
}
