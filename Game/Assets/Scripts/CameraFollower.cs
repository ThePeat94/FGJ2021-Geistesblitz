using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform m_target;

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(this.m_target.transform.position.x + 2, this.transform.position.y, this.m_target.position.z);
    }
}
