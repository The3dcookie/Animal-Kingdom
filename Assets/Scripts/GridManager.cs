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
    List<GameObject> MaleGoats = new List<GameObject>();
    List<GameObject> FemaleGoats = new List<GameObject>();


    List<Vector3> RandomPositions = new List<Vector3>();
    List<GameObject> Trees = new List<GameObject>();

    public bool isBorn = false;
    public Vector3 birthPoint;

    private void Start()
    {
        GenerateGrid();
        timerOn = true;
    }
    private void Update()
    {
        TimerOn();
        Mating();
        ColCheck();
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



        //Instantiate FeMale Goats
        for (int i = 0; i < 7; i++)
        {
            //Instantiate(kingdom[0], new Vector3(columnSpace * 4, rowSpace * 4), Quaternion.identity);

            FemaleGoats.Add(Instantiate(kingdom[0], RandPos(), Quaternion.identity));
            RandomPositions.Remove(FemaleGoats[i].transform.position);


            //Instantiate(kingdom[0], new Vector3(columnSpace * Random.Range(0, row), rowSpace * Random.Range(0, column)), Quaternion.identity);
        }
        //Instantiate(kingdom[1], new Vector3(columnSpace * 6, rowSpace * 5), Quaternion.identity);


        //Instantiate Male Goats
        for (int i = 0; i < 7; i++)
        {
            //Instantiate(kingdom[0], new Vector3(columnSpace * 4, rowSpace * 4), Quaternion.identity);

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
        //try
        //{
            // Collision Check for Lion eats Male Goat  
            for (int i = 0; i < Lions.Count; i++)
            {
                //foreach (GameObject Lion in Lions)
                //{
                for (int j = 0; j < MaleGoats.Count; j++)
                {
                    if (Lions[i].transform.position == MaleGoats[j].transform.position)
                    {
                        //Debug.Log("Male Goat Killed");
                        Destroy(MaleGoats[j]);
                        MaleGoats.Remove(MaleGoats[j]);
                    }

                }
                //}
            }
            // Collision Check for Lion eats FeMale Goat  
            for (int i = 0; i < Lions.Count; i++)
            {
                //foreach (GameObject Lion in Lions)
                //{
                for (int j = 0; j < FemaleGoats.Count; j++)
                {
                    if (Lions[i].transform.position == FemaleGoats[j].transform.position)
                    {
                        //Debug.Log("FeMale Goat Killed");
                        Destroy(FemaleGoats[j]);
                        FemaleGoats.Remove(FemaleGoats[j]);
                    }

                }
                //}
            }
        //}
        //catch (Exception)
        //{
        //    Debug.Log("Goats Finished");
        //}






            


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
                    //Debug.Log("Goats Mating");
                    //isBorn = true;
                    //birthPoint = MaleGoats[i].transform.position;

                    Debug.Log("Goat Born");

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


    public Vector3 RandPos()
    {
        int rand = Random.Range(0, RandomPositions.Count);
        Vector3 pos = RandomPositions[rand];
        return pos;
    }




}
