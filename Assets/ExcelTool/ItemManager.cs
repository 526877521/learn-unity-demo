using UnityEngine;

namespace Data
{
    public class ItemManager : ScriptableObject
    {
        public ItemObj[] dataArray;

        public ItemObj getItemById(uint index)
        {
            foreach (ItemObj i in dataArray)
            {
                if (i.itemId == index)
                {
                    return i;
                }
            }

            return null;
        }
    }
}