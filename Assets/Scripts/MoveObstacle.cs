using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _destroyPositionX = -20f;

    public float Speed
    {
        set => _speed = value;
    }

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-_speed, 0f);
    }

    private void Update()
    {
        if (transform.position.x < _destroyPositionX)
        {
            Destroy(gameObject);
        }
    }
}