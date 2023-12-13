using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsCheck : MonoBehaviour
{
    [Header("¼ì²â²ÎÊý")]
    public Vector2 bottomOffset;
    public float checkRaduis;
    public LayerMask groundLayer;

    [Header("×´Ì¬")]
    public bool isGround;


    public UnityEvent<PhysicsCheck> IsGround;
    private void Update()
    {
        Check();
    }
    public void Check()
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(bottomOffset.x * transform.localScale.x, bottomOffset.y), checkRaduis, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(bottomOffset.x * transform.localScale.x, bottomOffset.y), checkRaduis);
    }
}
