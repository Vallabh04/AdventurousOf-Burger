using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformpooler1 : MonoBehaviour
{
    //StartPoint = -10.
    //EndPoint = +470.
    public List<GameObject> PlatfromsPool = new List<GameObject>();
    public List<int> PlatformPlacer = new List<int>();//
    public List<int> EnemyPlacer = new List<int>();
    public List<int> IndexVals = new List<int>();
    public List<int> IndexVals1 = new List<int>();
    public int Dist1;
    public int Dist;
    public int CountDist;
    public int countdist1;
    public GameObject platformprefab;
    public int NCount = 10;
    public GameObject player;

    void Start()
    {
   
        createplatform();//
        //createenemy();
        //InvokeRepeating("SetPlayer", 1f, 2f);
    }

 

    void createplatform()
    {
        for(int i = 0;i<= NCount; i++) //platformcount
        {
            var Pobj = Instantiate(platformprefab, gameObject.transform.position, Quaternion.identity);
            platformprefab.SetActive(false);
            PlatfromsPool.Add(Pobj);
        }

        PlaceAtDist();
    }

    //PlatfromsPool - 15
    

    public void PlaceAtDist()
    {
        Dist = 0;
        CountDist = 100;
        IndexVals.Add(0);
        for (int i = 0; i < 38; i++)
        {
            int Temp = 5;
            Dist += (Temp + 10);//17
            PlatformPlacer.Add(Dist);

            if (Dist > 480)
            {
                IndexVals.Add(i);
                break;
            }

            if (Dist > CountDist)
            {
               CountDist += 100;
                IndexVals.Add(i);
            }
        }

        ChangePlatform(0, 1);//To place default platforms
       // Debug.Log("ffff " + IndexVals.Count);
    }


    public void ChangePlatform(int Id1,int Id2)
    {
        if(Id1 != 0)
        { 
            Id1 = IndexVals[Id1] - 1;
        }

        if (Id1 < 0)
        {
            Id1 = 0;
        }

        if(Id2 != 0)
        {
            Id2 = IndexVals[Id2] - 1;
        }

        if (Id2 < 0)
        {
            Id2 = 0;
        }

        //Debug.Log("VALUES " + Id1 + " " + Id2);

        int j = 0;
        for (int i = Id1; i <= Id2; i++)
        {
            Vector3 Pos = PlatfromsPool[j].transform.position;
            Pos.x = PlatformPlacer[i];
            Pos.y = -75f;
            PlatfromsPool[j].transform.position = Pos;
            if(PlatfromsPool[j].activeSelf == false)
            {
                PlatfromsPool[j].SetActive(true);
            }
            
            j++;
        }
    }
}
