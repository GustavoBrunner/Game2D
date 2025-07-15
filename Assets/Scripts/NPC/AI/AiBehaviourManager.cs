using UnityEngine;
namespace Npc
{
    public class AiBehaviourManager : MonoBehaviour
    {
        NpcBaseState m_currentState;

        public NpcBaseState IdleState = new IdleState();
        
        public NpcBaseState RoamingState = new RoamingState();

        public NpcBaseState GoToSleepState = new GoToSleepState();

        private void Start()
        {
            if (m_currentState == null)
            {
                m_currentState = IdleState;
                m_currentState.OnEnterState(this);
            }
        }

        private void Update()
        {
            m_currentState.UpdateState(this);
        }

        public void ChangeState(NpcBaseState newState)
        {
            if (m_currentState != null)
            {
                m_currentState.OnExitState(this);
            }
            m_currentState = newState;
            m_currentState.OnEnterState(this);
        }


    }
}