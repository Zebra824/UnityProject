using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/PlayerEvent")]
public class PlayerEvent : ScriptableObject
{
    public UnityAction<PhysicsCheck> OnEventRaised;
    
    public void RaiseEvent(PhysicsCheck physicsCheck)
    {
        OnEventRaised?.Invoke(physicsCheck);
    }

}
