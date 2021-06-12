using System.Collections.Generic;
using UnityEngine;
using TransformExtensions;

public class LevelSection : MonoBehaviour
{
    [SerializeField] private List<GameObject> _coins;
    
    public Bounds Bounds { get; private set; }
    
    private void Awake()
    {
        Bounds = transform.CalculateBounds();
    }

    private void OnEnable()
    {
        foreach (var coin in _coins)
        {
            coin.SetActive(true);
        }
    }
}
