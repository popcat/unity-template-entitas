using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{ 
    [ExecuteAlways]
    public class SpriteFaceTheCamera : MonoBehaviour
    {
        [ExecuteAlways]
        public void LateUpdate()
        {
#if UNITY_EDITOR
            if(Camera.main == false) return;
#endif
            transform.forward = Camera.main.transform.forward;
        }
    }
}