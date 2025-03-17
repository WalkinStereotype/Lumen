using UnityEngine;

public class SlotColliderChecker : MonoBehaviour
{
    public GameObject internalKey;
    public GameObject gate;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            collision.gameObject.SetActive(false);
            internalKey.SetActive(true);
            gate.SetActive(true);
            AudioManager.instance.PlayOrbUnlock();
        }
    }
}
