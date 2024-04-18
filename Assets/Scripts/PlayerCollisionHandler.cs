using UnityEngine;

public class PlayerCollisionHandler : ICollisionHandler
{
    private bool _isGrounded = true;
    private bool _isDead = false;

    public bool IsGrounded()
    {
        return _isGrounded;
    }

    public bool IsDead()
    {
        return _isDead;
    }

    public void HandleCollision(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            _isGrounded = true;
        }
        else if (collision.gameObject.tag == "obs")
        {
            _isDead = true;
            Time.timeScale = 0;
        }
    }
    
}