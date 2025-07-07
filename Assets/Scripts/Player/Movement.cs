using UnityEngine;

namespace Player
{
    public class Movement : PhysicsController
    {
        Vector2 m_Position;
        public Vector2 Direction { get; private set; }
        Rigidbody2D m_Rigidbody;
        [SerializeField] float m_XAxis;
        [SerializeField] float m_YAxis;

        [SerializeField] private float Speed = 5f;

        private Dash m_Dash;

        public Vector2 VelocityDebug;
        protected override void Awake()
        {
            base.Awake();
            InitialConfigs();
            
        }
        protected override void Update()
        {
            base.Update();
            if(m_Dash.IsDashing)
                return;
            Move();
            
        }

        private void Move()
        {
            m_XAxis = Input.GetAxisRaw("Horizontal");
            m_YAxis = Input.GetAxisRaw("Vertical");
            Direction = new Vector2(m_XAxis, m_YAxis).normalized;
            Rb.velocity = Direction * Speed;
            VelocityDebug = Rb.velocity;
        }

        private void InitialConfigs()
        {
            m_Rigidbody = GetComponent<Rigidbody2D>();
            m_Dash = GetComponent<Dash>();

            m_Rigidbody.freezeRotation = true;
            m_Rigidbody.gravityScale = 0f;
        }
    }
}
