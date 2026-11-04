public class Stack
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    public List<Flashcard> FlashCards { get; set; } = [];
    public List<StudySession> StudySessions { get; set; } = [];

}