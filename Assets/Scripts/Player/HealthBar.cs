using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    GameObject player;
    Transform colliderTransform;
    GameObject playerCollider;
    PlayerDamage ps;


    private RectTransform bar;
    void Start() {
        player = GameObject.Find("Player");
        colliderTransform = player.transform.Find("Collider");
        playerCollider = colliderTransform.gameObject;

        ps = playerCollider.GetComponent<PlayerDamage>();

        bar = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() {
        float barWidth = ps.maxHealth / 100 * ps.health;
        bar.sizeDelta = new Vector2(barWidth, 15);
    }
}
