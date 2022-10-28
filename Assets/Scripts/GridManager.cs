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
    List<GameObject> BabyGoats = new List<GameObject>();
    public List<GameObject> MaleGoats = new List<GameObject>();
   public List<GameObject> FemaleGoats = new List<GameObject>();
   public List<GameObject> Trees = new List<GameObject>();


    Goat goat;

    List<Vector3> RandomPositions = new List<Vector3>();

    public bool isBorn = false;
    public Vector3 birthPoint;

    private void Awake()
    {
        //goat = gameObject.GetComponent<Goat>();
    }

    private void Start()
    {
        GenerateGrid();
        goat = FindObjectOfType<Goat>();

        timerOn = true;
    }
    private void Update()
    {
        TimerOn();
        Mating();
        ColCheck();
        RandPos();
        //Replenish();
        //HungerKills();
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



        //Instantiate FeMale Goats
        for (int i = 0; i < 0; i++)
        {
            //Instantiate(kingdom[0], new Vector3(columnSpace * 4, rowSpace * 4), Quaternion.identity);

            FemaleGoats.Add(Instantiate(kingdom[0], RandPos(), Quaternion.identity));
            RandomPositions.Remove(FemaleGoats[i].transform.position);


            //Instantiate(kingdom[0], new Vector3(columnSpace * Random.Range(0, row), rowSpace * Random.Range(0, column)), Quaternion.identity);
        }
        //Instantiate(kingdom[1], new Vector3(columnSpace * 6, rowSpace * 5), Quaternion.identity);

        //MaleGoats.Add(Instantiate(kingdom[0], RandPos(), Quaternion.identity));
        //MaleGoats.Add(Instantiate(kingdom[0], new Vector3(columnSpace * 4, rowSpace * 4), Quaternion.identity));
        //MaleGoats.Add(Instantiate(kingdom[0], new Vector3(columnSpace * 3, rowSpace * 4), Quaternion.identity));

        //Instantiate Male Goats
        for (int i = 0; i < 10; i++)
        {
            //MaleGoats.Add(Instantiate(kingdom[0], new Vector3(columnSpace * 4, rowSpace * 4), Quaternion.identity));
            //MaleGoats.Add(Instantiate(kingdom[0], new Vector3(columnSpace * 3, rowSpace * 4), Quaternion.identity));


            MaleGoats.Add(Instantiate(kingdom[0], RandPos(), Quaternion.identity));
            RandomPositions.Remove(MaleGoats[i].transform.position);


            //Instantiate(kingdom[0], new Vector3(columnSpace * Random.Range(0, row), rowSpace * Random.Range(0, column)), Quaternion.identity);
        }
        //I

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
        for (int i = 0; i < 60; i++)
        {
            //Trees.Add(Instantiate(kingdom[2], new Vector3(columnSpace * 4, rowSpace * 4), Quaternion.identity));
            //Trees.Add(Instantiate(kingdom[2], new Vector3(columnSpace * 3, rowSpace * 4), Quaternion.identity));
            //Trees.Add(Instantiate(kingdom[2], new Vector3(columnSpace * 2, rowSpace * 4), Quaternion.identity));
            //Trees.Add(Instantiate(kingdom[2], new Vector3(columnSpace * 4, rowSpace * 3), Quaternion.identity));
            //Trees.Add(Instantiate(kingdom[2], new Vector3(columnSpace * 3, rowSpace * 3), Quaternion.identity));
            //Trees.Add(Instantiate(kingdom[2], new Vector3(columnSpace * 2, rowSpace * 3), Quaternion.identity));
            //Trees.Add(Instantiate(kingdom[2], new Vector3(columnSpace * 4, rowSpace * 5), Quaternion.identity));
            //Trees.Add(Instantiate(kingdom[2], new Vector3(columnSpace * 3, rowSpace * 5), Quaternion.identity));
            //Trees.Add(Instantiate(kingdom[2], new Vector3(columnSpace * 2, rowSpace * 5), Quaternion.identity));



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
            // Collision Check for Lion eats Male Goat  
            for (int i = 0; i < Lions.Count; i++)
            {
                //foreach (GameObject Lion in Lions)
                //{
                for (int j = 0; j < MaleGoats.Count; j++)
                {
                    if (Lions[i].transform.position == MaleGoats[j].transform.position)
                {
                    Destroy(MaleGoats[j]);
                    MaleGoats.Remove(MaleGoats[j]);
                    Debug.Log("Male Goat Killed");
                }

            }
            }
            // Collision Check for Lion eats FeMale Goat  
            for (int i = 0; i < Lions.Count; i++)
            {
                for (int j = 0; j < FemaleGoats.Count; j++)
                {
                    if (Lions[i].transform.position == FemaleGoats[j].transform.position)
                    {
                        //Debug.Log("FeMale Goat Killed");
                        Destroy(FemaleGoats[j]);
                        FemaleGoats.Remove(FemaleGoats[j]);
                    }

                }
            }


        //// Collision Check for Goat eats Trees
        //for (int i = 0; i < Trees.Count; i++)
        //{
        //    for (int j = 0; j < Goats.Count; j++)
        //    {
        //        if (Goats[j].transform.position == Trees[i].transform.position)
        //        {
        //            Debug.Log("Goat Ate Tree");
        //            //Destroy(Trees[i]);
        //            //Trees.Remove(Trees[i]);
        //        }
        //    }
        //}
    }

    public void Mating()
    {
        //Collision Check for Goat Mating
        for (int i = 0; i < MaleGoats.Count; i++)
        {
            for (int j = 0; j < FemaleGoats.Count; j++)
            {
                if (FemaleGoats[j].transform.position == MaleGoats[i].transform.position)

                {
                    int rand = Random.Range(1, 3);
                    if (MaleGoats.Count <= 10 && rand == 1)
                    {
                        Debug.Log("Male Goats Born");

                        MaleGoats.Add(Instantiate(kingdom[0], MaleGoats[i].transform.position, Quaternion.identity));
                    }
                    
                    else if(FemaleGoats.Count <= 10 && rand == 2)
                    {
                        Debug.Log("FeMale Goats Born");

                        FemaleGoats.Add(Instantiate(kingdom[0], MaleGoats[i].transform.position, Quaternion.identity));
                    }
                }
                else
                {
                    Debug.Log("Not Mating");
                }
            }
        }
    }


    private void Replenish()
    {
        // Collision Check for Goat eats Tree 
        for (int i = 0; i < MaleGoats.Count; i++)
        {
            for (int j = 0; j < Trees.Count; j++)
            {
                if (MaleGoats[i].transform.position == Trees[j].transform.position)
                {
                    //Debug.Log("Healed");
                    //goat.currentLifeSpan = goat.defaultLifeSpan;
                }
            }
        }
    }

    private void HungerKills()
    {
        // Collision Check for Goat eats Tree 
        for (int i = 0; i < MaleGoats.Count; i++)
        {
            //if (!goat.IsALive())
            //{
            //    Destroy(MaleGoats[i]);
            //    MaleGoats.Remove(MaleGoats[i]);
            //}
        }
    }


    public Vector3 RandPos()
    {
        int rand = Random.Range(0, RandomPositions.Count);
        Vector3 pos = RandomPositions[rand];
        return pos;
    }
}
