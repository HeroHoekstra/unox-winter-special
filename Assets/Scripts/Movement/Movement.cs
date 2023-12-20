using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    // Values
    public float speed;
    public float dashSpeed;
    public float dashTime;
    public float dashCoolDown;


    private CharacterController controller;
    private Collider hitbox;
    private float currentSpeed;
    private bool dash;

    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
        hitbox = GetComponent<Collider>();

        currentSpeed = speed;
        dash = false;
    }

    // Update is called once per frame
    void Update() {
        // Dashing
        if (Input.GetButtonDown("Fire2") && !dash) {
            StartCoroutine(Dash(dashTime));
            StartCoroutine(DashCoolDown(dashCoolDown));
        }


        // Movement
        float speedX = Input.GetAxisRaw("Horizontal");
        float speedY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(speedX, speedY, 0f).normalized;
        Vector3 velocity = movement * currentSpeed;

        controller.Move(velocity * Time.deltaTime);
    }

    // Dash
    IEnumerator Dash(float duration) {
        float oldSpeed = currentSpeed;
        currentSpeed = currentSpeed * dashSpeed;
        Physics.IgnoreCollision(controller, hitbox, true);

        yield return new WaitForSeconds(dashTime);

        currentSpeed = oldSpeed;
        Physics.IgnoreCollision(controller, hitbox, false);
    }

    IEnumerator DashCoolDown(float duration) {
        dash = true;

        yield return new WaitForSeconds(duration);

        dash = false;
    }
}
