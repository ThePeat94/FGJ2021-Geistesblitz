using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "Resource Data", menuName = "Data/Resource Data", order = 0)]
    public class ResourceData : ScriptableObject
    {
        [SerializeField] private float m_initMaxValue;
        [SerializeField] private float m_startValue;

        public float InitMaxValue => this.m_initMaxValue;
        public float StartValue => this.m_startValue;
    }
}