using UnityEngine;
using System;
public class Ring : MonoBehaviour
{
    public static event EventHandler OnAnyRingDestroyed;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            OnAnyRingDestroyed?.Invoke(this, EventArgs.Empty);
        }
    }
}
