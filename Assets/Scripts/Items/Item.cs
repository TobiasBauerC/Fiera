using System;

[Serializable]
public class Item
{
    public ItemType itemType;
    public int stackCount;

    public enum ItemType
    {
        None = 0, // default
        ScrapMetal,
        Stone
    }
}
