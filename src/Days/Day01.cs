namespace AdventOfCode.Days;

[Day(2022, 1)]
public class Day01 : BaseDay
{
    public override string PartOne(string input)
    {
        var elfs = input.Paragraphs();
        var calories = elfs.Select(e => e.Integers().Sum());

        return calories.Max().ToString();
    }

    public override string PartTwo(string input)
    {
        var elfs = input.Paragraphs();
        var calories = elfs.Select(e => e.Integers().Sum());

        var result = calories.OrderByDescending(x => x).Take(3).Sum();

        return result.ToString();
    }
}
