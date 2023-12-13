using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDie : MonoBehaviour
{
    public Animator anim;
    public Animator camer_anime;
    public GameObject wheel;
    public bool isPlayerDie;
    private void Start() {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DiePoint") && !isPlayerDie)
        {
            anim.SetTrigger("isDead");
            isPlayerDie = true;
            
        }
    
     
    }
}
