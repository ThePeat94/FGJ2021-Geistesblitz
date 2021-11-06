using System;
using EventArgs;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] private HealthController m_playerHealthController;
        [SerializeField] private Slider m_healthSlider;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            this.m_healthSlider.minValue = 0;
        }

        private void Start()
        {
            this.m_playerHealthController.ResourceController.ResourceValueChanged += PlayerHealthChanged;
            this.m_healthSlider.maxValue = this.m_playerHealthController.ResourceController.MaxValue;
            this.m_healthSlider.value = this.m_playerHealthController.ResourceController.CurrentValue;
        }

        private void PlayerHealthChanged(object sender, ResourceValueChangedEventArgs e)
        {
            this.m_healthSlider.value = e.NewValue;
        }
    }
}