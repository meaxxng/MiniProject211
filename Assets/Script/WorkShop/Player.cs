using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [Header("Hand setting")]
    public Transform RightHand;
    public Transform LeftHand;
    public List<Item> inventory = new List<Item>();

    [Header("Wallet & Lives")]
    public Wallet wallet;      // เพิ่ม wallet
    public int lives = 3;      // จำนวนชีวิต

    Vector3 _inputDirection;
    bool _isAttacking = false;
    bool _isInteract = false;

    [Header("Jump Setting")]
    public float jumpForce = 5f;
    bool isGrounded = true;
    bool _isJump = false;

    // ---------------- Double Jump ----------------
    int jumpCount = 0;
    public int maxJumpCount = 2; // กระโดดได้สูงสุด 2 ครั้ง (Double Jump)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    public void FixedUpdate()
    {
        Move(_inputDirection);
        Turn(_inputDirection);
        Attack(_isAttacking);
        Interact(_isInteract);

        //เพิ่มกระโดด 
        Jump(_isJump);
    }

    void Update()
    {
        HandleInput();

        // กด B เพื่อซื้อ Pet
        if (Input.GetKeyDown(KeyCode.B))
        {
            BuyPetWithStar();
        }
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    private void HandleInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _inputDirection = new Vector3(x, 0, y);
        if (Input.GetMouseButtonDown(0))
            _isAttacking = true;
        if (Input.GetKeyDown(KeyCode.E))
            _isInteract = true;

        //กระโดด
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
            _isJump = true;
    }

    public void Attack(bool isAttacking)
    {
        if (isAttacking)
        {
            animator.SetTrigger("Attack");
            var e = InFront as Idestoryable;
            if (e != null)
            {
                e.TakeDamage(Damage);
                Debug.Log($"{gameObject.name} attacks for {Damage} damage.");
            }
            _isAttacking = false;
        }
    }

    private void Interact(bool interactable)
    {
        if (interactable)
        {
            IInteractable e = InFront as IInteractable;
            if (e != null)
            {
                e.Interact(this);
            }
            _isInteract = false;
        }
    }

    private void Jump(bool jump)
    {
        // Reset jump count เมื่อแตะพื้น
        if (isGrounded)
        {
            jumpCount = 0;
        }

        if (jump && jumpCount < maxJumpCount)
        {
            // Reset ค่าแกน Y ก่อนกระโดด เพื่อให้กระโดดคงที่
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            // เพิ่มแรงกระโดด
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            jumpCount++;

            // เมื่อกระโดดแล้วถือว่าไม่ติดพื้น
            isGrounded = false;
        }

        _isJump = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        // ถ้าชนพื้น (normal เป็นด้านบน)
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            jumpCount = 0; // รีเซ็ตจำนวนกระโดด
        }
    }

    public GameObject petPrefab;

    public void BuyPetWithStar()
    {
        int starCost = 5;
        if (wallet.HasEnough(CurrencyType.STAR, starCost))
        {
            wallet.Use(CurrencyType.STAR, starCost);

            // สร้าง Pet ที่ตำแหน่ง Player + offset
            Vector3 spawnPos = transform.position + new Vector3(1, 0, 0); // ข้าง ๆ Player
            GameObject pet = Instantiate(petPrefab, spawnPos, Quaternion.identity);

            // กำหนด Player ให้ Pet ตาม
            FollowPlayer fp = pet.GetComponent<FollowPlayer>();
            if (fp != null)
            {
                fp.player = this.transform;
            }

            Debug.Log("ซื้อ Pet สำเร็จ! Star ถูกหัก " + starCost);
        }
        else
        {
            Debug.Log("Star ไม่พอ! ต้องมี 5 Star");
        }
    }


}
