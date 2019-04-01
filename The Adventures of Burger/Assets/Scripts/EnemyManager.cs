using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public float a;
    public float b;
    public GameObject enemy;
    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Destroyed");
    }


    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemy.gameObject.transform.position.x > transform.position.x)
        {
            a = enemy.gameObject.transform.position.x;
          
             Debug.Log("enemy is coming from left with a value of :" + a);
        }
        if (enemy.gameObject.transform.position.x < transform.position.x)
        {
            b = enemy.gameObject.transform.position.x;
             Debug.Log("enemy is coming from Right with a value of :" + b);
        }
    }
}
