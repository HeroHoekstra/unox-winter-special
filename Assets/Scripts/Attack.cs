using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject meleeAttack;
    public int attackTimer;

    public Camera cam;
    Vector2 mousePos;
    void Start()
    {
        meleeAttack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        attackTimer--;
        if (Input.GetMouseButtonDown(0)) {
            meleeAttack.SetActive(true);
            attackTimer = 10;
        }

        if(attackTimer <= 0) {
            meleeAttack.SetActive(false);
        }

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
