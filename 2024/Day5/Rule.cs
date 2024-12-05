namespace Day5;

public class Rule(int pagebefore, int pageAfter)
{
    public int PageBefore { get; set; } = pagebefore;
    public int PageAfter { get; set; } = pageAfter;

    public bool RuleApplys(Level level)
    {
        if (level.Pages.Contains(PageBefore) && level.Pages.Contains(PageAfter))
        {
            if (level.Pages.IndexOf(PageBefore) > level.Pages.IndexOf(PageAfter))
            {
                return false;
            }
        }
        return true;
    }
}