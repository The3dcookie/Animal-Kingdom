using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Lion : MonoBehaviour
    {
        #region Fields

        Rigidbody2D rb2D;

        #endregion


        #region Unity Methods

        private void Start()
        {
            StartCoroutine(Wait());
        }

        System.Collections.IEnumerator Wait()
        {
            yield return new WaitForSeconds(3);
            Debug.Log("Moved");

            transform.Translate(new Vector2(2.4f, 0));
            yield return new WaitForSeconds(3);
            transform.Translate(new Vector2(0, 1.2f));


        }

        #endregion




    }
}
