using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float _speed = -4.0f;
    [SerializeField] private float _destroyPositionX = -20.0f;
    [SerializeField] private Rigidbody2D _rb2D;

    private void FixedUpdate()
    {
        var newPosition = transform.position;
        newPosition.x += _speed * Time.fixedDeltaTime;
        _rb2D.MovePosition(newPosition);

        if (transform.position.x < _destroyPositionX)
        {
            Destroy(gameObject);
        }
    }
}