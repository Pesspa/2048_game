using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    [ContextMenu("SetTarget")]
    public void SetTarget()
    {
        itemList.Clear();
        Item[] items = FindObjectsOfType<Item>();
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].ItemType == ItemType.Box)
            {
                itemList.Add(items[i]);
            }
        }
    }
}
