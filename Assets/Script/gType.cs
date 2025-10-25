using UnityEngine;

public class gType : MonoBehaviour
{
    private int index = 1;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy Got Shot");
        if (other.CompareTag("Bullet"))
        {
            if (GameManager.instance.ColorsMatch(index))
            {
                //Dies
                Destroy(other.gameObject);
                GameManager.instance.IncreaseKills();
                Destroy(gameObject);
            }
            else
                Destroy(other.gameObject);
        }
                if (other.CompareTag("Player"))
        {
            GameManager.instance.TakeDamage();
            Destroy(gameObject);
        }
    }
}
