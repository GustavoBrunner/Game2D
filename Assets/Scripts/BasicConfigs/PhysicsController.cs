using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PhysicsController : BaseTransform
{
    public Rigidbody2D Rb { get; private set; }
    public Collider2D Clldr { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Rb = GetComponent<Rigidbody2D>();
        Rb.gravityScale = 0f;
        Rb.freezeRotation = true;
        Clldr = GetComponent<Collider2D>();
    }

}
