using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class SpreadShotUpgrade : MonoBehaviour
{
    [SerializeField] private AudioClip m_sound;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerStatsController playerStatsController)) return;
        AudioSource.PlayClipAtPoint(this.m_sound,this.transform.position, 0.5f);
        playerStatsController.CurrentSpreadShotCount += 1;
        GameObject.Destroy(this.gameObject);
    }
}
