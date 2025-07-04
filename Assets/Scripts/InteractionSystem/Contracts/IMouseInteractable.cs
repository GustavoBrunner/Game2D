using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace InteractionSystem
{
    public interface IMouseInteractable
    {
        public Vector2 ObjectPosition { get; }

        public float InteractionRadius { get; }

        public UnityEvent InteractionEvent { get; set; }

        void OnMouseInteract();
    }
}