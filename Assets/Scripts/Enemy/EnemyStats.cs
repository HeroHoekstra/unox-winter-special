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
