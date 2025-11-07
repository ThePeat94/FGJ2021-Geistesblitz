using UI;
using UnityEngine;
using UnityTemplateProjects;

namespace Upgrades
{
    public class PowerUpgrade : MonoBehaviour
    {
        [SerializeField] private AudioClip m_sound;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerStatsController playerStatsController)) return;
            AudioSource.PlayClipAtPoint(this.m_sound,this.transform.position, 0.5f);
            playerStatsController.CurrentAttackDamage += 1;
            GameObject.Destroy(this.gameObject);
            PlayerHUD.Instance.IncreaseAttackMeter();
        }
    }
}
