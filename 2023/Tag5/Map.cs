using System;

namespace aoc2023_05;

public class Map
{
    public long DestRange { get; set; }
    public long SourceRange { get; set; }
    public long RangeLength { get; set; }

    public Map(string destRange, string sourceRange, string rangeLength)
    {
        DestRange = long.Parse(destRange);
        SourceRange = long.Parse(sourceRange);
        RangeLength = long.Parse(rangeLength);
    }
}

