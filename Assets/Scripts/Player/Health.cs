using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3, sfx4;
    public float health;
    public float maxHealth;
    public Image HealthBar;

    private bool isDead;

    public GameManager gameManager;
    private void Start()
    {
        maxHealth = health;
    }
    private void Update()
    {
        HealthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0 && !isDead)
        {
            isDead = true;
            gameManager.GameOver();
            Debug.Log("Dead");
            src.clip = sfx4;
            src.Play();
        }
    }
}