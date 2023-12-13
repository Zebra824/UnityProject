using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    private PlayerAnimation playerAnimation;
    
    [Header("基本参数")]
    public bool isJump;
    public float speed;
    public float jumpForce;
    public Vector2 inputDirection;
    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        physicsCheck = GetComponent<PhysicsCheck>();
        rb = GetComponent<Rigidbody2D>();
        inputControl = new PlayerInputControl();
        isJump = false;
        inputControl.Gameplay.jump.started += Jump;

    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    void Update()
    {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
        //float move_x = Input.GetAxis("Horizontal");
        //float move_y = Input.GetAxis("Vertical");
        //transform.Translate(new Vector3(move_x, move_y, 0) * speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0) && physicsCheck.isGround)
        {
            playerAnimation.Ability();
        }

    }
    private void FixedUpdate()
    {
        
            Move();
        
    }

    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);
        int faceDir = (int)transform.localScale.x;
        if (inputDirection.x > 0)
            faceDir = 1;
        if (inputDirection.x < 0)
            faceDir = -1;
        //人物翻转
        transform.localScale = new Vector3(faceDir, 1, 1);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGround) 
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            GetComponent<AudioDefination>()?.PlayAudioClip();
        }
        isJump = true;
    }

}
