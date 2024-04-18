using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SceneManager _sceneManager;
    [SerializeField] private GameSoundManager _gameSoundManager;
    
    private bool _isJumping;
    private bool _canJump;
    
    private IInputHandler _inputHandler;
    private IAnimationHandler _animationHandler;
    private ICollisionHandler _collisionHandler;
    private IScoreHandler _scoreHandler;

    private void Awake()
    {
        _inputHandler = new KeyboardInputHandler();
        _animationHandler = new PlayerAnimationHandler(GetComponent<Animator>());
        _collisionHandler = new PlayerCollisionHandler();
        _scoreHandler = new PlayerScoreHandler();
        Time.timeScale = 1;
        _canJump = true;
    }

    private void Update()
    {
        HandleJumping();
    }
    
    private void HandleJumping()
    {
        if (_inputHandler.CanJump() && _collisionHandler.IsGrounded() && !_collisionHandler.IsDead() && _canJump)
        {
            _isJumping = true;
            _gameSoundManager.PlayJumpSound();
            _animationHandler.StartJump();
            _rigidbody.AddForce(new Vector2(0.0f, 150.0f));
            _canJump = false;
        }
        else
        {
            _animationHandler.StopJump();
            _isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _collisionHandler.HandleCollision(col);
        if (_collisionHandler.IsDead())
        {
            _gameSoundManager.PlayDeathSound();
        }
        
        // Разрешаем прыжок, когда игрок находится на земле
        if (_collisionHandler.IsGrounded())
        {
            _canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _gameSoundManager.PlayCoinCollectSound();
        _scoreHandler.HandleCoinCollection(other, other.gameObject);
    }

    private void OnGUI()
    {
        if (_collisionHandler.IsDead())
        {
            _sceneManager.ShowGameOverScene(_scoreHandler.GetScore());
        }
    }
}