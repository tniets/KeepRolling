using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCalculator : MonoBehaviour
{
    public Bounds CalculateBounds()
    {
        var center = Vector3.zero;
        var childRenderers = new List<SpriteRenderer>();

        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out SpriteRenderer renderer))
            {
                center += renderer.bounds.center;
                childRenderers.Add(renderer);
            }
        }

        center /= childRenderers.Count;

        var bounds = new Bounds(center, Vector3.zero);

        foreach (SpriteRenderer renderer in childRenderers)
        {
            bounds.Encapsulate(renderer.bounds);
        }

        return bounds;
    }
}
