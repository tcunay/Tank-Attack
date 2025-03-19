using Entitas;

namespace Code.Infrastructure.Entitas
{
    public interface IFixedExecuteSystem : ISystem
    {
        void FixedExecute();
    }
}