using Code.Common.Extensions;
using Code.Gameplay.Features.TargetCollection;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Compass.Systems
{
    public class MoveMarksSystem : IExecuteSystem
    {
        private const float MaxAngle = 180;
        
        private readonly IGroup<GameEntity> _compassMarks;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _compasses;

        public MoveMarksSystem(GameContext game)
        {
            _compassMarks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CompassMark,
                    GameMatcher.View
                    ).NoneOf(GameMatcher.Destructed));
            
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero, 
                    GameMatcher.WorldPosition,
                    GameMatcher.WorldRotation
                    ));
            
            _compasses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CompassView
                ));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity compass in _compasses)
            foreach (GameEntity mark in _compassMarks)
            {
                GameEntity enemy = mark.Target();

                float xPosition = CalculatePosition(enemy, hero, compass);

                // Устанавливаем позицию на UI
                mark.View.gameObject.transform.localPosition = mark.View.gameObject.transform.localPosition.SetX(xPosition);
            }
        }

        private static float CalculatePosition(GameEntity enemy, GameEntity hero, GameEntity compass)
        {
            // Вектор от героя к врагу
            Vector3 toEnemy = (enemy.WorldPosition - hero.WorldPosition).normalized;

            // Направление взгляда героя (предположим, что это forward из его worldRotation)
            Vector3 heroForward = hero.worldRotation.Value * Vector3.forward;

            // Угол между forward героя и направлением на врага (в плоскости XZ)
            Vector3 flatForward = new Vector3(heroForward.x, 0, heroForward.z).normalized;
            Vector3 flatToEnemy = new Vector3(toEnemy.x, 0, toEnemy.z).normalized;

            float angle = Vector3.SignedAngle(flatForward, flatToEnemy, Vector3.up);

            // Допустим, ты хочешь, чтобы угол ±90° отображался как ±компасWidth / 2
            float compassWidth = compass.CompassView.MarkParent.rect.width; // ширина UI-компаса в пикселях
            //float maxAngle = f; // максимально допустимый угол видимости

            // Ограничим угол (опционально)
            float clampedAngle = Mathf.Clamp(angle, -MaxAngle, MaxAngle);

            // Нормализуем угол в диапазон -1..1, потом умножим на половину ширины
            float normalized = clampedAngle / MaxAngle;
            float xPos = normalized * (compassWidth / 2f);
            
            return xPos;
        }
    }
}