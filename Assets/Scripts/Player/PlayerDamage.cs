using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public float maxHealth;
    public float regenSpeed;
    public float defense;

    public float health;

    public string sceneToLoad;
    // Start is called before the first frame update
    void Start() {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update() {
        if (health < maxHealth) {
            health += regenSpeed * Time.deltaTime;
        }
        if (health < 0) {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            EnemyStats es = other.gameObject.GetComponent<EnemyStats>();

            health -= es.damage * Mathf.Floor(Random.Range(0, es.critChance)) == 0 ? es.critMulitplier : 1 * Time.deltaTime;
        }
    }
}
