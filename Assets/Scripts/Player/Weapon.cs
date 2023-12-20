using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public Transform player;
    public bool melee;
    public float attackTime;
    public float damage;

    public GameObject projectile;

    private GameObject weapon;
    private BoxCollider2D hitbox;
    private bool fired;

    // Start is called before the first frame update
    void Start() {
        weapon = GameObject.FindWithTag("Weapon");

        if (melee) {
            hitbox = GetComponent<BoxCollider2D>();
            hitbox.enabled = false;
        } else {
            fired = false;
        }
    }

    // Update is called once per frame
    void Update() {
        RotateObject();

        if (Input.GetButtonDown("Fire1")) {
            if (melee) {
                StartCoroutine(MeleeAttack());
            } else {
                StartCoroutine(RangeAttack());
            }
        }
    }

    void RotateObject() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - player.position;

        // Rotate
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    IEnumerator MeleeAttack() {
        hitbox.enabled = true;

        yield return new WaitForSeconds(attackTime);

        hitbox.enabled = false;
    }

    IEnumerator RangeAttack() {
        if (!fired) {
            GameObject pewpew = Instantiate(projectile, transform.position, Quaternion.identity);
            MoveProjectile mp = pewpew.GetComponent<MoveProjectile>();

            mp.speed = mp.maxSpeed;
            mp.gunDirection = transform.rotation.eulerAngles;

            fired = true;
        

            yield return new WaitForSeconds(attackTime);

            fired = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            EnemyStats es = other.gameObject.GetComponent<EnemyStats>();

            es.health -= damage / es.defense;

            if (es.health <= 0) {
                if(Mathf.Floor(UnityEngine.Random.Range(0f ,es.itemSpawnChance)) == 0) {
                    Debug.Log("item spawned");
                }
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}
