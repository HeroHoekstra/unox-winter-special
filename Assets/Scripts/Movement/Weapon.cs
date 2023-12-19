<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public Transform player;
    public bool melee;
    public float attackTime;

    private GameObject weapon;
    private BoxCollider2D hitbox;

    // Start is called before the first frame update
    void Start() {
        weapon = GameObject.FindWithTag("Weapon");

        hitbox = GetComponent<BoxCollider2D>();
        hitbox.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        RotateObject();

        if (Input.GetButtonDown("Fire1")) {
            if (melee) {
                StartCoroutine(MeleeAttack());
            } else {
                RangeAttack();
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

    void RangeAttack() {
        Debug.Log("Fire");
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public Transform player;
    public bool melee;
    public float attackTime;
    public float damage;

    private GameObject weapon;
    private BoxCollider2D hitbox;

    // Start is called before the first frame update
    void Start() {
        weapon = GameObject.FindWithTag("Weapon");

        hitbox = GetComponent<BoxCollider2D>();
        hitbox.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        RotateObject();

        if (Input.GetButtonDown("Fire1")) {
            if (melee) {
                StartCoroutine(MeleeAttack());
            } else {
                RangeAttack();
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

    void RangeAttack() {
        Debug.Log("Fire");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            EnemyStats es = other.gameObject.GetComponent<EnemyStats>();

            es.health -= damage / es.defense;

            if (es.health <= 0) {
                Debug.Log(es.health + ", " + other.gameObject);
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}
>>>>>>> fa05f232036af0eb32a5e9d99338d9b18cf58f7b
