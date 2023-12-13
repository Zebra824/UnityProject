using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //要完成鼠标操控玩家，左键拖拽（拖拽的越远玩家移动的越远，通过力的添加完成这个逻辑）玩家移动，右键（使不同颜色的平台显性或消失）
    [Header("Dynamically")]
    public Vector2 playerPosition;
    public Vector2 mouseDownPosition;
    public Vector2 mouseDelta;
    public float forceMagnitude;
    public Vector2 distance;
    private Rigidbody2D playerRb2D;
    public CircleCollider2D circleCollider2D;
    public bool aimmode;

    [Header("SoundEffect")]
    public AudioSource moveSound;

    [Header("Change Platform")]
    public ColorIndicator colorIndicator;
    public bool canSwitch = true;
    public bool isTiming = false;
    public GameObject[] obstacles;
    public int currentObstacleIndex = 0;

    [Header("GroundDetection")]
    public bool isGround = false;
    public LayerMask groundLayer;

    public Vector2 respwan_position;




    private void Start()
    {
        playerRb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GroundDetection();
        colorIndicator.colorIndex = currentObstacleIndex;//同步数据

        if (!aimmode) return;
        mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPosition = new Vector2(transform.position.x, transform.position.y);
        mouseDelta = mouseDownPosition - playerPosition;//获取鼠标输入和玩家位置的坐标差
        float maxMagnitude = circleCollider2D.radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;//如果超过了最大范围，就设置向量为最大范围
        }

        //鼠标左键抬起，施加力
        if (Input.GetMouseButtonUp(0))
        {
            aimmode = false;
            if (isGround)
            {
                moveSound.Play();
                playerRb2D.gravityScale = 0.5f;
                playerRb2D.AddForce(mouseDelta * forceMagnitude);
            }
            else { return; }

        }


        

    }
    //当鼠标左键按下
    private void OnMouseDown()
    {
        aimmode = true;
        playerRb2D.gravityScale = 0.5f;

    }



    private void GroundDetection()
    {
        var rayCastAll = Physics2D.RaycastAll(transform.position, Vector2.down, 0.5f, groundLayer);
        if (rayCastAll.Length > 0)
        {
            isGround = true;
            Debug.Log("isGround");
        }
        else
        {
            isGround = false;
            Debug.Log("Jumping");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FinishPoint"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }




}

