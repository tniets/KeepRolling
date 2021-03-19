using UnityEngine;

public static class Utils 
{
    public static void SetAllChildrenActive(Transform transform, bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
            SetAllChildrenActive(child, value);
        }
    }
}
