using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(Bird))]
public class Wallet : MonoBehaviour
{
    private Bird _bird;

    public event UnityAction ValueChanged;

    public int Amount { get; private set; }

    private void Start()
    {
        Amount = 0;

        ValueChanged?.Invoke();

        _bird = GetComponent<Bird>();

        _bird.CoinTaken.AddListener(AddCoin);
    }

    private void OnDisable()
    {
        _bird.CoinTaken.RemoveListener(AddCoin);
    }

    private void AddCoin()
    {
        Amount++;
        ValueChanged?.Invoke();
    }
}
