using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class GridManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private GameObject animal;
    [SerializeField]
    private int column, row;
    [SerializeField]
    private float columnSpace,rowSpace;
    [SerializeField]
    Camera cam;
    [SerializeField]
    private float xAdjust, yAdjust;
    [SerializeField]
    private GameObject[] kingdom;



    private void Start()
    {
        GenerateGrid();
    }
    private void Update()
    {
        
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < row; i++)
        {
            
            for (int j = 0; j < column; j++)
            {                
                Instantiate(tile, new Vector3(columnSpace * i,rowSpace * j), Quaternion.identity);
                Instantiate(kingdom[Random.Range(0,4)], new Vector3(columnSpace * Random.Range(0,row), rowSpace * Random.Range(0,column)), Quaternion.identity);
            }   

        }
        cam.transform.position = new Vector3((float)row / 2 + xAdjust, (float)column / 2 + yAdjust, -10);
    }

}
