using Entitas;

namespace BartekNizio.Unity.Template.Entitas
{
    public class MetaObjectEntity : ObjectEntity
    {
        public new MetaEntity Entity => (MetaEntity) base.Entity;

        public MetaEntity Initialize()
        {
            InitializeEntity();
            return Entity;
        }
        
        protected override Entity CreatEntity()
        {
            return Contexts.meta.CreateEntity();
        }

        protected override void AddComponent(IObjectEntityComponent component)
        {
            component.AddComponent(this);
        }
    }
}