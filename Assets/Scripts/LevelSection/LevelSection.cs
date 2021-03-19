using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoundsCalculator))]
public class LevelSection : MonoBehaviour
{
    public Bounds Bounds { get; private set; }

    private void Awake()
    {
        Bounds = GetComponent<BoundsCalculator>().CalculateBounds();
    }

    private void OnEnable()
    {
        Utils.SetAllChildrenActive(transform, true);
    }
}
