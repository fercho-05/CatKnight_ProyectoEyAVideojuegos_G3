using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterPlataformerController : Monostate <CharacterPlataformerController>
{
    [Header("Move")]
    [SerializeField]
    float moveSpeed = 300.0F;

    [SerializeField]
    bool isFacingRight = true;

    [Header("Jump")]
    [SerializeField]
    float jumpForce = 140.0F;

    [SerializeField]
    float fallMultiplier = 3.0F;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    LayerMask groundMask;

    [SerializeField]
    LayerMask lavaMask;

    [SerializeField]
    float jumpGraceTime = 0.20F;

    [Header("Attack")]

    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    LayerMask enemyMask;

    //[SerializeField]
    //float reboundY = 5.0F;

    [Header("Animation")]
    [SerializeField]
    public Animator animator;

    Rigidbody2D _rb;

    Vector2 _direction;

    bool _isMoving;
    bool _isJumping;
    bool _isJumpPressed;
    bool _isAttacking;
    float _gravityY;
    float _lastTimeJumpPressed;
    float _meleeDamage;

    protected override void Awake()
    {
        base.Awake();
        _rb = GetComponent<Rigidbody2D>();
        _gravityY = -Physics2D.gravity.y;
    }

    void Update()
    {
        HandleInputs();
    }

    void FixedUpdate()
    {
        HandleJump();
        HandleFlipX();
        HandleMove();
    }

    void HandleInputs()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0.0F);
        _isMoving = _direction.x != 0.0F;
        _isJumpPressed = Input.GetButtonDown("Jump");

        if (_isJumpPressed)
        {
            _lastTimeJumpPressed = Time.time;
        }
    }

    void HandleMove()
    {
        bool isMoving = animator.GetFloat("speed") > 0.01F;

        if (_isMoving != isMoving && !_isJumping)
        {
            animator.SetFloat("speed", Mathf.Abs(_direction.x));
        }

        Vector2 velocity = _direction * moveSpeed * Time.fixedDeltaTime;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;

    }

    void HandleFlipX()
    {
        if (!_isMoving)
        {
            return;
        }

        bool facingRight = _direction.x > 0.0F;
        if (isFacingRight != facingRight)
        {
            isFacingRight = facingRight;
            transform.Rotate(0.0F, 180.0F, 0.0F);
        }

    }

    void HandleJump()
    {
        if (_lastTimeJumpPressed > 0.0F && Time.time - _lastTimeJumpPressed <= jumpGraceTime)
        {
            _isJumpPressed = true;
        }
        else
        {
            _lastTimeJumpPressed = 0.0F;
        }

        if (_isJumpPressed)
        {
            bool isGrounded = IsGrounded();
            if (isGrounded)
            {
                _rb.velocity += Vector2.up * jumpForce * Time.fixedDeltaTime;
            }
        }

        if (_rb.velocity.y < -0.01F)
        {
            _rb.velocity -= Vector2.up * _gravityY * fallMultiplier * Time.fixedDeltaTime;
        }

        _isJumping = !IsGrounded();

        bool isJumping = animator.GetBool("isJumping");
        if (_isJumping != isJumping)
        {
            animator.SetBool("isJumping", _isJumping);
        }

        bool isFalling = animator.GetBool("isFalling");
        bool isNegativeVelocityY = _rb.velocity.y < -0.01F;
        if (isNegativeVelocityY != isFalling)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", isNegativeVelocityY);

        }

    }

    bool IsGrounded()
    {
        return
        Physics2D.OverlapCapsule
            (groundCheck.position, new Vector2(1.67F, 0.004F),
                CapsuleDirection2D.Horizontal, 0.0F, groundMask);
    }

    public void Attack(float damage)
    {

        if (_isAttacking)
        {
            return;
        }

        _isAttacking = true;
        _meleeDamage = damage;
        animator.SetBool("attack", true);

        AudioManager.Instance.PlaySFX("golpeEspada", false);
    }

    public void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, 0.2F, enemyMask);
        foreach (Collider2D collider in enemies)
        {
            //codigo para hacer da�o
        }
        _isAttacking = false;
        animator.SetBool("attack", false);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //Recibir DA�O actualizar barra de vida

        }


    }


}
