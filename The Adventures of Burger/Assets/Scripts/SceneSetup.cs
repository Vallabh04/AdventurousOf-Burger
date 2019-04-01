using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    public Transform player;
    public GameObject trigger;
    public PlayerController pl;
    // Start is called before the first frame update
    void Start()
    {
        SetPlayer();
        GameManager.instance.firsttrigger = false;
        GameManager.instance.secondtrigger = false;
    }

    public void SetPlayer()
    {
        if (GameManager.instance.firsttrigger == true && GameManager.instance.secondtrigger == true)
        {
            Debug.Log("Pos1...1" + GameManager.instance.pos1);
            //GameManager.instance.pos1 = player.transform.position;//Problem in this line.
            player.transform.position = GameManager.instance.pos1 + new Vector3(10,0,0);
            Debug.Log("Pos1...2" + GameManager.instance.pos1);
            trigger.gameObject.SetActive(false);
            Debug.Log(GameManager.instance.lives+"....lives");
        }
      
    }
}
