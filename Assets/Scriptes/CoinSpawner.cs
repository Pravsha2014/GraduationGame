using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinTemplate;
    [SerializeField] private Transform _CoinSpawner;
    [SerializeField] private float _frequencyOfCoinOccurrence;

    private Transform[] _spawnPoints;
    private float _elapsedTimeInSeconds = 0;
    int _currentSpawnPointIndex;
    GameObject _coin = null;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if(_coin == null)
        {
            _elapsedTimeInSeconds += Time.deltaTime;
        }

        if (_elapsedTimeInSeconds >= _frequencyOfCoinOccurrence)
        {
            SpawnCoin();
            _elapsedTimeInSeconds = 0;
        }
    }

    private void SpawnCoin()
    {
        _currentSpawnPointIndex = Random.Range(0, _spawnPoints.Length);
        _coin = Instantiate(_coinTemplate, _spawnPoints[_currentSpawnPointIndex].transform);
    }
}
