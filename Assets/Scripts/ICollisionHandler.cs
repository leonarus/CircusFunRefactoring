// Collision Handler

using UnityEngine;

public interface ICollisionHandler
{
    bool IsGrounded();
    bool IsDead();
    void HandleCollision(Collision2D collision);
}