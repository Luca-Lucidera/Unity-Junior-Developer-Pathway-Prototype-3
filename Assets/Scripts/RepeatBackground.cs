using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;


    void Start()
    {
        //posizione iniziale 
        startPosition = transform.position;

        //Il background è composto in 2 parti uguali, quindi noi dobbiamo ripetere da metà background in poi
        //Questo metodo serve per avere un qualcosa che cambia nel tempo
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }


    void Update()
    {
        //Quando la metà del background arriva all'inizio della scena si riparte dall'inizio
        if (startPosition.x - repeatWidth > transform.position.x)
        {
            transform.position = startPosition;
        }
    }
}
