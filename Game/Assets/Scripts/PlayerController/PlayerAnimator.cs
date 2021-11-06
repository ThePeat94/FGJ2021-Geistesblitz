using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace UnityTemplateProjects
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private float m_frequency;
        [SerializeField] private float m_amplitudeFactor;
        private float m_yOffset;

        private void Awake()
        {
            this.m_yOffset = this.transform.localPosition.y;
        }

        private void Update()
        {
            var currentPos = this.transform.position;
            currentPos.y += this.m_amplitudeFactor * Mathf.Sin(this.m_frequency * Time.time);
            this.transform.position = currentPos;
        }
    }
}