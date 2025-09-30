using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
    public static class DebugLogger
    {
        public static void Log(string message)
        {
#if DEBUG_LOG
            Debug.Log($"{message}");
#endif
        }
        
        public static void LogWarning(string message)
        {
#if DEBUG_LOG
            Debug.LogWarning($"{message}");
#endif
        }
        
        public static void LogError(string message)
        {
#if DEBUG_LOG
            Debug.LogError($"{message}");
#endif
        }
    }
}