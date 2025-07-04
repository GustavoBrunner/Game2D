using InputSystem;
using UnityEngine;

namespace Player
{
    public class Movement : PhysicsController
    {
        Vector2 m_Position;
        Vector2 m_Direction;
        Rigidbody2D m_Rigidbody;
        float m_XAxis;
        float m_YAxis;

        [SerializeField] private float Speed = 5f;

        protected override void Awake()
        {
            base.Awake();
            InitialConfigs();
            
        }
        protected override void Update()
        {
            base.Update();
            Move();
        }

        private void Move()
        {
            m_XAxis = Input.GetAxisRaw("Horizontal");
            m_YAxis = Input.GetAxisRaw("Vertical");
            m_Direction = new Vector2(m_XAxis, m_YAxis).normalized;
            if (m_Direction != Vector2.zero)
            {
                m_Position += m_Direction * (Speed * Time.deltaTime);
                transform.position = m_Position;
            }
        }

        private void InitialConfigs()
        {
            m_Rigidbody = GetComponent<Rigidbody2D>();
            
            m_Rigidbody.freezeRotation = true;
            m_Rigidbody.gravityScale = 0f;
        }
    }
}
