using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class RingManager : MonoBehaviour
{
    [SerializeField] private TMP_Text ringsText;
    [SerializeField] private TimeManager timeManager;
    int totalRingCount;
    public int currentRings;

    public void Awake()
    {
        totalRingCount = FindObjectsByType<Ring>(FindObjectsSortMode.None).Length;
    }
    private void Start()
    {
        currentRings = 0;
        UpdateRingsText();
    }

    private void Update()
    {
        if(currentRings == totalRingCount)
        {
            LevelComplete();
        }
    }

    public void UpdateRingsText()
    {
        ringsText.text = $"Rings - {currentRings}/{totalRingCount}";
    }

    private void LevelComplete()
    {
       if(SceneManager.GetActiveScene().name == "Game")
        {
         ScoreTracker.Instance.SetScore(timeManager.GetScore());
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
