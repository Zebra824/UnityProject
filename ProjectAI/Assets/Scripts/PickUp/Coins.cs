using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text text;
    public SpriteRenderer codeRenderer;

    private void Start()
    {
        codeRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            codeRenderer.enabled = false;
            text.gameObject.SetActive(true);
            StartCoroutine(HideText());
        }
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(3f);
        text.gameObject.SetActive(false);
    }
}
