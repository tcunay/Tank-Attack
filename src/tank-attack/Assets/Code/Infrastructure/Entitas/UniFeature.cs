using System.Collections.Generic;
using Entitas;
using Entitas.VisualDebugging.Unity;

namespace Code.Infrastructure.Entitas
{
    public abstract class UniFeature : Feature, IFixedExecuteSystem
    {
        private readonly List<SystemInfo> _fixedExecuteSystemInfos = new();
        private readonly List<IFixedExecuteSystem> _fixedExecuteSystems = new();
        
        public override global::Entitas.Systems Add(ISystem system)
        {
            var systems = base.Add(system);

            if (system is IFixedExecuteSystem fixedExecuteSystem)
            {
                _fixedExecuteSystemInfos.Add(systemInfo);
                _fixedExecuteSystems.Add(fixedExecuteSystem);
            }

            return systems;
        }

        public void FixedExecute()
        {
            foreach (IFixedExecuteSystem fixedExecuteSystem in _fixedExecuteSystems)
            {
                fixedExecuteSystem.FixedExecute();
            }
        }
    }
}