using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    float enemyposition;
    public Transform Burger;
    public float Health;
    public GameObject deathmenu;

    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        Health = 90;
    //    gameObject.SetActive(false);
      //  Debug.Log(gameObject.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Burger"))
        {
            Debug.Log(gameObject);
            --player.Lives;
            player.Lifes.text = "Lives : " + player.Lives.ToString();
            player.player.transform.position = new Vector3(0,-10.5f,0);
            Health = 90;
            gameObject.SetActive(true);
            if (player.Lives == 0)
            {
                collision.gameObject.SetActive(false);
                deathmenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {
                Debug.Log(this.gameObject.activeSelf + ".....1");
                if (this.gameObject.activeSelf == false)
                {
                   this.gameObject.SetActive(true);
                    Debug.Log(this.gameObject.activeSelf + "....2");
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Health -= 30;
            collision.gameObject.SetActive(false);
            if(Health == 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }
}
