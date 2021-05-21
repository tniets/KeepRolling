using UnityEngine;
using TransformExtensions;

public class LevelSection : MonoBehaviour
{
    public Bounds Bounds { get; private set; }

    private void Awake()
    {
        Bounds = transform.CalculateBounds();
    }

    private void OnEnable()
    {
        transform.SetAllChildrenActive(true);
    }
}
