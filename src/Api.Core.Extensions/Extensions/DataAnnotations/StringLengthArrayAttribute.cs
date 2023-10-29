using System.ComponentModel.DataAnnotations;

namespace Api.Core.Extensions.Extensions.DataAnnotations;
public class StringLengthArrayAttribute : StringLengthAttribute
{
    public StringLengthArrayAttribute(int maximumLength)
        : base(maximumLength) { }

    public override bool IsValid(object value)
    {

        if (value is null)
            return true;

        if (value is not string[])
            return false;

        foreach (var str in value as string[])
        {
            if (str.Length > MaximumLength || str.Length < MinimumLength)
                return false;
        }

        return true;
    }
}
