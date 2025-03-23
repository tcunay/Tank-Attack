using Code.Common.Extensions;
using UnityEngine;

namespace Code.Gameplay.Common.Collisions
{
    public class DrawColliderService : IDrawColliderService
    {
        public void Draw(Collider collider)
        {
            switch (collider)
            {
                case BoxCollider box:
                    CreateBox(collider.gameObject, box);
                    break;
                case SphereCollider sphere:
                    CreateSphere(collider.gameObject, sphere);
                    break;
                case CapsuleCollider capsule:
                    CreateCapsule(collider.gameObject, capsule);
                    break;
            }
        }

        private void CreateBox(GameObject parent, BoxCollider box)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Object.Destroy(cube.GetComponent<Collider>()); // Удаляем коллайдер, чтобы не мешался

            cube.transform.SetParent(parent.transform);
            cube.transform.localPosition = box.center;
            cube.transform.localRotation = parent.transform.rotation;
            cube.transform.localScale = box.size;

            SetMaterial(cube);
        }

        private void CreateSphere(GameObject parent, SphereCollider sphere)
        {
            GameObject sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Object.Destroy(sphereObj.GetComponent<Collider>());

            sphereObj.transform.SetParent(parent.transform);
            sphereObj.transform.localPosition = sphere.center;
            sphereObj.transform.localRotation = parent.transform.rotation;
            sphereObj.transform.localScale = Vector3.one * sphere.radius * 2;

            SetMaterial(sphereObj);
        }

        private void CreateCapsule(GameObject parent, CapsuleCollider capsule)
        {
            GameObject capsuleObj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            Object.Destroy(capsuleObj.GetComponent<Collider>());

            capsuleObj.transform.SetParent(parent.transform);
            capsuleObj.transform.localPosition = capsule.center;
            // Определяем направление капсулы
            Quaternion rotation = parent.transform.rotation;
            Vector3 scale = Vector3.one;

            switch (capsule.direction)
            {
                case 0: // X-axis
                    rotation *= Quaternion.Euler(0, 0, 90);
                    scale = new Vector3(capsule.height * 0.5f, capsule.radius * 2, capsule.radius * 2);
                    break;
                case 1: // Y-axis (по умолчанию)
                    scale = new Vector3(capsule.radius * 2, capsule.height * 0.5f, capsule.radius * 2);
                    break;
                case 2: // Z-axis
                    rotation *= Quaternion.Euler(90, 0, 0);
                    scale = new Vector3(capsule.radius * 2, capsule.radius * 2, capsule.height * 0.5f);
                    break;
            }

            capsuleObj.transform.localRotation = rotation;
            capsuleObj.transform.localScale = new Vector3(
                capsule.radius * 2,
                capsule.height * 0.5f,
                capsule.radius * 2
            );

            SetMaterial(capsuleObj);
        }

        private void SetMaterial(GameObject obj)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Sprites/Default"))
            {
                color = Color.blue.AlphaMultiplied(0.3f)
            };
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            renderer.receiveShadows = false;
        }
    }
}
