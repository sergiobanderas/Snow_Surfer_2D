using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        int layer = LayerMask.NameToLayer("Ground");
        if (other.gameObject.layer == layer)
        {
            Debug.Log("Player Crashed!");
        }
    }
}
