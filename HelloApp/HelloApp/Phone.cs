using SQLite;

namespace HelloApp
{
    public class Phone
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
    }

    public class Lang
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Language { get; set; }
    }
}
