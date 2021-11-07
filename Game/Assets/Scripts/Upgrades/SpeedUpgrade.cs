using UI;
using UnityEngine;
using UnityTemplateProjects;

namespace Upgrades
{
    public class SpeedUpgrade : MonoBehaviour
    {
        [SerializeField] private AudioClip m_sound;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerStatsController playerStatsController)) return;
            AudioSource.PlayClipAtPoint(this.m_sound,this.transform.position, 0.5f);
            playerStatsController.CurrentMovementSpeed += 1.0f;
            GameObject.Destroy(this.gameObject);
            PlayerHUD.Instance.IncreaseSpeedMeter();
        }
    }
}
