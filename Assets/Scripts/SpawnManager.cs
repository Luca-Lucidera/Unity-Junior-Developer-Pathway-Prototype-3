using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float startDelay = 0f;
    public float repeateRate = 2f;


    private Vector3 spawnPosition = new(25, 0, 0);
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //Spawno un ostacolo a inizio gioco
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeateRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
