using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem snowTrailEffect;

    void OnCollisionEnter2D(Collision2D other)
    {
       int layer = LayerMask.NameToLayer("Ground");
       if (other.gameObject.layer == layer)
       {
            snowTrailEffect.Play();
       }
    }

    void OnCollisionExit2D(Collision2D other)
    {
       int layer = LayerMask.NameToLayer("Ground");
       if (other.gameObject.layer == layer)
       {
            snowTrailEffect.Stop();
       }
    }
}
