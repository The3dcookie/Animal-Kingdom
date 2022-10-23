using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Assets.Scripts;


public class GridManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private GameObject animal;
    [SerializeField]
    public int column, row;
    [SerializeField]
    public float columnSpace,rowSpace;
    [SerializeField]
    Camera cam;
    [SerializeField]
    private float xAdjust, yAdjust;
    [SerializeField]
    private GameObject[] kingdom;

    public bool timerOn = false;
    public float timeLeft = 2f;
    List<GameObject> Lions = new List<GameObject>();
    List<GameObject> Goats = new List<GameObject>();
    List<Vector3> RandomPositions = new List<Vector3>();
    List<GameObject> Trees = new List<GameObject>();

    public bool vacant;

    private void Start()
    {
        GenerateGrid();
        timerOn = true;
    }
    private void Update()
    {
        TimerOn();

        //ColCheck();
        RandPos();
    }

    public bool TimerOn()
    {

        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else if (timeLeft <= 0)
            {
                timeLeft = 2f;
            }
        }

        return timerOn;
    }
    public void GenerateGrid()
    {
        //Instantiate Grids
        for (int i = 0; i < row; i++)
        {

            for (int j = 0; j < column; j++)
            {
                Instantiate(tile, new Vector3(columnSpace * i, rowSpace * j), Quaternion.identity);
                //Instantiate(kingdom[Random.Range(0, 4)], new Vector3(columnSpace * Random.Range(0, row), rowSpace * Random.Range(0, column)), Quaternion.identity);
       
                RandomPositions.Add(new Vector3(columnSpace * i, rowSpace * j));



            }

        }



        //Instantiate Goats
        for (int i = 0; i < 10; i++)
        {
            //Instantiate(kingdom[0], new Vector3(columnSpace * 4, rowSpace * 4), Quaternion.identity);

            Goats.Add(Instantiate(kingdom[0], RandPos(), Quaternion.identity));
            RandomPositions.Remove(Goats[i].transform.position);


            //Instantiate(kingdom[0], new Vector3(columnSpace * Random.Range(0, row), rowSpace * Random.Range(0, column)), Quaternion.identity);
        }
        //Instantiate(kingdom[1], new Vector3(columnSpace * 6, rowSpace * 5), Quaternion.identity);


        //Instantiate Lions
        for (int i = 0; i < 10; i++)
        {



                //Vector3 lionPos = new Vector3(columnSpace * Random.Range(0, row), rowSpace * Random.Range(0, column));

                //    if (lionPos == IsVacant())
                //    {
                        //Lions.Add(Instantiate(kingdom[1], new Vector3(columnSpace * Random.Range(0, row), rowSpace * Random.Range(0, column)), Quaternion.identity));
                        
            Lions.Add(Instantiate(kingdom[1], RandPos(), Quaternion.identity));
            RandomPositions.Remove(Lions[i].transform.position);


            //}


            //Instantiate(kingdom[1], new Vector3(columnSpace * 4, rowSpace * 4), Quaternion.identity);

            //Lions.Add(Instantiate(kingdom[1], new Vector3(columnSpace * 4, rowSpace * 5), Quaternion.identity));
            //Lions.Add(Instantiate(kingdom[1], new Vector3(columnSpace * 4, rowSpace * 6), Quaternion.identity));
            //Instantiate(kingdom[1], new Vector3(columnSpace * Random.Range(0, row), rowSpace * Random.Range(0, column)), Quaternion.identity);
        }


        //Instantiate Trees
        for (int i = 0; i < 6; i++)
        {
            //Instantiate(kingdom[1], new Vector3(columnSpace * 4, rowSpace * 4), Quaternion.identity);
            Trees.Add(Instantiate(kingdom[2], RandPos(), Quaternion.identity));
            RandomPositions.Remove(Trees[i].transform.position);
            //Lions.Add(Instantiate(kingdom[1], new Vector3(columnSpace * 4, rowSpace * 5), Quaternion.identity));
            //Lions.Add(Instantiate(kingdom[1], new Vector3(columnSpace * 4, rowSpace * 6), Quaternion.identity));
            //Instantiate(kingdom[1], new Vector3(columnSpace * Random.Range(0, row), rowSpace * Random.Range(0, column)), Quaternion.identity);
        }
        cam.transform.position = new Vector3((float)row / 2 + xAdjust, (float)column / 2 + yAdjust, -10);

        

    }

    public void ColCheck()
    {

        // Collision Check for Lion eats Goat  
        for (int i = 0; i < Goats.Count; i++)
        {
            if (Lions[0].transform.position == Goats[i].transform.position)
            {
                Destroy(Goats[i]);
                Goats.Remove(Goats[i]);
            }
        }

        // Collision Check for Goat eats Trees
        for (int i = 0; i < Trees.Count; i++)
        {
            if (Goats[0].transform.position == Trees[i].transform.position)
            {
                Destroy(Trees[i]);
                Trees.Remove(Trees[i]);
            }
        }
    }

    //public Vector3 IsVacant()
    //{
    //    for (int i = 0; i < RandomPositions.Count; i++)
    //    {

    //        while (RandPos() != RandomPositions[i])
    //            {
    //            Vector3 free = RandPos();

    //            return free;
    //            }
    //    }

    //    Debug.Log("Wrong");
    //    return transform.position;
    //}

    public Vector3 RandPos()
    {

        
        int rand = Random.Range(0, RandomPositions.Count);
        
        Vector3 pos = RandomPositions[rand];
        
        
        return pos;
        


    }
}
