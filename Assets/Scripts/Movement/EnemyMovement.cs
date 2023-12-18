using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public Transform player;
    public float moveSpeed;

    private CharacterController controller;
    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer() {
        if (player == null || controller == null) {
            Debug.Log("Can't find target or controller");
        }

        Vector3 direction = player.position - transform.position;

        direction.Normalize();

        controller.Move(direction * moveSpeed * Time.deltaTime);
    }
}
