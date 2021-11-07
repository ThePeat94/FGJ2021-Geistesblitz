using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityTemplateProjects;

public class HealthUpgrade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerStatsController playerStatsController)) return;
        playerStatsController.HealthController.ResourceController.IncreaseMaximum(2);
        GameObject.Destroy(this.gameObject);
        playerStatsController.HealthController.ResourceController.ResetValue();
        PlayerHUD.Instance.IncreaseHealthMeter();
    }
}
