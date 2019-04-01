using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    //enum and states
    public enum StateEnum {Idel,Right,Left};
    public StateEnum PlayerState;

    //components
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;


    //bools
    public bool IdelBool = false;
    public bool leftBool = false;
    public bool rightBool = false;
    public bool JumpBool = false;
    public bool OnGround = false;


    //int and float values

    public int Lives;
    public float Speed = 15;
    public float jumpheight;
    public int collect;



    //Text Values
    public Text Lifes;
    public Text coins;
    //Pooling and Menus
    public GameObject deathmenu;

    //Transform
    public Transform player;
    public GameObject tomato;
    public GameObject Particals;
    public GameObject bullet;
    public GameObject muzzle;

    void Start()
    {
        //player state
        PlayerState = StateEnum.Idel;

        //components
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


        //coins
        collect = 0;
        //Lives = 3;
        Lives = GameManager.instance.lives;

        coins.text = "Coins : " + collect.ToString();
        Lifes.text = "Lives : " + Lives.ToString();


        //Invoking
        InvokeRepeating("spawntomato",1f,1.5f);

       
    }
    
    void Update()
    {
        //DEATH CONDITION
        if (transform.position.x < -4.5)
        {
            --Lives;
            Lifes.text = "Lives : " +Lives.ToString();
            player.transform.position = new Vector3(0, -10.5f, 0);


            if (Lives == 0)
            {
                gameObject.SetActive(false);
                deathmenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        //MOVEMENT
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerState = StateEnum.Right;
            sr.flipX = true;
            anim.SetBool("Run",true);
        }

 

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerState = StateEnum.Left;
            sr.flipX = false;
            anim.SetBool("Run",true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            PlayerState = StateEnum.Idel;
            anim.SetBool("Run", false);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            PlayerState = StateEnum.Idel;
            anim.SetBool("Run", false);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayerState = StateEnum.Idel;
            anim.SetBool("Jump", false);
        }
        MoveMethod(PlayerState);
    }

        public void MoveMethod(StateEnum State)
    {
        switch (State)
        {

            case StateEnum.Idel:
                if (IdelBool == true)
                {
                    //Set to Idel Animation

                    IdelBool = false;
                }
                break;
            case StateEnum.Left:
                    transform.Translate(Vector3.left * Speed * Time.deltaTime);
                    
                break;
            case StateEnum.Right:
                    transform.Translate(Vector3.right * Speed * Time.deltaTime);
                break;
        }
    }
    //COLLISIONS
        private void OnCollisionEnter2D(Collision2D collision)
        {
        if(collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
        if (collision.gameObject.CompareTag("objdes"))
            {
                collision.gameObject.SetActive(false);
            }

        if(collision.gameObject.CompareTag("Finish"))
        {
            gameObject.SetActive(false);
            deathmenu.SetActive(true);
            Time.timeScale = 0;
        }
            if (collision.gameObject.CompareTag("Jump"))
            {
            transform.Translate(Vector3.up * 100 * Time.deltaTime);
            }
            if(collision.gameObject.CompareTag("Coins"))
        {
            Particals.GetComponent<ParticleSystem>().Play();
            Invoke("StopParticals",0.04f);
            collision.gameObject.SetActive(false);
            collect = ++GameManager.instance.ScoreValue;
            coins.text = "Coins : " + collect;   
        }
            if(collision.gameObject.CompareTag("D1"))
        {
            Speed += 5;
            collision.gameObject.SetActive(false);
            Debug.Log(Speed + "speed");
        }
            if(collision.gameObject.CompareTag("D2"))
        {
            tomato.transform.position = collision.transform.localPosition - tomato.transform.localPosition;
            collision.gameObject.SetActive(false);
        }
         
   }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Level2"))
        {
            SceneManager.LoadScene("Level_2");
        }
        if(collision.gameObject.CompareTag("Done"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }


    void StopParticals()
    {
         Particals.GetComponent<ParticleSystem>().Stop();
    }
    //Spawning
    void spawntomato()
    {
        if (PlayerState==StateEnum.Right )
        { 
            GameObject GObj = Instantiate(tomato, player.transform.localPosition + new Vector3(8, Random.Range(0, 2), 0), Quaternion.identity);
            GObj.SetActive(true);
        }
        else
        {

        }
    }


    //
    }
