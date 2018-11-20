using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistas : MonoBehaviour {

    public int X;
    public int Y;
    public bool active = false;
    public GenerationFloor generationFloor;
    Transform carPlayer;
    public float dist = 16;
    // Use this for initialization
    void Start()
    {
        carPlayer = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update () {

        if (transform.position.y < carPlayer.transform.position.y - dist) 
        {
            active = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            generationFloor.CrearPista();
        
        }

    }
   
   

}
