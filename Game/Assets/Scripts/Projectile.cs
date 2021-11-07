using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 ShootDirection { get; set; }
    public GameObject Sender { get; set; }

    private void Awake()
    {
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.ShootDirection * Time.deltaTime * 20f;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit" + other.gameObject.name);
        if (other.GetComponent<Projectile>() != null)
            return;
        
        if (other.TryGetComponent(out HealthController playerHealthController) && this.Sender != other.gameObject)
        {
            playerHealthController.TakeDamage(1);   
        }
        Destroy(this.gameObject);

    }
}
