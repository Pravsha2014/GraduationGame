using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Bird : MonoBehaviour
{
    [HideInInspector] public UnityEvent CoinTaken;

    public event UnityAction Died;

    private readonly int _hashDead = Animator.StringToHash("Dead");
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out _))
        {
            CoinTaken?.Invoke();

            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Cage _))
        {
            Died?.Invoke();
            SetDeadAnimation();
        }
    }

    public void SetDeadAnimation()
    {
        _animator.SetTrigger(_hashDead);
    }
}