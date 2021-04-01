using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] CharacterStats.Character inventory;
    [SerializeField] GameObject attackPoint;
    public LayerMask enemyLayers;
    public bool drawDebugRaycasts = true;

    [SerializeField] GameObject player;
    [SerializeField] CharacterData data;
    [SerializeField] AudioClip BaseAudioCombat;
    private AudioClip audioCombatWeapon;
    [SerializeField] AudioClip BaseAudioMove;
    private AudioClip audioMove;
    [SerializeField] AudioClip BaseAudioDead;
    [SerializeField] AudioClip BaseAudioImpact;
    [SerializeField] float BaseAttackSpeed;
    private AudioSource audioSource;

    #region States
    public StandState standState;
    public HandState handState;
    public CrouchState crouchState;
    public JumpState jumpState;
    public StandRunState standRunState;
    public JumpRunState jumpRunState;
    public CrouchRunState crouchRunState;
    public ClimbState climbState;
    public AirState airState;
    StateMachine stateMachine;
#endregion

    #region Variables

    [Header("Ground Check")]
    [SerializeField] float groundDistance;
    [SerializeField] float footOffset;
    [SerializeField] LayerMask groundMask;
    public bool OnGround;
    [SerializeField] Transform groundCheck;
    [Space]

    [Header("Wall Check")]
    [SerializeField] float handDistance;
    [SerializeField] float handOffset;
    public bool OnWall;
    [Space]
    [Header("Eye check")]
    [SerializeField] float eyeDistance;
    [SerializeField] float eyeOffset;
    private int baseDirection;
    public bool OnEye;
    public bool OnAir;
    public int horizontalMoveParam = Animator.StringToHash("H_Speed");
    public int verticalMoveParam = Animator.StringToHash("V_Speed");
    public int AttackRateParam = Animator.StringToHash("AttackRate");

    private Vector2 directionOfSight;

    #endregion

    #region Properties (Data)
    public float JumpForce => data.jumpForce;
    public float MovementSpeed => data.movementSpeed;
    public float CrouchSpeed => data.crouchSpeed;
    public float AttackRange => data.attackRange;
    public float AttackRate => data.attackRate;
    public int BaseDamage => data.baseDamage;
    #endregion

    #region Anim cash
    public int JumpParam => Animator.StringToHash("Jump");
    public int CrouchParam => Animator.StringToHash("Crouch");
    public int StandParam => Animator.StringToHash("Stand");
    public int SoarParam => Animator.StringToHash("SourInAir");
    public int RunParam => Animator.StringToHash("Run");
    public int MoveHorizontalParam => Animator.StringToHash("HorizontalMove");
    public int MoveVeticalParam => Animator.StringToHash("VerticalMove");
    public int TouchEyeParam => Animator.StringToHash("TouchEye");
    public int TouchHandParam => Animator.StringToHash("TouchHand");
    public int AttackParam => Animator.StringToHash("Attack");
    #endregion

    #region Cash
    private Rigidbody2D rb2d;
    public Rigidbody2D Rigidbody2D => rb2d;
    private Animator anim;
    private Transform playerTransform;
    private CapsuleCollider2D myBodyCollider;
    private SpriteRenderer sp;
    #endregion

    #region Methods Physics Processing
    public void Move(float speed)
    {
        RevertBody(speed);

        rb2d.velocity = new Vector2(data.movementSpeed * speed, rb2d.velocity.y);
    }
    public void WallMove()
    {
        if (rb2d.velocity.y < -1)
            rb2d.velocity = new Vector2(rb2d.velocity.x, -1);
    }

    private void RevertBody(float direction)
    {
        if (direction > 0.0f)
        {
            baseDirection = 1;
            transform.localScale = new Vector2(baseDirection, 1);
            //sp.flipX = false;
        }
        if (direction < 0.0f)
        {
            baseDirection = -1;
            //sp.flipX = true;
            transform.localScale = new Vector2(baseDirection, 1);
        }
    }
    public void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x * 0, data.jumpForce);
    }
    public void WallJump()
    {
        rb2d.velocity = new Vector2(-baseDirection * data.sideForce, data.jumpForce);
        //rb2d.AddForce(new Vector2(-baseDirection * data.sideForce, data.jumpForce), ForceMode2D.Impulse);
    }

    // public void JumpVelocity(float jumpSpeed)
    // {
    //     Vector2 targetVelocity = new Vector2(0, jumpSpeed);
    //     rb2d.velocity += targetVelocity;
    // }

    public bool PhysicsCheck()
    {
        OnGround = false;
        Vector2 pos = groundCheck.transform.position;

        RaycastHit2D rightFootCheck = Raycast(new Vector2(footOffset, 0f), Vector2.down, groundDistance, pos);
        RaycastHit2D leftFootCheck = Raycast(new Vector2(-footOffset, 0f), Vector2.down, groundDistance, pos); 

        if (rightFootCheck || leftFootCheck) 
            OnGround = true;

        return OnGround;
    }

    public bool WallCheck()
    {
        OnWall = false;

        Vector2 pos = groundCheck.transform.position;

        RaycastHit2D handCheck = Raycast(new Vector2(0f, handOffset), new Vector2(baseDirection, 0), handDistance, pos);

        if (handCheck) OnWall = true;

        return handCheck;
    }
    public bool EyeCheck()
    {
        OnEye = false;

        Vector2 pos = groundCheck.transform.position;

        RaycastHit2D eyeCheck = Raycast(new Vector2(0f, eyeOffset), new Vector2(baseDirection, 0), eyeDistance, pos);

        if (eyeCheck) OnEye = true;

        return OnEye;
    }

    private RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, Vector2 transformationPos)
    {
        return Raycast(offset, rayDirection, length, groundMask, transformationPos);
    }
    private RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask mask, Vector2 transformationPos)
    {
        Vector2 pos = transformationPos;

        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, mask);

        Color color = hit ? Color.red : Color.green;

        Debug.DrawRay(pos + offset, rayDirection * length, color);

        return hit;
    }
    #endregion

    #region Animation Controller
    public void SetBoolAnimator(int param, bool value)
    {
        anim.SetBool(param, value);
    }

    public void SetFloatAnimator(int param, float value)
    {
        anim.SetFloat(param, value);
    }

    public float GetFloatAnimator(int param)
    {
        return anim.GetFloat(param);
    }
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        baseDirection = 1;
        audioCombatWeapon = BaseAudioCombat;
        audioMove = BaseAudioMove;

        GameEvent.Instance.OnUnequipItemEvent += UnequipItem;
        GameEvent.Instance.OnGetItemEvent += TakeItem;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        anim.SetFloat("RateAttack", AttackRate);
        playerTransform = player.GetComponent<Transform>();
        //player.GetComponent<Rigidbody2D>();

        stateMachine = new StateMachine();

        standState = new StandState(this, stateMachine);
        crouchState = new CrouchState(this, stateMachine);
        jumpState = new JumpState(this, stateMachine);
        airState = new AirState(this, stateMachine);
        handState = new HandState(this, stateMachine);

        if (OnGround) stateMachine.Initialize(standState);
        else stateMachine.Initialize(airState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenCloseInventory();
        }

        stateMachine.CurrentState.InputHander();

        stateMachine.CurrentState.Update();
    }

    private void FixedUpdate()
    {
        PhysicsCheck();
        WallCheck();
        EyeCheck();

        stateMachine.CurrentState.FixedUpdate();
    }
    #endregion

    void OpenCloseInventory()
    {
        inventory.gameObject.SetActive(!inventory.gameObject.active);
    }

    // private float nextAttackTime = 0;
    // public bool CanYouAttack()
    // {
    //     if (nextAttackTime > Time.time)
    //         return false;

    //     nextAttackTime = Time.time + 1f / AttackRate;
    //     return true;
    // }
    public void Attack()
    {
        audioSource.clip = audioCombatWeapon;
        audioSource.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, AttackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Health>().TakeDamage(BaseDamage);
        }
    }
    private void TakeItem(Item item)
    {
        EquippableItem equippableItem = item as EquippableItem;
        if (equippableItem.EquipmentType == EquipmentType.Weapon1)
        {
            audioCombatWeapon = item.audio;
            anim.SetFloat("RateAttack", item.attackSpeed);
        }
    }
    private void UnequipItem(Item item)
    {
        EquippableItem equippableItem = item as EquippableItem;
        if (equippableItem.EquipmentType == EquipmentType.Weapon1)
        {
            audioCombatWeapon = BaseAudioCombat;
            anim.SetFloat("RateAttack", BaseAttackSpeed);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.transform.position, AttackRange);
    }
    // when our player steps
    public void StepEvent()
    {
        audioSource.clip = audioMove;
        audioSource.Play();
    }
}
