using System;
using UnityEngine;

namespace UnityTemplateProjects.Utils
{
    public class RotateToCamera : MonoBehaviour
    {
        private Camera m_target ;

        public void Start()
        {
            this.m_target = Camera.main;
        }

        public void Update()
        {
            var newVector = this.m_target.transform.position - this.transform.position; 
            this.transform.rotation = Quaternion.LookRotation( newVector );
        } 
    }
}