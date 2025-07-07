using InputSystem;
using Player;
using UnityEngine;

namespace InteractionSystem
{
    public class MouseInteraction : MonoBehaviour
    {
        Vector2 m_MousePosition;
        RaycastHit2D m_Hit;

        public Transform PlayerTf { get => FindAnyObjectByType<Movement>().transform; }

        private void Update()
        {
            InteractionSensor();
        }

        private void InteractionSensor()
        {
            m_MousePosition = Input.mousePosition;
            m_Hit = Physics2D.Raycast(Camera.main
                .ScreenToWorldPoint(m_MousePosition), Vector2.zero, 0f);
            //Debug.Log(m_MousePosition);
            if (m_Hit.collider == null)
                return;
            
            if (!m_Hit.collider.TryGetComponent<IMouseInteractable>(out var interactable))
                return;
            
            bool distance = Vector2.Distance(PlayerTf.position, 
                interactable.ObjectPosition) <= interactable.InteractionRadius;
            

            if ((InputController.Instance.IsInteracting || 
                InputController.Instance.IsAlternativeInteracting) & 
                distance)
            {
                interactable.OnMouseInteract();
            }
        }
    }
}