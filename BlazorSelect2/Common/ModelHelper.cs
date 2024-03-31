using System.Text;

namespace BlazorSelect2.Common;

public static class ModelHelper
{
    public static string AddSpacesToSentence(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return "";

        var textLength = text.Length;
        var newText = new StringBuilder(textLength * 2);
        newText.Append(text[0]);
        for (var i = 1; i < text.Length; i++)
        {
            if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                newText.Append(' ');
            newText.Append(text[i]);
        }

        return newText.ToString();
    }


    public static T ToEnum<T>(this string value)
    {
        try
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);
            throw new Exception(a.Message);

        }
    }

}