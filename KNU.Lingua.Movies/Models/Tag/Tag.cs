
namespace KNU.Lingua.Movies.Models.Tag
{
    public class Tag
    {
        public Tag(string name, int count, double normCount)
        {
            this.Name = name;
            this.OccurencesCount = count;
            this.NormCount = normCount;
        }

        public string Name { get; set; }
        public int OccurencesCount { get; set; }
        public double NormCount { get; set; }
    }
}
