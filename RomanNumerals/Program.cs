namespace RomanNumerals;

public class RomanNumeralConverter
{
    public static void Main()
    {
        Console.WriteLine("Enter a number to convert to Roman Numerals");
        var input = GetNumberFromUser();
        Console.WriteLine(ConvertNumberToRomanNumeral(input));
        Console.ReadLine();
    }

    private static string GetNumberFromUser()
    {
        var input = string.Empty;
        while (input == string.Empty)
        {
            input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out var result))
            {
                if (result is <= 3999 and >= 0)
                    continue;
                Console.WriteLine("Number out of bounds. Roman numerals only work in the range of 1 - 3,999");
                input = string.Empty;
            }
            else
            {
                Console.WriteLine("That is not a valid number, try again.");
                input = string.Empty;
            }
        }

        return input;
    }
    private static string ConvertNumberToRomanNumeral(string input)
    {
        var placeValue = input.ToCharArray().Reverse().ToArray();

        var output = new List<string>();

        for (var i = 0; i < placeValue.Length; i++)
        {
            switch (i)
            {
                case 0:
                    output.Add(ConvertSingleNumberToNumeral(int.Parse(placeValue[i].ToString()), "I", "V", "X"));
                    break;
                case 1:
                    output.Add(ConvertSingleNumberToNumeral(int.Parse(placeValue[i].ToString()), "X", "L", "C"));
                    break;
                case 2:
                    output.Add(ConvertSingleNumberToNumeral(int.Parse(placeValue[i].ToString()), "C", "D", "M"));
                    break;
                case 3:
                    output.Add(ConvertSingleNumberToNumeral(int.Parse(placeValue[i].ToString()), "M", null!, null!));
                    break;

            }
        }

        output.Reverse();

        return output.Aggregate(string.Empty, (current, number) => current + number);
    }

    private static string ConvertSingleNumberToNumeral(int number, string single, string middle, string upper)
    {
        return number switch
        {
            0 => string.Empty,
            1 => single,
            2 => single + single,
            3 => single + single + single,
            4 => single + middle,
            5 => middle,
            6 => middle + single,
            7 => middle + single + single,
            8 => middle + single + single + single,
            9 => single + upper,
            _ => null!
        };
    }
}