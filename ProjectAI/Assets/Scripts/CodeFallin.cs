using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CodeFallin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cavans;
    public GameObject code;
    GameObject codeChild;
    // 设定生成时间
    private float codeCount = 3;
    //设定坠落生成开关
    private int InstantiateState =1;
    //限制update帧数
    private float updateTime;
    //删除时间
    private float deleteTime;
    void Fallin()
    {
            codeChild = Instantiate(code);
            codeChild.transform.parent = Cavans.transform;
            Rigidbody2D rb = codeChild.GetComponent<Rigidbody2D>();
            float rbVelocity = Random.Range(-9.5f, 9.5f);
            float rbY = Random.Range(0.1f, 1.2f);
            rb.velocity =new Vector3(0, rbVelocity, 0);

            float positionX = Random.Range(-9.5f, 9.5f);
            codeChild.transform.position = new Vector3(positionX, 9, 0);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        updateTime += Time.deltaTime;
        deleteTime += Time.deltaTime;
        if (updateTime >= 0.1f) { 
            updateTime = 0;
            Fallin();
        }
       //删除生成的文字
        if (deleteTime >= 60f)
        {
            GameObject[] codeChild = GameObject.FindGameObjectsWithTag("FallinCode");
            foreach (GameObject child in codeChild)
            {
                Destroy(child);
            }
            deleteTime = 0;
        }
    }
 
}
