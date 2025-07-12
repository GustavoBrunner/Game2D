
using UnityEngine;
namespace Npc
{
    [CreateAssetMenu(fileName = "AiBehaviour", menuName = "NPC/AiBehaviour", order = 1)]
    public class AiBehaviour : ScriptableObject
    {
        public int Id;
        public NpcState State;

        public float Speed = 5.0f;
        public string Name;
        public string ActualSceneName;
        public string NextSceneName;

        public string Description;
        public Sprite Icon;
        public Sprite NpcSprite;

        public int Day;
        public int Hour;
        public int Minute;

        public bool IsActive = true;

        




        public AiBehaviour()
        {
            this.Id = (int)Random.Range(1,1000000) * 100;
        }
    }
}