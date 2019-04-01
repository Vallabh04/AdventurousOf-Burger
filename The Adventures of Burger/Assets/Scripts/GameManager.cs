using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int ScoreValue;
    public int lives;
    public bool firsttrigger;
    public bool secondtrigger;
    public bool thirdtrigger;
    public bool fourthtrigger;
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos4;
    public ReferenceScript RefScript;

    void Awake()
    {
       // Debug.Log(GameManager.instance.firsttrigger);

        ScoreValue = 0;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
