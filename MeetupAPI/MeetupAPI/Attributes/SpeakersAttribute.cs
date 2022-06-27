using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.Attributes
{
    public class SpeakersAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value == null)
            {
                return false;
            }

            var speakers = (List<string>)value;
            if (speakers == null)
            {
                return false;
            }

            if (speakers.Count == 0)
            {
                return false;
            }

            if(speakers.Any(item => item == null))
            {
                return false;
            }

            return true;
        }
    }
}
