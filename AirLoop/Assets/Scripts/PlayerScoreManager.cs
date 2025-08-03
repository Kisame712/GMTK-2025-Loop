using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class PlayerScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_InputField nameInputField;

    public UnityEvent<string, int> submitScoreEvent;

    int playerScore;
    private void Awake()
    {
        playerScore = ScoreTracker.Instance.GetScore();
        scoreText.text = $"Time - " + playerScore.ToString();
    }

    public void SubmitScore()
    {
        submitScoreEvent?.Invoke(nameInputField.text, playerScore);
    }
}
