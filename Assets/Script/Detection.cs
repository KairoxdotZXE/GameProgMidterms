using UnityEngine;

public class Detection : MonoBehaviour
{
    [Header("Targeting")]
    public string targetTag = "Enemy";    // Tag of objects to detect
    public float detectionRadius = 100f;   // How far we can see targets

    [Header("Rotation")]
    public float rotationSpeed = 5f;      // How fast the shooter rotates

    [HideInInspector]
    public Transform nearestTarget;       // The closest target in range

    void LateUpdate()
    {
        // Rotate toward the nearest target if it exists
        if (nearestTarget != null)
        {
            Vector3 direction = nearestTarget.position - transform.position;

            if (direction != Vector3.zero)
            {
                Debug.Log("rotating tank");
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    Time.deltaTime * rotationSpeed*100
                );
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(targetTag))
        {
            UpdateNearestTarget();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            UpdateNearestTarget();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag) && nearestTarget == other.transform)
        {
            nearestTarget = null; // Lost the nearest target
        }
    }

    void UpdateNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        float closestDistance = Mathf.Infinity;
        Transform currentNearest = null;

        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance <= detectionRadius && distance < closestDistance)
            {
                closestDistance = distance;
                currentNearest = target.transform;
            }
        }

        nearestTarget = currentNearest;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
