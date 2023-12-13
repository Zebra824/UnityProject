using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlatform : MonoBehaviour
{
    [Header("SoundEffect")]
    public AudioSource switchPlatfomSound;

    [Header("Change Platform")]
    public ColorIndicator colorIndicator;
    public bool canSwitch = true;
    public bool isTiming = false;
    public GameObject[] obstacles;
    public int currentObstacleIndex = 0;
    void Start()
    {
        colorIndicator = GameObject.Find("ColorIndicator").GetComponent<ColorIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchPlatform();
        colorIndicator.colorIndex = currentObstacleIndex;//同步数据
    }

    private void SwitchPlatform()
    {
        if (Input.GetMouseButton(1) && !isTiming)
        {
            switchPlatfomSound.Play();
            Debug.Log("Pressed right click.");
            isTiming = true;
            canSwitch = false;//简单计时器，不让东西可以一直切换
            Invoke("EnableSwitch", 1f);

            //增加当前物品索引
            currentObstacleIndex++;

            if (currentObstacleIndex >= obstacles.Length)
            {
                currentObstacleIndex = 0;
            }
            for (int i = 0; i < obstacles.Length; i++)
            {
                if (i == currentObstacleIndex)
                { obstacles[i].gameObject.SetActive(true); }
                else
                { obstacles[i].SetActive(false); }
            }//激活平台禁用其他平台


        }
    }
    private void EnableSwitch()
    {
        canSwitch = true;
        isTiming = false;
    }
}
