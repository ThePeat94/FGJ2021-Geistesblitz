using System;
using System.Collections;
using System.Collections.Generic;
using EventArgs;
using Scriptables;
using UnityEngine;

public class ResourceController
{
    private float m_currentValue;
    private EventHandler<ResourceValueChangedEventArgs> m_resourceValueChanged;
    private EventHandler<ResourceValueChangedEventArgs> m_maxValueChanged;
    
    public ResourceController(ResourceData data)
    {
        this.MaxValue = data.InitMaxValue;
        this.m_currentValue = data.StartValue;
    }
    
    public float CurrentValue => this.m_currentValue;
    public float MaxValue { get; set; }
    
    public event EventHandler<ResourceValueChangedEventArgs> ResourceValueChanged
    {
        add => this.m_resourceValueChanged += value;
        remove => this.m_resourceValueChanged -= value;
    }
    
    public event EventHandler<ResourceValueChangedEventArgs> MaxValueChanged
    {
        add => this.m_maxValueChanged += value;
        remove => this.m_maxValueChanged -= value;
    }
    
    public void ResetValue()
    {
        this.m_currentValue = this.MaxValue;
        this.m_resourceValueChanged?.Invoke(this, new ResourceValueChangedEventArgs(this.m_currentValue));
    }
    
    public bool UseResource(float amount)
    {
        if(!this.CanAfford(amount))
            return false;

        this.m_currentValue -= amount;
        this.m_resourceValueChanged?.Invoke(this, new ResourceValueChangedEventArgs(this.m_currentValue));
        return true;
    }
    
    public bool CanAfford(float amount)
    {
        return this.m_currentValue > 0 && amount <= this.m_currentValue;
    }

    public void Add(float value)
    {
        this.m_currentValue += value;
        this.m_resourceValueChanged?.Invoke(this, new ResourceValueChangedEventArgs(this.m_currentValue));
    }

    public void IncreaseMaximum(float value)
    {
        this.MaxValue += value;
        this.m_maxValueChanged?.Invoke(this, new ResourceValueChangedEventArgs(this.MaxValue));
    }
}
