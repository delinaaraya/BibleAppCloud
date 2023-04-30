namespace FirstPageTry.Models
{
    public class BibleModel
    {
        public int Id { get; set; }
        public int Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Text { get; set; }

        public BibleModel(int id, int b, int c, int v, string t)
        {
            Id = id;
            Book = b;
            Chapter = c;
            Verse = v;
            Text = t;
        }
    }
}
