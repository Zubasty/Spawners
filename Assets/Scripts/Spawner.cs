using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private PointSpawn[] _points;
    [SerializeField] private float _timeDelay;
    private WaitForSeconds _delay;


    private bool _canSpawn;

    private void Awake()
    {
        _canSpawn = true;
        _delay = new WaitForSeconds(_timeDelay);
    }

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private void OnValidate()
    {
        if (_timeDelay <= 0)
        {
            _timeDelay = 1;
            Debug.LogError("Количество секунд между спавнами должно быть положительным");
        }
    }

    private IEnumerator Spawning()
    {
        while (_canSpawn)
        {
            Vector3 position = _points[Random.Range(0, _points.Length)].transform.position;
            Instantiate(_enemyPrefab, position, Quaternion.identity);
            yield return _delay;
        }
        yield return null;
    }
}
