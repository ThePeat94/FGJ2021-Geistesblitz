using UnityEngine;
using UnityTemplateProjects;

namespace Upgrades
{
    public class PowerUpgrade : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerStatsController playerStatsController)) return;
            playerStatsController.CurrentAttackDamage += 1;
            GameObject.Destroy(this.gameObject);
        }
    }
}
