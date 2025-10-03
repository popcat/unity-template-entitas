using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace BartekNizio.Unity.Template.Entitas.Platformer2D
{
    [Game, Unique]
    public class Platformer2DCharacterControllerComponent : IComponent
    {
        public CharacterControllerData ControllerData;
    }
}