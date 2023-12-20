using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuckingdraailmao : MonoBehaviour
{
    private Transform img;
    float currentAngle = 0;
    float speed = 0;
    // Start is called before the first frame update
    void Start() {
        img = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        currentAngle = currentAngle < 358 ? currentAngle + speed : 0;
        img.rotation = Quaternion.Euler(0, 0, currentAngle);

        speed += Time.deltaTime / 100;
    }
}
