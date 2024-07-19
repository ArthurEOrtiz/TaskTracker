using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskTracker.Attributes;

namespace TaskTracker.Models
{
  public class UserTask
  {
    // Properties
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter a title.")]
    [MaxLength(50, ErrorMessage = "Title must be less than 50 characters long.")]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500, ErrorMessage = "Description must be less than or equal to 500 characters.")]
    public string? Description { get; set; } = string.Empty;

    [Required]
    [FutureDate(ErrorMessage = "The date HAS gotta be in the future bro.")]
    public DateTime DueDate { get; set; } /*= DateTime.Now.AddDays(1);*/

    public UserTaskStatus Status { get; set; } = UserTaskStatus.NotStarted;

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; } = DateTime.Now;

    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Methods
    public void MarkAsCompleted()
    {
      Status = UserTaskStatus.Completed;
      UpdatedAt = DateTime.Now;
    }

    public void UpdateTask(string title, UserTaskStatus status, string description, DateTime dueDate)
    {
      Title = title;
      Description = description;
      DueDate = dueDate;
      Status = status;
      UpdatedAt = DateTime.Now;
    }

  }
}
