using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace BartekNizio.Unity.Template.Entitas
{
    [Meta, Unique, Cleanup(CleanupMode.DestroyEntity)]
    public class SceneUnloadCompletedComponent : IComponent
    {
    }
}