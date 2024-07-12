using TaskTracker.Models;

namespace TaskTracker.ViewModels
{
  public class TaskFormViewModal
  {
    public UserTask Task { get; set; } = new UserTask();
    public string Action {  get; set; } = string.Empty;
    public string ButtonText { get; set; } = string.Empty;
    public string FormId { get; set; } = string.Empty;
  }
}
