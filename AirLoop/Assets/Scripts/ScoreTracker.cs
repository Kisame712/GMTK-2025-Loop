using System.Threading;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static ScoreTracker Instance;

    private int playerScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(Instance);
    }
   
    public void SetScore(int scoreAtLevelComplete)
    {
        playerScore = scoreAtLevelComplete;
    }

}
