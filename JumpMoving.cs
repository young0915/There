using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpMoving : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool isGround;
    public Transform groundCheck;
    public float CheckRadius;
    public LayerMask WhatisGround;

    public int extraJump;
    public GameObject Gameoverpannel;
    public GameObject Life;
    public GameObject but;
    public GameObject Winpannel;
    public Slider LifeBar;

   public GameObject bullet; //총알 만드는 구역
    Vector2 bullectPos;
    public float fireRate = 0.4f;
    float nextfire = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        
    }
    
    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, WhatisGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (LifeBar.value == 0)
        {
            Gameoverpannel.SetActive(true);
            Life.SetActive(false);
            but.SetActive(false);
            Time.timeScale = 0f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isGround == true)
        {
            // extraJump = extraJumping;  
            extraJump = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }


        if (Input.GetMouseButton(0) && Time.time > nextfire) //마우스 클릭시 총알 나옴
        {
            nextfire = Time.time + fireRate;
            fire();
        }



        // 생명선 타임
        LifeBar.value -= Time.deltaTime * 0.04f;//
    }

   void fire() // 총알 함수
   {
       bullectPos = transform.position;
       bullectPos += new Vector2(+0.08f, 0.15f);
       Instantiate(bullet, bullectPos, Quaternion.identity);
   }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "DeadZone")
        {
            gameObject.SetActive(false);
            Life.SetActive(false);
            but.SetActive(false);
            Gameoverpannel.SetActive(true);//DeadZone과 닿을 시 게임 오버 게임오버 패널 나옴
            Time.timeScale = 0f;// 정지
        }

        if (col.gameObject.tag == "enemy") // 생명바 영역
        {

            LifeBar.value -= 0.35f;
            if (LifeBar.value == 0)
            {
                Life.SetActive(false);
                but.SetActive(false);
                Gameoverpannel.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        if (col.gameObject.tag == "Lifeup") // 초코바 먹을 시 생면선 Up
        {
            LifeBar.value += 0.2f;
        }

        if (col.gameObject.tag == "obstacle")
        {
            LifeBar.value -= 0.2f;
        }

        if(col.gameObject.tag == "win")
        {
            
            Winpannel.SetActive(true);
                Time.timeScale = 0f;

        }
    }
}
