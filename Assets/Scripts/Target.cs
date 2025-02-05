using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    public bool targetIsDead = false;
    private float _currentHealth;

    public event Action<Target> OnDestroy;
    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
           OnDestroy?.Invoke(this);
            Destroy(gameObject);
            
        }
            
    }
    
}
