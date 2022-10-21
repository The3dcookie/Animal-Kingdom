using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    GridManager grScr;
    Rigidbody2D rb2D;
    
    private void Awake()
    {
        grScr = GetComponent<GridManager>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(new Vector3(3.6f, 3.6f) * Time.deltaTime);
        //gameObject.transform.position = new Vector3(1.2f, 0, 0);
        //StartCoroutine(Wait());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = new Vector2(0, 1) /** speed * Time.deltaTime*/;
        //transform.Translate(new Vector2(0, 1) * grScr.speed * Time.deltaTime);

        
        //transform.Translate(new Vector3(grScr.columnSpace * 1, grScr.rowSpace * 1) * grScr.speed * Time.deltaTime);
        

        //if (transform.tag.Equals("Goat"))
        //{
        //    transform.position += transform.right * Time.deltaTime * speed;
        //    Debug.Log("GOatIsMOving");
        //}
    }
}
