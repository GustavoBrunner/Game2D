using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraController
{
    public class CameraController : MonoBehaviour
    {
        private Transform m_target;
        [SerializeField] private float m_speed;

        private void Awake()
        {
            m_target = FindObjectOfType<Movement>().transform;
        }
        private void LateUpdate()
        {
            FollowPlayer();
        }

        private void FollowPlayer()
        {
            if (m_target != null)
            {
                Vector3 newPos = m_target.position;
                newPos.z = transform.position.z;
                transform.position = Vector3.Lerp(
                    transform.position, newPos, Time.deltaTime * m_speed);
            }
        }
    }
}