using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private PointSpawn[] _points;
    [SerializeField] private float _delaySpawn;

    private bool _canSpawn;

    private void Awake()
    {
        _canSpawn = true;      
    }

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private void OnValidate()
    {
        if (_delaySpawn <= 0)
        {
            _delaySpawn = 1;
            Debug.LogError("Количество секунд между спавнами должно быть положительным");
        }
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds delay = new WaitForSeconds(_delaySpawn);
        while (_canSpawn)
        {
            Vector3 position = _points[Random.Range(0, _points.Length)].transform.position;
            Instantiate(_enemyPrefab, position, Quaternion.identity);
            yield return delay;
        }
        yield return null;
    }
}
