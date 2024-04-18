using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _backgroundPrefab;
    [SerializeField] private float _initialDelay = 0.03f;
    [SerializeField] private float _spawnInterval = 5.0f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBackground), _initialDelay, _spawnInterval);
    }

    private void SpawnBackground()
    {
        Instantiate(_backgroundPrefab);
    }
}