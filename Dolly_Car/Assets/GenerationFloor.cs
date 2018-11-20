using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationFloor : MonoBehaviour {


    public Pistas[] pistas;
    public GameObject oActualP;
    public int actualPY;
    public GameObject[] coins;
 
 	// Use this for initialization
	void Start () {
        coins = GameObject.FindGameObjectsWithTag("Coin");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CrearPista()
    {
        int X = 0 ;
        switch (actualPY)
        {
            case 2:
                X = 4;
                break;
            case 3:
                X = 1;
                break;
            case 4:
                X = 2;
                break;
        }
       int Y = Random.Range(2, 5);
       
        int Z = pistas.Length ;
        for (int i = 0; i < Z; i++ )
        {
            if (pistas[i].X == X)
            {
              
                if (pistas[i].Y == Y)
                {
                 
                    if (!pistas[i].active )
                    {
                        switch (X)
                        {
                            case 1:
                                pistas[i].transform.position = new Vector3(oActualP.transform.position.x, oActualP.transform.position.y + 4f);
                                break;
                            case 2:
                                pistas[i].transform.position = new Vector3(oActualP.transform.position.x + 4f, oActualP.transform.position.y);
                                break;
                            case 4:
                                pistas[i].transform.position = new Vector3(oActualP.transform.position.x - 4f, oActualP.transform.position.y);
                                break;
                        }
                        actualPY = Y;
                        oActualP = pistas[i].gameObject;

                        //random para crear coin o no 
                        int c = Random.Range(0, 3);
                        if(c == 1)
                        {
                            CreateCoin(pistas[i].gameObject.transform);
                        }
                     
                        pistas[i].active = true;
                        break;


                    }

                  

                }
            }
            if (i == Z - 1) 
            {
                CrearPista();
            }
        }
  
     

    }
    public void CreateCoin(Transform pistaActual)
    {
        for (int i = 0; i < coins.Length; i++ )
        {
            if(!coins[i].GetComponent<Coin>().state)
            {

                float _x = Random.Range(pistaActual.position.x -0.6f, pistaActual.position.x + 0.6f);
                float _y = Random.Range(pistaActual.position.y - 0.6f, pistaActual.position.y + 0.6f);
                coins[i].gameObject.transform.position = new Vector2(_x, _y);
                coins[i].GetComponent<Coin>().state = true;
                break;
            }
        }

    }
}
