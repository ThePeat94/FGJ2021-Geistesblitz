using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "Level Data X", menuName = "Data/Level Data", order = 0)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private int m_width;
        [SerializeField] private int m_height;
        [SerializeField] private int m_threshold;

        public int Width => this.m_width;
        public int Height => this.m_height;
        public int Threshold => this.m_threshold;
    }
}