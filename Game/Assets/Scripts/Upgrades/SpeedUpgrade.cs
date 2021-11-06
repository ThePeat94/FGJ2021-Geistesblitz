using UnityEngine;
using UnityTemplateProjects;

namespace Upgrades
{
    public class SpeedUpgrade : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerStatsController playerStatsController)) return;
            playerStatsController.CurrentMovementSpeed += 5.0f;
            GameObject.Destroy(this.gameObject);
        }
    }
}
