using System;

[Serializable]
public class Item
{
    public ItemType itemType;
    public int stackCount;

    public int maxStackCount
    {
        get { return GetMaxStack(itemType); }
    }

    public enum ItemType
    {
        None = 0, // default
        ScrapMetal,
        Stone
    }

    static int GetMaxStack(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.ScrapMetal: return 999;
            case ItemType.Stone:       return 999;
            default:                   return 1;
        }
    }
}
