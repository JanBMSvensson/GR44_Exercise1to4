using static System.Console;

ConsoleKeyInfo MenuInput;

do
{
    WriteLine();
    WriteLine("MAIN MENU");
    WriteLine("Press key to a run exercise (1-4) or ESC to exit: ");

    MenuInput = Console.ReadKey(true);

    switch (MenuInput.Key)
    {
        default:
            WriteLine($"The '{MenuInput.KeyChar}'-key is not a valid option!");
            break;

        case ConsoleKey.D1:
        case ConsoleKey.NumPad1:
            Exercise01();
            break;

        case ConsoleKey.D2:
        case ConsoleKey.NumPad2:
            Exercise02();
            break;

        case ConsoleKey.D3:
        case ConsoleKey.NumPad3:
            Exercise03();
            break;

        case ConsoleKey.D4:
        case ConsoleKey.NumPad4:
            Exercise04();
            break;

        case ConsoleKey.Escape:
            break;

    }

} 
while (MenuInput.Key != ConsoleKey.Escape);





void Exercise01()
{
    WriteLine("Exercise 01");

    WriteLine(GetNumericInputFromUser(1M, 10M).HasValue ? "Valid" : "Invalid");
}

void Exercise02()
{
    WriteLine("Exercise 02");

    while (!GetNumericInputFromUser(1M,10M).HasValue) 
    {
        WriteLine("Invalid");
    }

    WriteLine("Valid");
}

void Exercise03()
{
    WriteLine("Exercise 03");

    UInt16? Width = GetImageSizeFromUser("width", 16384);
    UInt16? Height = GetImageSizeFromUser("height");

    if (Width.HasValue && Height.HasValue)
    {
        if (Width.Value > Height.Value)
        {
            WriteLine("Landscape");
        }
        else if (Width.Value < Height.Value) {
            WriteLine("Portrait");
        }
        else
        {
            WriteLine("Neither Landscape nor Portrait");
        }
    }
    else
    {
        WriteLine("Invalid input");
    }
}

void Exercise04()
{
    WriteLine("Exercise 04");

    byte? SpeedLimit = GetAbsoluteSpeedFromUser("speed limit");
    if (!SpeedLimit.HasValue)
    {
        WriteLine("Not valid");
        return;
    }
    byte? SpeedOfCar;

    do
    {
        SpeedOfCar = GetAbsoluteSpeedFromUser("speed of car");
        if (SpeedOfCar.HasValue)
        {
            if (SpeedOfCar.Value > SpeedLimit.Value)
            {
                int SpeedDiff = SpeedOfCar.Value - SpeedLimit.Value;
                int FailurePoints = (int)(SpeedDiff / 5) + 1;

                WriteLine($"Failure points: {FailurePoints} {(FailurePoints > 12 ? "Licence Suspended" : "")}");
            }
            else
            {
                WriteLine("Ok");
            }
        }
    }
    while (SpeedOfCar.HasValue);
}




decimal? GetNumericInputFromUser(decimal min, decimal max)
{
    Write($"Enter a number between {min} and {max}: ");
    if (decimal.TryParse(ReadLine(), out decimal ParsedValue))
    {
        return ParsedValue >= min && ParsedValue <= max 
            ? ParsedValue 
            : null;
    }

    return null;
}

UInt16? GetImageSizeFromUser(string typeDesc, UInt16? max = null)
{
    Write($"Enter the {typeDesc} of the image (between 1 and {(max.HasValue ? max.Value : UInt16.MaxValue)}): ");
    if(UInt16.TryParse(ReadLine(), out UInt16 ParsedValue))
    {
        return ParsedValue >= 1
            ? ParsedValue
            : null;
    }

    return null;
}

byte? GetAbsoluteSpeedFromUser(string typeOfSpeed)
{
    Write($"Enter {typeOfSpeed}: ");
    if(byte.TryParse(ReadLine(), out byte ParsedValue))
    {
        return ParsedValue;
    }

    return null;
}
