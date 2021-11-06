using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class SpreadShotUpgrade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerStatsController playerStatsController)) return;
        playerStatsController.CurrentSpreadShotCount += 1;
        GameObject.Destroy(this.gameObject);
    }
}
