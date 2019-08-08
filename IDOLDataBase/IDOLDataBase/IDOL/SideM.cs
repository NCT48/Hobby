namespace IDOLDataBase
{
    public class SideM : IIDOL
    {
        public string Name { get; set; }
        public string Phonetic { get; set; }
        public string English { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Foot { get; set; }
        public string BirthDay { get; set; }
        public string Blood { get; set; }
        public string BirthPlace { get; set; }
        public string Hobby { get; set; }
        public string Constellation { get; set; }
        public string Handedness { get; set; }
        public string Color { get; set; }

        public SideM() { }

        public SideM(SideM data)
        {
            Name = data.Name;
            Phonetic = data.Phonetic;
            English = data.English;
            Age = data.Age;
            Height = data.Height;
            Weight = data.Weight;
            Foot = data.Foot;
            BirthDay = data.BirthDay;
            Blood = data.Blood;
            BirthPlace = data.BirthPlace;
            Hobby = data.Hobby;
            Constellation = data.Constellation;
            Handedness = data.Handedness;
            Color = data.Color;
        }
    }

}
