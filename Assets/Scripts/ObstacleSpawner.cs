using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePrefabs;
    [SerializeField] private float _minSpawnInterval = 0.5f;
    [SerializeField] private float _maxSpawnInterval = 2f;
    [SerializeField] private float _speedIncreaseInterval = 30f;
    [SerializeField] private float _initialObstacleSpeed = 4f;
    [SerializeField] private float _speedIncreaseAmount = 1f;
    [SerializeField] private float _spawnPositionX = 10f;
    [SerializeField] private float _delayAfterSpeedIncrease = 5f;

    private float _currentObstacleSpeed;
    private SpeedController _speedController;

    private void Start()
    {
        _currentObstacleSpeed = _initialObstacleSpeed;
        _speedController = new SpeedController(_speedIncreaseInterval, _speedIncreaseAmount, _delayAfterSpeedIncrease, _initialObstacleSpeed);
        StartCoroutine(SpawnObstaclesCoroutine());
    }

    private IEnumerator SpawnObstaclesCoroutine()
    {
        while (true)
        {
            float currentSpawnInterval = Mathf.Lerp(_maxSpawnInterval, _minSpawnInterval, _speedController.CurrentSpeed / (_initialObstacleSpeed + _speedController.SpeedIncreaseAmount * (_speedController.TimeSinceLastSpeedIncrease / _speedController.SpeedIncreaseInterval)));
            yield return new WaitForSeconds(currentSpawnInterval);
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        var randomIndex = Random.Range(0, _obstaclePrefabs.Length);
        var obstacle = Instantiate(_obstaclePrefabs[randomIndex],
            new Vector3(_spawnPositionX, _obstaclePrefabs[randomIndex].transform.position.y, transform.position.z), Quaternion.identity);
        obstacle.GetComponent<MoveObstacle>().Speed = _speedController.CurrentSpeed;
    }

    private void Update()
    {
        if (_speedController.CanIncreaseSpeed())
        {
            IncreaseObstacleSpeed();
        }
    }

    private void IncreaseObstacleSpeed()
    {
        _speedController.CurrentSpeed += _speedController.SpeedIncreaseAmount;
        _speedController.ResetTimeSinceLastSpeedIncrease();
    }
}