using System.Xml.Serialization;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{    private float speed = 5f;
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(0,0,0),Time.deltaTime * speed);
    }
}
