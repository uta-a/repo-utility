using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace REPOUtility;

public static class ItemHelper
{
    public static void ToggleItem(ItemAttributes item, bool active)
    {
        var toggle = item.GetComponent<ItemToggle>();
        if (toggle == null)
        {
            Plugin.Log.LogWarning("ToggleItem: no ItemToggle component found");
            return;
        }

        toggle.ToggleItem(active);
    }

    public static List<ItemAttributes> GetAllItems()
    {
        return new List<ItemAttributes>(ItemManager.instance.spawnedItems);
    }

    public static List<ItemAttributes> FindItemsByName(string name)
    {
        return ItemManager.instance.spawnedItems
            .Where(item => item != null && item.name.Contains(name))
            .ToList();
    }

    public static ItemAttributes FindNearestItem(Vector3 position, float range)
    {
        ItemAttributes nearest = null;
        float nearestDist = range;

        foreach (var item in ItemManager.instance.spawnedItems)
        {
            if (item == null) continue;
            float dist = Vector3.Distance(position, item.transform.position);
            if (dist < nearestDist)
            {
                nearestDist = dist;
                nearest = item;
            }
        }

        return nearest;
    }

    public static List<string> GetLocalInventory()
    {
        return ItemManager.instance.localPlayerInventory;
    }

    public static void ForceGrab(PhysGrabObject obj)
    {
        SemiFunc.PhysGrabberLocalForceGrab(obj);
    }
}
