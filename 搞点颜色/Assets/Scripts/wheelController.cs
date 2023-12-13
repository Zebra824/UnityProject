using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelController : MonoBehaviour
{
    public GameObject ice;
    public GameObject ice_2;
    public GameObject wheel;
    private BoxCollider2D boxCollider;
    private Camera mainCamera;

    private Animator anime;
    void Start()
    {
        mainCamera = Camera.main;
        boxCollider = GetComponent<BoxCollider2D>();
        anime = wheel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (boxCollider.OverlapPoint(mousePosition))
            {
                set_ice_inactive();
                anime.Play("Rotate");
            }
        }
    }

    public void set_ice_inactive()
    {
        ice.SetActive(false);
        ice_2.SetActive(false);
    }
}
