using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneman : MonoBehaviour
{
    public Transform burger;
    // Start is called before the first frame update
    void Start()
    {
        burger = GameObject.FindGameObjectWithTag("Burger").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag( "Burger"))
        {
            if (GameManager.instance.firsttrigger == false)
            {
                GameManager.instance.firsttrigger = true;
                Debug.Log("First Triggerd position " + GameManager.instance.firsttrigger);
                GameManager.instance.pos1.x = burger.transform.position.x;
                Debug.Log(" First Trigger Position is : " + burger.transform.position.x);
                SceneManager.LoadScene("SecretLevel");
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Burger"))
        {
            if (GameManager.instance.firsttrigger == true && GameManager.instance.secondtrigger == false)
            {
                GameManager.instance.secondtrigger = true;
                SceneManager.LoadScene("Level01");
              //  burger.transform.position = GameManager.instance.pos1;
                Debug.Log(" second trigger Burger Position is : " +burger.transform.position);
              
            }
        }
    }
}
