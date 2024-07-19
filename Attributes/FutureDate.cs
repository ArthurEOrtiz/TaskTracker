using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Attributes
{
  /// <summary>
  /// The FutureDate class is a custom validation attribute that ensures a
  /// DateTime property is set to today or a future date.
  /// </summary>
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public class FutureDate : ValidationAttribute, IClientModelValidator
  {
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
      if (value is DateTime dateValue && dateValue >= DateTime.Today)
        return ValidationResult.Success!;
      
      return new ValidationResult("Due date must be in the future.");
    }

    /// <summary>
    /// The AddValidation method is part of the IClientModelValidator interface 
    /// implementation. It's responsible for adding the necessary data attributes 
    /// to the HTML elements rendered for the model property in the view, enabling 
    /// client-side validation. The method first ensures the context parameter is 
    /// not null, then calls a private helper method MergeAttribute twice to add 
    /// two attributes: data-val set to "true" to enable validation, and 
    /// data-val-futuredate set to a custom error message or a default "Invalid date."
    /// message if no custom message is provided.
    /// </summary>
    /// <param name="context">A <see cref="ClientModelValidationContext"/> context for model validation, containing attributes to be modified for client-side validation.</param>
    public void AddValidation(ClientModelValidationContext context)
    {
      ArgumentNullException.ThrowIfNull(context); // Throws ArgumentNullException if context is null

      MergeAttribute(context.Attributes, "data-val", "true"); // This will enable client-side validation by  setting the data-val attribute to true which will  trigger the validation process on the client side
      MergeAttribute(context.Attributes, "data-val-futuredate", ErrorMessage ?? "Invalid date."); // This will set the data-val-futuredate attribute to the custom error message or a default message if no custom message is provided
    }

    /// <summary>
    /// The MergeAttribute private method is a utility function that adds a key-value 
    /// pair to a dictionary representing HTML attributes if the key does not already 
    /// exist in the dictionary. If the key is new, it adds the key-value pair and 
    /// returns true; if the key already exists, it does nothing and returns false. 
    /// This method ensures that attributes are not duplicated and that the most 
    /// relevant validation messages are displayed to the user.
    /// </summary>
    /// <param name="attributes">An <see cref="IDictionary{string, string}"/> that represents 
    ///  a collection of key/value pairs. This dictionary is where the new attribute will be 
    ///  added if the key does not already exist in the dictionary</param>
    /// <param name="key">
    ///   A <see cref="string"/> that represents the key of the attribute to 
    ///   be added to the attribute dictionary.
    /// </param>
    /// <param name="value">
    ///   A <see cref="string"/> that represents the value associated with they key to be added
    ///   to the attributes dictionary. This value is added only if the key does not already exist
    ///   in the dictionary.
    /// </param>
    /// <returns>
    ///   A <see cref="bool"/> indicating whether a new key/value pair was successfully added to the
    ///   dictionary.
    /// </returns>
    private static bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
    {
      if (attributes.ContainsKey(key))
      {
        return false;
      }

      attributes.Add(key, value);
      return true;
    }
  }
}
