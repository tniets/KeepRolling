using UnityEngine;
using TransformExtensions;

public class LevelSection : MonoBehaviour
{
    [SerializeField] private Transform _coinsContainer;
    
    public Bounds Bounds { get; private set; }
    
    private void Awake()
    {
        Bounds = transform.CalculateBounds();
    }

    private void OnEnable()
    {
        _coinsContainer.SetAllChildrenActive(true);
    }
}
