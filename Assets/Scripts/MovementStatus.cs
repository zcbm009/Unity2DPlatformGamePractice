using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStatus : MonoBehaviour
{
    private float directionX;
    private Rigidbody2D rigidbody2DObj;
    private SpriteRenderer spriteComponent;
    private Animator animatorComponent;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpHeight;

    private enum MovementStatusEnum { idle, running, jumping, falling }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2DObj = GetComponent<Rigidbody2D>();
        spriteComponent = GetComponent<SpriteRenderer>();
        animatorComponent = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 移动
        directionX = Input.GetAxisRaw("Horizontal");
        rigidbody2DObj.velocity = new Vector2(directionX * moveSpeed, rigidbody2DObj.velocity.y);

        // 跳越，解决无限跳问题
        if (Input.GetKeyDown("space") && CheckGrounded())
        {
            rigidbody2DObj.velocity = new Vector2(rigidbody2DObj.velocity.x, jumpHeight);
        }

        // 移动动画
        if (directionX > 0f)
        {
            spriteComponent.flipX = false;
            animatorComponent.SetInteger("status", (int)MovementStatusEnum.running);
        }
        else if (directionX < 0f)
        {
            spriteComponent.flipX = true;
            animatorComponent.SetInteger("status", (int)MovementStatusEnum.running);
        }
        else
        {
            animatorComponent.SetInteger("status", (int)MovementStatusEnum.idle);
        }

        // 跳越动画
        if (rigidbody2DObj.velocity.y > .1f)
        {
            animatorComponent.SetInteger("status", (int)MovementStatusEnum.jumping);
        }
        else if (rigidbody2DObj.velocity.y < -.1f)
        {
            animatorComponent.SetInteger("status", (int)MovementStatusEnum.falling);
        }
    }

    private bool CheckGrounded(){
        // 碰撞检测，检测是否碰撞到了地面
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}
