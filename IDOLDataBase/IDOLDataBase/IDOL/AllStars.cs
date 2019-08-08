namespace IDOLDataBase
{
    public class AllStar : IIDOL
    {
        public string Name { get; set; }
        public string Phonetic { get; set; }
        public string English { get; set; }
        public string Attribute { get; set; }
        public string Division { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Bust { get; set; }
        public double Waist { get; set; }
        public double Hip { get; set; }
        public string BirthDay { get; set; }
        public string Blood { get; set; }
        public string BirthPlace { get; set; }
        public string Hobby { get; set; }
        public string Talent { get; set; }
        public string Constellation { get; set; }
        public string Handedness { get; set; }
        public string Color { get; set; }

        public AllStar() { }

        public AllStar(AllStar data)
        {
            Name = data.Name;
            Phonetic = data.Phonetic;
            English = data.English;
            Attribute = data.Attribute;
            Division = data.Division;
            Type = data.Type;
            Age = data.Age;
            Height = data.Height;
            Weight = data.Weight;
            Bust = data.Bust;
            Waist = data.Waist;
            Hip = data.Hip;
            BirthDay = data.BirthDay;
            Blood = data.Blood;
            BirthPlace = data.BirthPlace;
            Hobby = data.Hobby;
            Talent = data.Talent;
            Constellation = data.Constellation;
            Handedness = data.Handedness;
            Color = data.Color;
        }
    }

}
