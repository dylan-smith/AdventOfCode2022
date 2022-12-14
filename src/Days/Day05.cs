namespace AdventOfCode.Days;

[Day(2022, 5)]
public class Day05 : BaseDay
{
    public override string PartOne(string input)
    {
        var stacks = ParseStacks(input[..input.IndexOf("move")]);
        
        input = input[input.IndexOf("move")..];
        var moves = input.ParseLines(ParseMove);
        
        moves.ForEach(m => m.count.Times(() => MoveCrates(stacks, m.from, m.to, 1)));

        return string.Concat(stacks.Select(s => s.Last()));
    }

    private List<List<char>> ParseStacks(string input)
    {
        var lines = input.Lines().ToList();
        var numStacks = (lines.First().Length + 1) / 4;

        var stacks = new List<List<char>>();
        stacks.Initialize(() => new List<char>(), numStacks);

        lines.ForEach(line =>
        {
            for (var i = 0; i < numStacks; i++)
            {
                var stackInput = line.Substring(i * 4, 3);

                if (stackInput.StartsWith('['))
                {
                    stacks[i].AddFirst(stackInput[1]);
                }
            }
        });

        return stacks;
    }

    private (int count, int from, int to) ParseMove(string line)
    {
        var words = line.Words().ToList();

        var count = int.Parse(words[1]);
        var from = int.Parse(words[3]);
        var to = int.Parse(words[5]);

        return (count, from, to);
    }

    private void MoveCrates(List<List<char>> stacks, int from, int to, int count)
    {
        var crates = stacks[from - 1].Pop(count);
        stacks[to - 1].AddRange(crates);
    }

    public override string PartTwo(string input)
    {
        var stacks = ParseStacks(input[..input.IndexOf("move")]);

        input = input[input.IndexOf("move")..];
        var moves = input.ParseLines(ParseMove);
        
        moves.ForEach(m => MoveCrates(stacks, m.from, m.to, m.count));

        return string.Concat(stacks.Select(s => s.Last()));
    }
}
