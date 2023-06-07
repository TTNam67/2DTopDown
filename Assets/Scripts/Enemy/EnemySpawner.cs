using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _enemyPrefabs;
    Transform _playerTransform;
    float _spawnDistance = 7f;
    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        if (_playerTransform == null)
        {
            Debug.LogWarning("EnemySpawner.cs: The player transform is null");
        }

        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int enemyIndex = Random.Range(0, _enemyPrefabs.Length);
            float angle = Random.Range(0f, Mathf.PI * 2f);

            Vector2 playerPosi = new Vector2(_playerTransform.position.x, _playerTransform.position.y);

            // Calculate the random position based on the angle and distance
            Vector2 randomPosition = playerPosi + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * _spawnDistance;
            GameObject newEnemy = Instantiate(_enemyPrefabs[enemyIndex], randomPosition, Quaternion.identity);
            newEnemy.transform.parent = this.transform;
            yield return new WaitForSeconds(2f);
        }
    }
}

