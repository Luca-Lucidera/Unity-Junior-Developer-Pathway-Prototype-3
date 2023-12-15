using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15f;
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        //A servono i dati che sono legati al GameObject "Player" per lo script PlayerController
        //Con questo pezzo di codice vado a prendere i dati presenti nella classe PlayerController
        //È una sorta di Dependency Injection
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        //vado a eliminare SOLO gli ostacoli
        if(transform.position.x <= -10 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
