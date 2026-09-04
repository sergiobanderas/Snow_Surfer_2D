using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayBeforeReload = 1f;
    [SerializeField] ParticleSystem crashEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        int layer = LayerMask.NameToLayer("Ground");
        if (other.gameObject.layer == layer)
        {
            crashEffect.Play();
            Invoke(nameof(ReloadScene), delayBeforeReload);       
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
