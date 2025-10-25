using UnityEngine;

public class bType : MonoBehaviour
{
    private int index = 2;
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
