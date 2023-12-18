using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public float spawnSpeed;
    public float spawnRadius;
    public GameObject[] enemies;

    private GameObject player;
    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("Player");

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        if (enemies.Length > 0) {
            float angle = Random.Range(0f, 360f);
            Vector3 spawnPosition = player.transform.position + Quaternion.Euler(0f, 0f, angle) * new Vector3(spawnRadius, 0f, -10f);

            GameObject enemyToSpawn = enemies[Random.Range(0, enemies.Length - 1)];
            GameObject spawnedEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
            spawnedEnemy.transform.parent = transform;
        } else {
            Debug.Log("No enemies were found");
        }

        yield return new WaitForSeconds(spawnSpeed);

        spawnSpeed = spawnSpeed > .5f ? spawnSpeed -= Random.Range(0, 0.1f) : spawnSpeed;

        StartCoroutine(Spawn());
    }
}
