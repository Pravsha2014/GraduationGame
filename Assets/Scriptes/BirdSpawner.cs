using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _birdTemplate;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private Transform _birdSpawnPoint;
    [SerializeField] private WalletText _walletText;

    public UnityEvent BirdDied;

    private GameObject _birdObject = null;
    private Bird _bird;
    private Wallet _wallet;

    private void OnDisable()
    {
        _bird.Died -= OnBirdDied;
        _wallet.ValueChanged -= OnValueChanged;
    }

    public void CreateBird()
    {
        if (_birdObject != null)
        {
            Destroy(_birdObject);
        }

        _birdObject = Instantiate(_birdTemplate, _birdSpawnPoint);

        _bird = _birdObject.GetComponent<Bird>();
        _wallet = _birdObject.GetComponent<Wallet>();

        _bird.Died += OnBirdDied;
        _wallet.ValueChanged += OnValueChanged;
    }

    private void OnValueChanged()
    {
        _walletText.ChangeValue(_wallet.Amount);
    }

    public void OpenMenu()
    {
        _menuPanel.SetActive(true);
    }

    private void OnBirdDied()
    {
        BirdDied?.Invoke();
    }
}
