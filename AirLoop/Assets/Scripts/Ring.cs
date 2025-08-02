using UnityEngine;
using System;
public class Ring : MonoBehaviour
{
    public static event EventHandler OnAnyRingDestroyed;
    public GameObject ringEffect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(ringEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            OnAnyRingDestroyed?.Invoke(this, EventArgs.Empty);
        }
    }
}
