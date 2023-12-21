using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float maxSpeed;
    public float damage;
    public float KYStime;
    
    public Vector3 gunDirection;
    public float speed;

    Vector3 direction;

    // Start is called before the first frame update
    void Start() {
        direction = new Vector3(speed * Mathf.Cos(gunDirection.z * Mathf.Deg2Rad), speed * Mathf.Sin(gunDirection.z * Mathf.Deg2Rad), 0);
        StartCoroutine(KYS(KYStime));
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;

        transform.position = new Vector3(pos.x + direction.x, pos.y + direction.y, pos.z);
    }

    IEnumerator KYS(float duration) {
        yield return new WaitForSeconds(duration);

        Destroy(gameObject);
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

            Destroy(gameObject);
        }
    }
}
