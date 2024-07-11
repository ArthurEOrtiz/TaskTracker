﻿using System.ComponentModel.DataAnnotations;
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

    [Required]
    [MinLength(3, ErrorMessage = "Title must be at least 3 characters long.")]
    [MaxLength(50, ErrorMessage = "Title must be less than 50 characters long.")]
    public required string Title { get; set; } 

    [MaxLength(500, ErrorMessage = "Description must be less than or equal to 500 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [FutureDate(ErrorMessage = "Due date must be today or in the future.")]
    public DateTime DueDate { get; set; } = DateTime.Now.Date;

    public bool IsCompleted { get; set; } = false;

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; } = DateTime.Now;

    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Methods
    public void MarkAsCompleted()
    {
      IsCompleted = true;
      UpdatedAt = DateTime.Now;
    }

    public void UpdateTask(string title, string? description, DateTime dueDate)
    {
      Title = title;
      Description = description;
      DueDate = dueDate;
      UpdatedAt = DateTime.Now;
    }

  }
}
