using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public bool isgrounded;
    public bool onplatform;
    private float Extrajump;
    public float ExtrajumpValues;
    private float platfromjumpvalue;
    public float NoOfPlatformExtraJumps;
    public Transform GroundCheck;
    public LayerMask Ground;
    public LayerMask OnPlatform;
    public float Radius;
    public int jumpheight;

    public GameObject Secret;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Extrajump = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(isgrounded == true)
        {
            Extrajump = ExtrajumpValues;
        }
        Debug.Log("Extra jump is :" + Extrajump);
        if(Input.GetKeyDown(KeyCode.UpArrow) && Extrajump > 0)
        {
            rb.velocity = Vector2.up * jumpheight;
            Extrajump--;
            Debug.Log(Extrajump);
        }else if(Input.GetKeyDown(KeyCode.UpArrow)&&Extrajump == 0)
        {
            rb.velocity = -Vector2.up * jumpheight;
        }
    }

    private void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(GroundCheck.position, Radius, Ground);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Activate"))
        {
            Secret.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
        }
    }
}
