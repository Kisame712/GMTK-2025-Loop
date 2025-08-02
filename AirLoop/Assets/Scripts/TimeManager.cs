using UnityEngine;
using TMPro;
public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    [SerializeField] private TMP_Text timeDisplay;
    private float timeCount;
    private void Update()
    {
        timeCount += Time.deltaTime;
        timeDisplay.text = "Time : " + Mathf.RoundToInt(timeCount).ToString();
    }

    public int GetScore()
    {
        return Mathf.RoundToInt(timeCount);
    }
}
