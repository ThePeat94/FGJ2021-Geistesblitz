using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UpgradeMeterUI : MonoBehaviour
    {
        [SerializeField] private Slider m_slider;

        private void Awake()
        {
            this.m_slider.maxValue = 5;
            this.m_slider.value = 0;
        }


        public void IncreaseSlider()
        {
            this.m_slider.value++;
        }

        public void ResetSlider()
        {
            this.m_slider.value = 0;
        }

    }
}