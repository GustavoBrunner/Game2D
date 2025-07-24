using InputSystem;
using UnityEngine;
using Weapons;

namespace Player {
    public class Attack : MonoBehaviour {
        private const string ATTACK_ANIMATION_TRIGGER = "isAttacking";

        public bool IsFight { get; private set; } = false;

        [SerializeField] int m_Damage = 10;
        [SerializeField] float m_AttackRange = 1.5f;
        [SerializeField] float m_AttackCooldown = 1f;

        [SerializeField] Animator m_WeaponAnimation;

        [SerializeField] WeaponController m_equippedWeapon;


        private void Update() {
            if(!IsFight)
                return;
            if(InputController.Instance.IsInteracting) {
                if (m_WeaponAnimation != null) {
                    m_WeaponAnimation.SetBool(ATTACK_ANIMATION_TRIGGER, true);
                }
            }

        }


    }
}