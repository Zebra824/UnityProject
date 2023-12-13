using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    Animator anim;
    public bool isFade = false;
    private BoxCollider2D boxCollider;
    private Camera mainCamera;
    private void Start() {
        anim = GetComponent<Animator>();
        mainCamera = Camera.main;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            if (boxCollider.OverlapPoint(mousePosition) && !isFade)
            {
                anim.SetTrigger("PlayFade");
                anim.SetTrigger("PLayGround");
                isFade = true;
            }
        //Debug.Log("trigeer");
        }
    }
    public void disactive(){
        Debug.Log("disactive");
        this.gameObject.SetActive(false);
    }
}
