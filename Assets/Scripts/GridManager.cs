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

    public float speed;

    public bool timerOn = false;
    public float timeLeft = 1f;



    private void Start()
    {
        
        GenerateGrid();
        timerOn = true;
    }
    private void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else if(timeLeft <= 0)
            {
                timeLeft = 1f;
            }
        }
    }

    public void GenerateGrid()
    {
        for (int i = 0; i < row; i++)
        {

            for (int j = 0; j < column; j++)
            {
                Instantiate(tile, new Vector3(columnSpace * i, rowSpace * j), Quaternion.identity);
                //Instantiate(kingdom[Random.Range(0, 4)], new Vector3(columnSpace * Random.Range(0, row), rowSpace * Random.Range(0, column)), Quaternion.identity);
                


            }

        }
        for (int i = 0; i < 1; i++)
        {
            Instantiate(kingdom[0], new Vector3(columnSpace * 4, rowSpace * 4), Quaternion.identity);
        }
        Instantiate(kingdom[1], new Vector3(columnSpace * 4, rowSpace * 5), Quaternion.identity);
        cam.transform.position = new Vector3((float)row / 2 + xAdjust, (float)column / 2 + yAdjust, -10);

        

    }
}
