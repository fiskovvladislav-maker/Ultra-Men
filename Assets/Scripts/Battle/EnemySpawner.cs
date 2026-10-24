using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _spawnRate = 1f;    
    [SerializeField] private float _spawnRadius = 50f; 
    [SerializeField] private int _maxEnemies = 5;     

    private float _nextSpawnTime;
    private int _currentEnemyCount = 0;

    private void Update()
    {
        
        if (_currentEnemyCount >= _maxEnemies) return;

    
        if (Time.time >= _nextSpawnTime)
        {
            SpawnEnemy();
            _nextSpawnTime = Time.time + 1f / _spawnRate; 
        }
    }

    private void SpawnEnemy()
    {
   
        Vector3 randomPos = Random.insideUnitSphere * _spawnRadius;
        randomPos += transform.position; 

    
        randomPos.y = 0;

        GameObject enemy = ObjectPool.Instance.SpawnFromPool("Enemy", randomPos, Quaternion.identity);

        if (enemy != null)
        {
            _currentEnemyCount++;
        }
    }
}