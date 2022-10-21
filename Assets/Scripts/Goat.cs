using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{

  
    public class Goat : MonoBehaviour
    {
        #region Fields
        public bool canEat = false;
        public bool isEaten = false;
        Rigidbody2D rb2D;
        GridManager gridManager;

        public bool withinBoundary = false;
        public bool outsideBoundary = false;

        

        #endregion


        #region Constructor

        public Goat(string name, bool canEat, bool isEaten)
        {
            this.name = name;
            this.canEat = canEat;
            this.isEaten = isEaten;
        }

        #endregion


        #region Unity

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
            gridManager = FindObjectOfType<GridManager>();
        }

        private void Start()
        {
            //StartCoroutine(Wait());
        }

        private Vector3 RandReloc(Vector3 dir)
        {
            //Correct Outside Boundary
            if (dir.x >= gridManager.columnSpace * (gridManager.row))
            {
                //Debug.Log("Greater Than X");
                return new Vector3(dir.x - 1.2f, dir.y);
            }
            else if (dir.x <= 0)
            {
                Debug.Log(dir);
                return new Vector3(dir.x + 1.2f, dir.y);
            }
            else if (dir.y >= gridManager.rowSpace * (gridManager.column) - 1)
            {
                //Debug.Log("Greater Than Y");
                return new Vector3(dir.x, dir.y - 1.2f);
            }
            else if (dir.y <= 0 - gridManager.columnSpace)
            {
                //Debug.Log("Less Than Y");
                return new Vector3(dir.x, dir.y + 1.2f);
            }
            return transform.position;
        }

        public Vector3 randMov()
        {
            int val = /*Random.Range(1, 3)*/1;
            if (val == 1)
            {
                transform.position = new Vector3(transform.position.x + 1.2f, transform.position.y);
                //transform.Translate(new Vector2(Random.Range(-2, 2) * 1.2f, 0));
                //transform.position = new Vector2(Random.Range(-2, 2) * 1.2f, 0);
                return transform.position;
            }
            else if (val == 2)
            {
                transform.position = new Vector3(transform.position.x + 1.2f * 2, transform.position.y);
                //transform.Translate(new Vector2(0, Random.Range(-2, 2) * 1.2f));
                //transform.Translate(new Vector2(0, Random.Range(-1, 3) * 1.2f));
                return transform.position;
            }
            return transform.position;
        }




        private bool BoundaryCheck(Vector3 dir)
        {
            //Correct Outside Boundary
            if (dir.x  >= gridManager.columnSpace * (gridManager.row))
            {
                //Debug.Log("Greater Than X");
                dir = transform.position;
                transform.position = new Vector3 (dir.x - 1.2f,dir.y);
                return true;
            }
            else if (dir.x <= 0 - gridManager.columnSpace)
            {
                //Debug.Log("Less Than X");
                dir.x = transform.position.x;
                return true;
            }
            else if (dir.y >= gridManager.rowSpace * (gridManager.column) - 1)
            {
                //Debug.Log("Greater Than Y");
                dir = transform.position;
                transform.position = new Vector3(dir.x , dir.y - 1.2f);
                return true;
            }
            else if (dir.y <= 0 - gridManager.columnSpace)
            {
                //Debug.Log("Less Than Y");
                dir.y = transform.position.y;
                return true;
            }
            return false;

            //// Correct Within Boundary
            //if (transform.position.x <= gridManager.columnSpace * gridManager.row)
            //{
            //    //Debug.Log("Within Grid Boundary");
            //    withinBoundary = true;
            //}
            //if (transform.position.x > 0)
            //{
            //    //Debug.Log("Within Grid Boundary");
            //    withinBoundary = true;
            //}

            //if (transform.position.y <= gridManager.rowSpace * gridManager.column)
            //{
            //    //Debug.Log("Within Grid Boundary");
            //    withinBoundary = true;
            //}
            //if (transform.position.y > 0)
            //{
            //    //Debug.Log("Within Grid Boundary");
            //    withinBoundary = true;
            //}



        }

        private void Update()
        {

            Vector3 pos;
            pos = transform.position;


            //Debug.Log(randMov());


            //Debug.Log("Timer Left" );

            if (gridManager.timeLeft <= 0)
            {






                //if (pos.x + gridManager.columnSpace < gridManager.columnSpace * (gridManager.row - 1))
                //{
                //    Debug.Log("Can Move");
                Vector3 newPos = new Vector3(pos.x + gridManager.columnSpace, pos.y , 0);

                if (!BoundaryCheck(newPos))
                {
                    //randMov();
                    transform.position = newPos;
                    
                }
                else if (BoundaryCheck(newPos))
                {
                    transform.position = new Vector3(pos.x - gridManager.columnSpace, pos.y , 0);
                    //RandReloc(pos);
                }

                //}
                //else if (pos.x + gridManager.columnSpace >= gridManager.columnSpace * (gridManager.row - 1))
                //{
                //    Debug.Log("Can't Move");
                //    transform.position = new Vector3(pos.x - 1.2f, pos.y, 0);
                //}
                ////}


            }


            //if (outsideBoundary)
            //{
            //    //Debug.Log("Outside");
            //    transform.position = pos;

            //    if (gridManager.timeLeft <= 0)
            //    {
            //        //transform.position = new Vector3(gridManager.columnSpace * Random.Range(0, gridManager.row),
            //        //    gridManager.rowSpace * Random.Range(0, gridManager.column));



            //        if (gameObject.transform.position.x >= gridManager.columnSpace * (gridManager.row - 1))
            //        {
            //            transform.position = new Vector3(pos.x - 1.2f, pos.y, 0);
            //        }
            //        if (transform.position.x <= 0)
            //        {
            //            transform.position = new Vector3(pos.x + 1.2f, pos.y, 0);
            //        }
            //        if (transform.position.y >= gridManager.rowSpace * (gridManager.column - 2))
            //        {
            //            transform.position = new Vector3(pos.x, pos.y - 1.2f, 0);
            //        }
            //        if (transform.position.y <= 0)
            //        {
            //            transform.position = new Vector3(pos.x, pos.y + 1.2f, 0);
            //        }
            //    }
            //    outsideBoundary = false;
            //}
        }
        #endregion
    }
}
