using System;
using Scriptables;
using UnityEngine;


public class HealthController : MonoBehaviour
{
    [SerializeField] private ResourceData m_healthData;
    private ResourceController m_resourceController;
    private EventHandler m_healthDownToZero;
    
    private void Awake() 
    {
        m_resourceController = new ResourceController(m_healthData);
    }
    
    public event EventHandler HealthDownToZero
    {
        add => this.m_healthDownToZero += value;
        remove => this.m_healthDownToZero -= value;
    }

    public void TakeDamage(int value)
    {
        if (!this.m_resourceController.UseResource(value))
            this.Kill();
        
        if (this.m_resourceController.CurrentValue <= 0)
            this.Kill();
    }

    private void Kill()
    {
        m_resourceController.UseResource(m_resourceController.CurrentValue);
        this.m_healthDownToZero?.Invoke(this, System.EventArgs.Empty);
    }

    public void Heal(int value)
    {
        m_resourceController.Add(value);
    }

    public void SetToFullHealth()
    {
        m_resourceController.ResetValue();
    }

    public ResourceController GetResourceController()
    {
        return this.m_resourceController;
    }
}
