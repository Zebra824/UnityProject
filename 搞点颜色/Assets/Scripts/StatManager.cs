using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public DistantView distantView;

    private void Awake()
    {
        distantView = GetComponent<DistantView>();
    }
    [Header("×´Ì¬¼àÌý")]
    public PlayerEvent statEvent;

    private void OnEnable()
    {
        statEvent.OnEventRaised += IsGround;
    }

    private void OnDisable()
    {
        statEvent.OnEventRaised -= IsGround;
    }
    private void IsGround(PhysicsCheck physicsCheck)
    {
        distantView.areGround = physicsCheck.isGround;
    }
}
