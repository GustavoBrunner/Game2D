using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "New_Weapon", menuName = "Weapon")]
    public class WeaponBase : ScriptableObject
    {
        public int Damage;
        public float Range;
    }
}