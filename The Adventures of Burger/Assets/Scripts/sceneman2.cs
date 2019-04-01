using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneman2 : MonoBehaviour
{
    public Transform burger;
    // Start is called before the first frame update
    void Start()
    {
        burger = GameObject.FindGameObjectWithTag("Burger").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Burger"))
        {
            if (GameManager.instance.thirdtrigger == false)
            {
                GameManager.instance.thirdtrigger = true;
                Debug.Log("Third Triggerd position " + GameManager.instance.thirdtrigger);
                GameManager.instance.pos3.x = burger.transform.position.x;
                Debug.Log(" Third Trigger Position is : " + burger.transform.position.x);
                SceneManager.LoadScene("SecretLevel_2");
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Burger"))
        {
            if (GameManager.instance.thirdtrigger == true && GameManager.instance.fourthtrigger == false)
            {
                GameManager.instance.fourthtrigger = true;
                SceneManager.LoadScene("Level_2");
                //  burger.transform.position = GameManager.instance.pos1;
                Debug.Log(" Fourth trigger Burger Position is : " + burger.transform.position);

            }
        }
    }
}
