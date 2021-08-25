namespace dotnet_proj01
{
    public class Serie : BaseEntity
    {
        private Genre Genre {get; set; }
        private string Title {get; set; }
        private string Description {get; set; }
        private int Year {get; set; }
        private bool Deleted {get; set; }

        public Serie (int id, Genre genre, string title, string description, int year) {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString() {
            string ret = "";
            ret += "Genre: "+this.Genre + "\n";
            ret += "Title: "+this.Title + "\n";
            ret += "Description: "+this.Description + "\n";
            ret += "Year: "+this.Year + "\n";
            ret += "isDeleted: "+this.Deleted;
            return ret;
        }

        public string GetTitle() => this.Title;
        public int GetId() => this.Id;
        public bool GetDeleted() => this.Deleted;
        public void Delete() {
            this.Deleted = true;
        }
    }
}