using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{   
    public float speed = 15f;
    void Start()
    {
        StartCoroutine(DeSpawn());
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other) { if (other.CompareTag("Player")) { } }
    
    void Damage(){}
    IEnumerator DeSpawn(){ yield return new WaitForSeconds(10f); Destroy(gameObject);}
}
