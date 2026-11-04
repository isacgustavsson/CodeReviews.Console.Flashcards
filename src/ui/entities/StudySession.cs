public class StudySession
{
    public int Id { get; set; }
    public int Score { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int StackId { get; set; }

    public Stack Stack { get; set; } = null!;
}