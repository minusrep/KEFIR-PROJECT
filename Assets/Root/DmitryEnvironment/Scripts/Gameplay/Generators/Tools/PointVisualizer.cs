using UnityEngine;

namespace Root.Rak.Gameplay.Generators
{
    public class PointVisualizer : MonoBehaviour
    {
        public Vector3 Position => transform.position;

        [SerializeField] private Color _color = Color.red;
        [SerializeField] [Range(0, 2)] private float _radius = 1;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = _color;

            Gizmos.DrawSphere(transform.position, _radius);
        }
#endif
    }
}