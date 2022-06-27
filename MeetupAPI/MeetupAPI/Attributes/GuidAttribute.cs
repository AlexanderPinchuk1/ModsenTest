using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.Attributes
{
    public class GuidAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            return value switch
            {
                Guid guid => guid != Guid.Empty,
                _ => false
            };
        }
    }
}
