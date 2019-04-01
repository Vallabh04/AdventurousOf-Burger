using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionCollider : MonoBehaviour
{
    public int index;//Collider Index
    public int index1;
    public Platformpooler pool;
    public float a;
    public float b;
    //public float P1 = 100;
    //P1 = 100
    //P2 = 200
    //P3 = 300
    //P4 = 400
    //P5 = 500

    private void OnTriggerEnter2D(Collider2D collision)
    {

        a = collision.gameObject.transform.position.x;
      //  MoveDirection();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        b = collision.gameObject.transform.position.x;
        MoveDirection();//
    }

    public void MoveDirection()
    {
        int Temp;
        int Temp2;

        if (index < pool.IndexVals.Count)
        {
            if (a < b)//Left to Right
            {
                Temp = index;//1
                Temp2 = index + 1;//2
                pool.ChangePlatform(Temp, Temp2);
            }

            if (b < a)//Right to Left
            {
                Temp = index;//1
                Temp2 = index - 1;//0
                pool.ChangePlatform(Temp2, Temp);
            }
        }
    }



}