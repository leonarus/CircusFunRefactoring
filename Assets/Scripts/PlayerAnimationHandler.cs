using UnityEngine;

public class PlayerAnimationHandler : IAnimationHandler
{
    private readonly Animator _animator;
    private static readonly int Jump = Animator.StringToHash("jump");

    public PlayerAnimationHandler(Animator animator)
    {
        _animator = animator;
    }

    public void StartJump()
    {
        _animator.SetBool(Jump, true);
    }

    public void StopJump()
    {
        _animator.SetBool(Jump, false);
    }
}