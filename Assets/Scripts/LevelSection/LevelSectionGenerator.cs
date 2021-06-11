using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSectionGenerator : MonoBehaviour
{
    [SerializeField] private Vector3 _nextSpawnPosition;
    [SerializeField] private float _xOffset;
    [SerializeField] private Transform _player;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private float _removeDistance;
    [SerializeField] private List<PoolObjectTemplate<LevelSection>> _templates;

    private readonly List<Transform> _spawned = new List<Transform>();
    private ObjectPool<LevelSection> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<LevelSection>(_templates);
    }

    private void Update()
    {
        TrySpawnNextSection();
        TryRemoveOutOfRangeSections();
    }

    private void TrySpawnNextSection()
    {
        if (!(Vector2.Distance(_player.transform.position, _nextSpawnPosition) <= _spawnDistance)) 
            return;
        
        LevelSection template = _pool.GetRandomObject();

        _spawned.Add(template.transform);

        template.transform.position = _nextSpawnPosition;
        template.gameObject.SetActive(true);

        _nextSpawnPosition = new Vector3(template.transform.position.x + template.Bounds.size.x + _xOffset, _nextSpawnPosition.y);
    }

    private void TryRemoveOutOfRangeSections()
    {
        for (int i = 0; i < _spawned.Count; i++)
        {
            var section = _spawned[i];

            if (Vector2.Distance(_player.transform.position, section.position) >= _removeDistance)
            {
                section.gameObject.SetActive(false);
                _spawned.Remove(section);
                i--;
            }
        }
    }
}
