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
