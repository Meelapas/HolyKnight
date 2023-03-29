using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] GameObject atkHit;
   [SerializeField] Ultbar ultbar;
   
   public static Player instance;

    public float speed = 5f;
    public float jump = 5f;
    public int Hp = 5;
    private Rigidbody2D rb;
    public LayerMask groundLayer;
    public GameObject[] hpBar;

 
    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isAtk = false;
    public bool isUtl = false;
    public bool isDie = false;
    public bool isFlash;




    int  jumpcount = 1;
    //public GameObject Hand;
    private Animator Anime;
    

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();   
         Anime = GetComponent<Animator>(); 
         atkHit.SetActive(false);
         hpBar[5].SetActive(true);
         
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FilpSprite();
        CheckGround();
        Jump();
        AnimePlayer();
        Atk();
        if(ultbar.Ult==3)
        {
            Ult();
        }
        else
        {
            isUtl = false;
        }
       
    }
    void Run()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 	rb.velocity.y);
         isMoving = (Input.GetAxisRaw("Horizontal") != 0); 
    }
    public void FilpSprite()
    {
        bool filp = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        //Vector3 theScale = Hand.transform.localScale;
        if (filp)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
          
   
        }
       
    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 1f, groundLayer); // checks if you are within 0.5 position in the Y of the ground
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded )
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);          
            jumpcount = 2;
            //AudioManager.instance.playJump(); 
        } 
        else if(Input.GetButtonDown("Jump")&& !isGrounded && jumpcount==2)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            jumpcount=1;
        } 
    }
    private void Atk()
    {
       
        if(Input.GetMouseButtonDown(0))
        {
            isAtk = true;
            atkHit.SetActive(true);
        }else if(Input.GetMouseButtonUp(0))
        {
            isAtk = false;
            atkHit.SetActive(false);
        }
       
    }
    public void Ult()
    {
         if(Input.GetMouseButtonDown(1))
        {
            isUtl = true;
            ultbar.Ult = 0;
        }
    }
    private void AnimePlayer()
    {
        Anime.SetBool("IsMoving", isMoving);
        Anime.SetBool("IsJumping", isGrounded);
        Anime.SetBool("IsAtk", isAtk);
        Anime.SetBool("isUtl", isUtl);
        Anime.SetBool("isDie", isDie);
    }
    void getDamage()
    {
        //AudioManager.instance.playEnemyHit();
        Hp--;
        isFlash = true;
        Physics2D.IgnoreLayerCollision(7,8,true);
        StartCoroutine(Flash());
        PlayerHp();

        if(Hp <= 0)
        {
            isDie = true;
            
            //this.gameObject.SetActive(false);
        }
    }
    public void PlayerHp()
    {
        switch (Hp)
        {
            case 5:
                hpBar[5].SetActive(true);
                hpBar[4].SetActive(false);
                hpBar[3].SetActive(false);
                hpBar[2].SetActive(false);
                hpBar[1].SetActive(false);
                hpBar[0].SetActive(false);
                break;
            case 4:
                hpBar[4].SetActive(true);
                hpBar[5].SetActive(false);
                hpBar[3].SetActive(false);
                hpBar[2].SetActive(false);
                hpBar[1].SetActive(false);
                hpBar[0].SetActive(false);
                break;
            case 3:
                hpBar[3].SetActive(true);
                hpBar[5].SetActive(false);
                hpBar[4].SetActive(false);
                hpBar[2].SetActive(false);
                hpBar[1].SetActive(false);
                hpBar[0].SetActive(false);
                break;
            case 2:
                hpBar[2].SetActive(true);
                hpBar[5].SetActive(false);
                hpBar[4].SetActive(false);
                hpBar[3].SetActive(false);
                hpBar[1].SetActive(false);
                hpBar[0].SetActive(false);
                break;
            case 1:
                hpBar[1].SetActive(true);
                hpBar[5].SetActive(false);
                hpBar[4].SetActive(false);
                hpBar[3].SetActive(false);
                hpBar[2].SetActive(false);
                hpBar[0].SetActive(false);
                break;
            
            default:
                hpBar[0].SetActive(true);
                hpBar[5].SetActive(false);
                hpBar[4].SetActive(false);
                hpBar[3].SetActive(false);
                hpBar[2].SetActive(false);
                hpBar[1].SetActive(false);
                break;
        }
    }
    public void AddHp()
    {
         
        if(Hp < 5)
        {
             Hp++;
            PlayerHp();
            Debug.Log(Hp);
        }

    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
            if(collision.gameObject.CompareTag("Enemy")&& !isFlash)
            {
                getDamage();
                Debug.Log(Hp);
            }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Enemy")&& !isFlash)
            {
                getDamage();
               
            }
    }


     IEnumerator Flash()
    {
        for(int i=0;i<10;i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.5f);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(0.1f);
        }
        Physics2D.IgnoreLayerCollision(7,8,false);
        isFlash = false;
    }

  

    





}
