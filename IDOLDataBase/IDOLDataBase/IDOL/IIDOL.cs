namespace IDOLDataBase
{
    public interface IIDOL
    {
        string Name { get; }
        string Phonetic { get; }
        string English { get; }
        int Age { get; }
        double Height { get; }
        double Weight { get; }
        string BirthDay { get; }
        string Blood { get; }
        string BirthPlace { get; }
        string Hobby { get; }
        string Constellation { get; }
        string Handedness { get; }
        string Color { get; }
    }
}
