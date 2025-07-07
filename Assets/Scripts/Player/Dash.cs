using InputSystem;
using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PhysicsController
{
    Movement m_Movement;
    public bool IsDashing { get; private set; }
    [SerializeField] Vector2 m_DashDirection;

    [SerializeField] float m_DashSpeed = 10f;
    [SerializeField] float m_DashDuration = 0.2f;
    [SerializeField] float m_DashCooldown = 1f;
    [SerializeField] float m_LastDashTime;

    protected override void Awake()
    {
        base.Awake();
        m_Movement = GetComponent<Movement>();
    }

    protected override void Update()
    {
        base.Update();
        if (!IsDashing)
        {
            m_DashDirection = m_Movement.Direction;
            if (InputController.Instance.IsRunning && 
                Time.time >= m_LastDashTime + m_DashCooldown && 
                m_DashDirection != Vector2.zero)
            {
                StartCoroutine(DashCoroutine());
            }
        }
    }

    private IEnumerator DashCoroutine()
    {
        IsDashing = true;
        m_LastDashTime = Time.time;

        float dashEndTime = Time.time + m_DashDuration;

        while (Time.time < dashEndTime)
        {
            Rb.velocity = m_DashDirection * m_DashSpeed;
            yield return null;
        }
        IsDashing = false;
    }
}
