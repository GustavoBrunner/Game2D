using InteractionSystem;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObjects : PhysicsController, IMouseInteractable
{
    public Vector2 ObjectPosition => transform.position;

    public float InteractionRadius => 5f;

    [field: SerializeField] public UnityEvent InteractionEvent { get; set; }

    public virtual void OnMouseInteract()
    {
        Debug.Log(this.gameObject.name + ObjectPosition);
        InteractionEvent?.Invoke();
    }
}
