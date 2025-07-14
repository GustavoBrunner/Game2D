using UnityEditor;
using UnityEngine;

namespace Npc
{
    public class Node : MonoBehaviour
    {
        [SerializeField] private float m_Radius = 2f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, m_Radius);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.1f);
        }

    }
}