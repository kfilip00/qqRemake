using System.Collections.Generic;

public class PlayerData
{
    public List<int> CardIdsIndeck { get; private set; }

    public void Init()
    {
        CardIdsIndeck = new List<int>() { 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 0, 1 };
    }
}
