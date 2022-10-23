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

        }

        private Vector3 RandReloc(Vector3 dir)
        {
            //Correct Outside Boundary
            if (dir.x >= gridManager.columnSpace * (gridManager.row))
            {
                //Debug.Log("Greater Than X");
                return new Vector3(dir.x - 1.2f * 2, dir.y);
            }
            else if (dir.x <= 0)
            {
                return new Vector3(dir.x + 1.2f * 2, dir.y);
            }
            else if (dir.y >= gridManager.rowSpace * (gridManager.column) - 1)
            {
                //Debug.Log("Greater Than Y");
                return new Vector3(dir.x, dir.y - 1.2f * 2);
            }
            else if (dir.y <= 0 - gridManager.columnSpace)
            {
                //Debug.Log("Less Than Y");
                return new Vector3(dir.x, dir.y + 1.2f * 2);
            }
            return transform.position;
        }

        public Vector3 randMov(Vector3 pos)
        {
            int val = Random.Range(1, 6);
            if (val == 1)
            {
                transform.position = new Vector3(pos.x + 1.2f, pos.y);
                //transform.Translate(new Vector2(Random.Range(-2, 2) * 1.2f, 0));
                //transform.position = new Vector2(Random.Range(-2, 2) * 1.2f, 0);
                return transform.position;
            }
            else if (val == 3)
            {
                transform.position = new Vector3(pos.x - 1.2f, pos.y);
                //transform.Translate(new Vector2(Random.Range(-2, 2) * 1.2f, 0));
                //transform.position = new Vector2(Random.Range(-2, 2) * 1.2f, 0);
                return transform.position;
            }
            else if (val == 2)
            {
                transform.position = new Vector3(pos.x , pos.y + 1.2f);
                //transform.Translate(new Vector2(0, Random.Range(-2, 2) * 1.2f));
                //transform.Translate(new Vector2(0, Random.Range(-1, 3) * 1.2f));
                return transform.position;
            }
            else if (val == 4)
            {
                transform.position = new Vector3(pos.x, pos.y - 1.2f);
                //transform.Translate(new Vector2(0, Random.Range(-2, 2) * 1.2f));
                //transform.Translate(new Vector2(0, Random.Range(-1, 3) * 1.2f));
                return transform.position;
            }
            else if (val == 5)
            {
                transform.position = new Vector3(pos.x, pos.y);
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
                return true;
            }
            else if (dir.x <= 0 - gridManager.columnSpace)
            {
                return true;
            }
            else if (dir.y >= gridManager.rowSpace * (gridManager.column) - 1)
            {
                return true;
            }
            else if (dir.y <= 0 - gridManager.columnSpace)
            {
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

            if (gridManager.timeLeft <= 0)
            {
                //Vector3 newPos = new Vector3(pos.x, pos.y + gridManager.columnSpace, 0);
                Vector3 newPos = randMov(pos);

                if (!BoundaryCheck(newPos))
                {
                    //randMov();
                    transform.position = newPos;
                    
                }
                else if (BoundaryCheck(newPos))
                {
                    transform.position = RandReloc(newPos);
                }
            }
        }
        #endregion
    }
}
