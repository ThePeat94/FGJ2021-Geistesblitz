using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var time = Time.time;
        transform.position = new Vector3(transform.position.x + (Mathf.Sin(time)*0.005f), transform.position.y + (Mathf.Cos(time) * 0.001f), transform.position.z + (Mathf.Cos(time)*0.005f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collsion");
    }
}
