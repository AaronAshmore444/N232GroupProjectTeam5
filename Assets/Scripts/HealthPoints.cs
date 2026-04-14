using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public float StartingHealth = 100f;

    public float CurrentHealth

    {
        get { return _HealthPoints; }
        set
        {
            _HealthPoints = Mathf.Clamp(value, 0, StartingHealth);

            if (_HealthPoints <= 0)
            {
                Die();
            }
        }
    }

    private float _HealthPoints;

    void Start()
    {
        CurrentHealth = StartingHealth;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}