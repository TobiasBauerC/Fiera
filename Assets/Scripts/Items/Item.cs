using System;

[Serializable]
public class Item
{
    public ItemType itemType;
    public int stackCount;

    public void ClearItem()
    {
        itemType = ItemType.None;
        stackCount = 0;
    }

    public enum ItemType
    {
        None = 0, // default
        ScrapMetal,
        Stone
    }
}
