using TaskTracker.Models;

namespace TaskTracker.ViewModels
{
  public class TaskFormViewModal
  {
    public UserTask UserTask { get; set; } = new UserTask();
    public string Action {  get; set; } = string.Empty;
    public string ButtonText { get; set; } = string.Empty;
    public string FormId { get; set; } = string.Empty;
  }
}
