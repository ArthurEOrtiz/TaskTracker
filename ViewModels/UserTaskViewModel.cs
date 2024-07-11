namespace TaskTracker.ViewModels
{
  public class UserTaskViewModel
  {
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    //public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
    public string FormattedDueDate => DueDate.ToString("MM/dd/yyyy");
  }
}
