using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    
    public static CoinCount instance;
    public GameObject bonus;
    public GameObject spawnPoint;
    public Text text;
    public int score;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = score.ToString();
        if (score % 10 == 0)
        {
            Instantiate(bonus, spawnPoint.transform.position, Quaternion.identity);
        }
    }

}
