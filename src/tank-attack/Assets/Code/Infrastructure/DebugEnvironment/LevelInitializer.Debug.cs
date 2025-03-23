using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Vehicle.Setup;
using UnityEngine;

namespace Code.Infrastructure.Installers.Initializers.BattleScene
{
    [ExecuteAlways]
    public partial class LevelInitializer
    {
        public const string WaypointsDebugObject = "WAY_POINT_DEBUG";
        
        private readonly List<LineRenderer> _lineRenderers = new();
        
        private Material _lineMaterial;

        private void Start()
        {
            InitializeLineRenderer();
        }

        private void OnDestroy()
        {
            ClearLines();
        }

        private void InitializeLineRenderer()
        {
            ClearLines();
            
            _lineMaterial = new Material(Shader.Find("Sprites/Default"))
            {
                color = Color.green.AlphaMultiplied(0.2f)
            };

            GameObject linesParent = new GameObject(WaypointsDebugObject);
            
            foreach (var wayPointsMoveSetup in _enemiesSetups.Select(x => x.VehicleSetup.MoveSetup))
            {
                GameObject wayPointsLine = CreateWayPointsLine(wayPointsMoveSetup);

                wayPointsLine.transform.parent = linesParent.transform;
            }
        }

        private GameObject CreateWayPointsLine(WayPointsMoveSetup wayPointsMoveSetup)
        {
            if (wayPointsMoveSetup.WayPoints.IsNullOrEmpty())
            {
                return null;
            }

            GameObject lineObject = new GameObject("WayPointsLine");
            LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

            lineRenderer.material = _lineMaterial;
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
            lineRenderer.positionCount = wayPointsMoveSetup.WayPoints.Length;

            for (int i = 0; i < wayPointsMoveSetup.WayPoints.Length; i++)
            {
                lineRenderer.SetPosition(i, wayPointsMoveSetup.WayPoints[i].position);
            }

            _lineRenderers.Add(lineRenderer);

            return lineObject;
        }
        
        private void ClearLines()
        {
            foreach (var lineRenderer in _lineRenderers)
            {
                DestroyImmediate(lineRenderer.gameObject);
            }

            _lineRenderers.Clear();

            DestroyImmediate(GameObject.Find(WaypointsDebugObject));
        }
    }
}