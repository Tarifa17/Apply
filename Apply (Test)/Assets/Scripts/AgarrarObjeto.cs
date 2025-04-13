using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
    [SerializeField] private GameObject puntoAgarre;
    private GameObject objetoAgarrado = null;


    void Update()
    {
        if (objetoAgarrado!= null)
        {
            if (Input.GetKey("q"))
            {
                Rigidbody2D rb = objetoAgarrado.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }

                objetoAgarrado.transform.SetParent(null);
                objetoAgarrado = null;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Objetos"))
        {
            if (Input.GetKey("e") && objetoAgarrado == null)
            {
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    //rb.gravityScale = 0;
                    rb.isKinematic = true;
                }

                other.transform.position = puntoAgarre.transform.position;
                other.transform.SetParent(puntoAgarre.transform);
                objetoAgarrado = other.gameObject;
            }
        }
     }
}
