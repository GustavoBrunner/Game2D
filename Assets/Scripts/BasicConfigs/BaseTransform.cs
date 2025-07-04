using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTransform : MonoBehaviour
{
    public Transform Tf { get => this.transform; }
    protected virtual void Awake()
    {
        // This method can be overridden in derived classes to perform additional initialization.
    }
    protected virtual void Start()
    {
        // This method can be overridden in derived classes to perform additional setup after Awake.
    }
    protected virtual void Update()
    {
        // This method can be overridden in derived classes to perform updates every frame.
    }
    protected virtual void FixedUpdate()
    {
        // This method can be overridden in derived classes to perform physics updates at fixed intervals.
    }
}
