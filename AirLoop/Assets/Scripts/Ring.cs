using UnityEngine;
public class Ring : MonoBehaviour
{
    public GameObject ringEffect;

    public RingManager ringManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ringManager.currentRings++;
            ringManager.UpdateRingsText();
            Instantiate(ringEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
