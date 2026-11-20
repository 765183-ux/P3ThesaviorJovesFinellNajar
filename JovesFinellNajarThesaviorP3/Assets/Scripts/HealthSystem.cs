using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    [Header("Invulnerability (Optional)")]
    [SerializeField] private float invulnerabilityDuration = 0.5f;
    private float invulnerabilityTimer;

    [Header("Events")]
    // Passes normalized health (0.0 to 1.0) for UI bars
    public UnityEvent<float> OnHealthChanged;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealed;
    public UnityEvent OnDeath;

    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;
    public bool IsDead => currentHealth <= 0;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        // Initialize UI on start
        OnHealthChanged?.Invoke(currentHealth / maxHealth);
    }

    private void Update()
    {
        if (invulnerabilityTimer > 0)
        {
            invulnerabilityTimer -= Time.deltaTime;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (IsDead || invulnerabilityTimer > 0 || damageAmount <= 0) return;

        ModifyHealth(-damageAmount);
        invulnerabilityTimer = invulnerabilityDuration;
        OnDamaged?.Invoke();

        if (IsDead)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        if (IsDead || healAmount <= 0) return;

        ModifyHealth(healAmount);
        OnHealed?.Invoke();
    }

    private void ModifyHealth(float amount)
    {
        // Clamp ensures health never drops below 0 or exceeds maxHealth
        currentHealth = Mathf.Clamp(currentHealth + amount, 0f, maxHealth);
        OnHealthChanged?.Invoke(currentHealth / maxHealth);
    }

    private void Die()
    {
        //OnDeath?.Invoke();
        // Default behavior: destroy the object. 
        // Remove this line if you handle death via animations or respawns in OnDeath.
        //Destroy(gameObject);
    }
}