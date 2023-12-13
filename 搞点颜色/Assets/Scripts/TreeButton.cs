using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeButton : MonoBehaviour
{
    public GameObject leaf;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setLeaveTrue()
    {
        print("hesr");
        leaf.SetActive(true);
    }
}
