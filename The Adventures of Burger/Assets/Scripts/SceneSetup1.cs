using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetup1 : MonoBehaviour
{
    public Transform player;
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
        SetPlayer();
        GameManager.instance.thirdtrigger = false;
        GameManager.instance.fourthtrigger = false;
    }

    public void SetPlayer()
    {
        if (GameManager.instance.thirdtrigger == true && GameManager.instance.fourthtrigger == true)
        {
            Debug.Log("Pos3...1" + GameManager.instance.pos3);
            //GameManager.instance.pos1 = player.transform.position;//Problem in this line.
            player.transform.position = GameManager.instance.pos3 + new Vector3(10,0,0);
            Debug.Log("Pos3...2" + GameManager.instance.pos3);
            trigger.gameObject.SetActive(false);
        }
      
    }
}
