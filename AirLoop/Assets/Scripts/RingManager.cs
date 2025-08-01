using UnityEngine;
using TMPro;
using System;
public class RingManager : MonoBehaviour
{
    [SerializeField] private TMP_Text ringsText;
    Ring[] rings;
    int totalRingCount;


    private void Start()
    {
        InitialTextDisplay();
        Ring.OnAnyRingDestroyed += Ring_OnAnyRingDestroyed;
    }

    private void UpdateRingsText()
    {
      
        rings = FindObjectsByType<Ring>(FindObjectsSortMode.None);
        ringsText.text = $"Rings - {( totalRingCount - rings.Length + 1)}/{totalRingCount}";
    }

    private void Ring_OnAnyRingDestroyed(object sender, EventArgs e)
    {
        UpdateRingsText();
    }

    private void InitialTextDisplay()
    {
        rings = FindObjectsByType<Ring>(FindObjectsSortMode.None);
        totalRingCount = rings.Length;
        ringsText.text = $"Rings - 0/{totalRingCount}";
    }
}
