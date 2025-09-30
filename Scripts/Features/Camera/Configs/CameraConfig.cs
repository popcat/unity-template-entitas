using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Config/Camera")]
    public class CameraConfig : ScriptableObject
    {
        public GameObject gameCameraPrefab;
        
        public float cameraSpeed;
        public float cameraMovementInterpolation;
        public float cameraRotationInterpolation;
        //public int[] cameraAngles = new[] { 0, 45, 90, 135, 180, 225, 270, 315 };
        public int[] cameraAngles = new[] { 45, 135, 225, 315 };
    }
}