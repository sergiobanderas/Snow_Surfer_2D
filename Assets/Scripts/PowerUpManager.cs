using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private PowerUpScriptableObject powerUpData;

    PlayerController playerController;
    SpriteRenderer spriteRenderer;
    

    float timeLeft;

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeLeft = powerUpData.Time;
    }

    void Update()
    {
        CountDownPowerUpTime();

    }

    private void CountDownPowerUpTime()
    {
        if (spriteRenderer.enabled == false)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;

                if (timeLeft <= 0)
                {
                    playerController.DeactivatePowerUpEffect(powerUpData);

                }
        
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
            playerController.ActivatePowerUpEffect(powerUpData);            
        }


    }

    
}
