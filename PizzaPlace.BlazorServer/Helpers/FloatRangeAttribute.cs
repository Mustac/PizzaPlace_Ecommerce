using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.BlazorServer.Helpers
{
    public class FloatRangeAttribute : ValidationAttribute
    {
        public float Minimum { get; set; }
        public float Maximum { get; set; }

        public FloatRangeAttribute(float minimum, float maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        public override bool IsValid(object value)
        {
            try
            {
                if (value is float floatValue)
                {
                    return floatValue >= Minimum && floatValue <= Maximum;
                }
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
        }
    }
}
