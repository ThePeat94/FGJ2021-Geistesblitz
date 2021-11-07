using UnityEngine;
using Cinemachine;

namespace UnityTemplateProjects
{
    
    
    [ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
    public class LockCameraY : CinemachineExtension
    {
        [Tooltip("Lock the camera's Y position to this value")]
        public float m_yPosition = 7.38f;
 
        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (stage == CinemachineCore.Stage.Body)
            {
                var pos = state.RawPosition;
                pos.y = this.m_yPosition;
                state.RawPosition = pos;
            }
        }
    }
}