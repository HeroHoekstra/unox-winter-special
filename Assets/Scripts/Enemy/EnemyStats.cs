<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Weapon")) {
            Debug.Log("ouchie");
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    public float defense;

    public float health;
    // Start is called before the first frame update
    void Start() {
        health = maxHealth;
    }
}
>>>>>>> fa05f232036af0eb32a5e9d99338d9b18cf58f7b
