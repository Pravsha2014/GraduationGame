using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;
    [SerializeField] private float _frequencyOfCoinOccurrence;

    private Transform[] _spawnPoints;
    private readonly Coroutine _coroutine;
    private Coin _coin = null;
    private int _currentSpawnPointIndex;
    private bool _isSpawning;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if (_coin == null && _isSpawning == false)
        {
            _isSpawning = true;

            RunCoroutine();
        }
    }

    private void RunCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        StartCoroutine(SpawnCoinWithDelay());
    }

    private IEnumerator SpawnCoinWithDelay()
    {
        var frequencyInSeconds = new WaitForSeconds(_frequencyOfCoinOccurrence);

        yield return frequencyInSeconds;

        _currentSpawnPointIndex = Random.Range(0, _spawnPoints.Length);
        _coin = Instantiate(_coinTemplate, _spawnPoints[_currentSpawnPointIndex].transform);
        _isSpawning = false;
    }
}
