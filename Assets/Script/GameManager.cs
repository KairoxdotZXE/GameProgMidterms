using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int bulletIndex;
    public bool isMatching;
    public int hp = 3;
    private int kills = 0;
    public TextMeshProUGUI killCount;
    public GameObject[] Hearts;
    public GameObject GameOverScreen;
        private void Awake()
    {
        // Singleton pattern
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void GetBulletColor(int bulletNum){ bulletIndex = bulletNum;Debug.Log("Getting BulletColor");}

    public bool ColorsMatch(int enemyIndex)
    {
        if (enemyIndex == bulletIndex)
            isMatching = true;
        else
            isMatching = false;

        return isMatching;
    }
     public void TakeDamage(){hp--; CheckHealth();Debug.Log("Took Damage:"+ hp);}
    void CheckHealth()
    {
        switch (hp)
        {
            case 1:
                Hearts[0].SetActive(true);
                Hearts[1].SetActive(false);
                Hearts[2].SetActive(false);
                break;
            case 2:
                Hearts[0].SetActive(true);
                Hearts[1].SetActive(true);
                Hearts[2].SetActive(false);
                break;
            case 3:
                Hearts[0].SetActive(true);
                Hearts[1].SetActive(true);
                Hearts[2].SetActive(true);
                break;
            default:
                GameOver();
                break;
        }
    }
    public void IncreaseKills() { kills++; Debug.Log("Kills:" + kills); }
    void setKillCount() { killCount.text = "Kills:" + kills; }
    public void GameOver(){ GameOverScreen.SetActive(true); setKillCount();Time.timeScale = 0;}
}
