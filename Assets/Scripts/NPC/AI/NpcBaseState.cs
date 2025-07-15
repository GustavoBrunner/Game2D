using Npc;
using UnityEngine;

public abstract class NpcBaseState 
{
    public abstract void OnEnterState(AiBehaviourManager behaviourData);

    public abstract void OnExitState(AiBehaviourManager behaviourData);

    public abstract void UpdateState(AiBehaviourManager behaviourData);
}
