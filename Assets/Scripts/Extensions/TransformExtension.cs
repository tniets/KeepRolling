using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TransformExtensions
{
    public static class TransformExtension 
    {
        public static Bounds CalculateBounds(this Transform that)
        {
            var bounds = new Bounds();

            foreach (Transform child in that)
            {
                if (child.TryGetComponent(out SpriteRenderer renderer))
                {
                    bounds.Encapsulate(renderer.bounds);
                }
            }
        
            return bounds;
        }

        public static void SetAllChildrenActive(this Transform that, bool value)
        {
            foreach (Transform child in that)
            {
                child.gameObject.SetActive(value);
                SetAllChildrenActive(child, value);
            }
        }
    }
}

