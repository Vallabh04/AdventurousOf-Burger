using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceScript : MonoBehaviour
{
    public Platformpooler Ppooler;
    public Platformpooler1 PaPoller;
    public MainMenu MenuP;
    public positionCollider posco;
    public EnemyMovement em;
    public PauseMenu menuPau;

    void Start()
    {
        Invoke("ManagingMethods", 0.2f);
    }

    // Update is called once per frame
   public void ManagingMethods()
    {
        GameObject.Find("gameManager").GetComponent<GameManager>().RefScript = this;
    }
}
