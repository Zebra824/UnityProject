using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorIndicator : MonoBehaviour
{
    public Renderer colorRender;
    public Color[] colors;
    public int colorIndex;

    private void Update()
    {
        ColorSwitch(colorIndex);
    }
    private void Start()
    {
        colorRender = GetComponent<Renderer>();
    }

    public void ColorSwitch(int i)
    {
        if(i>=0&&i<colors.Length)
        {
            colorRender.material.color = colors[i];
        }
    }
}
