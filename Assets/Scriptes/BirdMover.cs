using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Bird))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpVelocity;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Bird _bird;
    private bool _canMove;

    private void Start()
    {
        _canMove = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _bird = GetComponent<Bird>();

        _bird.Died += ProhibitMovement;
    }

    private void Update()
    {
        if (_canMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                _spriteRenderer.flipX = true;
                transform.Translate(_speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _spriteRenderer.flipX = false;
                transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.AddForce(Vector2.up * _jumpVelocity, ForceMode2D.Impulse);
            }
        }
    }

    private void OnDisable()
    {
        _bird.Died -= ProhibitMovement;
    }

    private void ProhibitMovement()
    {
        _canMove = false;
    }
}
