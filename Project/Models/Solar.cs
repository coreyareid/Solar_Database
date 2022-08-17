namespace Project.Models
{
    public class Solar
    {
        public Solar()
        {
        }

        public int BodyID { get; set; }
        public string EnglishName { get; set; }
        public string TypeOf { get; set; }
        public string DistanceFrom { get; set; }
        public string Gravity { get; set; }
        public string AverageTemp { get; set; }
        public int Moons { get; set; }
        public string DiscoveredBy { get; set; }
    }
}

