using System.Collections;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] GameObject _slimePrefab;
    [SerializeField] public GameObject _target;
    float spawnRadius = 9f;
    float spawnInterval = 3.5f;

    private void Start()
    {
        StartCoroutine(SpawnSlimes());
        // _target = GameObject.FindWithTag("Player");
        // if (_target == null)
        //     Debug.LogError("SlimeSpawner.cs: Target is null");
    }

    private IEnumerator SpawnSlimes()
    {
        while(true)
        {
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            Vector2 spawnPosition = (Vector2)_target.transform.position + new Vector2(randomOffset.x, randomOffset.y);

            GameObject slime = Instantiate(_slimePrefab, spawnPosition, Quaternion.identity);
            slime.transform.SetParent(transform);
            

            // Set any additional properties or behaviors of the spawned slime

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
