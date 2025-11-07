using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityTemplateProjects;

public class HealthUpgrade : MonoBehaviour
{
    
    [SerializeField] private AudioClip m_sound;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerStatsController playerStatsController)) return;
        AudioSource.PlayClipAtPoint(this.m_sound,this.transform.position, 0.5f);
        playerStatsController.HealthController.ResourceController.IncreaseMaximum(2);
        GameObject.Destroy(this.gameObject);
        playerStatsController.HealthController.ResourceController.ResetValue();
        PlayerHUD.Instance.IncreaseHealthMeter();
    }
}
