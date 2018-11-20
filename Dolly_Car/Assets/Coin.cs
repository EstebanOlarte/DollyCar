using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public bool state;
    public Transform poolSite;
    private ManagerPC managerPC;
	// Use this for initialization
	void Start () {
        managerPC = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ManagerPC>();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Unactive();
        }
        if (collision.gameObject.tag == "Deleter")
        {
            state = false;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
	public void Unactive()
	{

        managerPC.AddCoin();
        state = false;
        transform.position = poolSite.position;
	}

}
