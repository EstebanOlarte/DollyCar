using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerPC : MonoBehaviour {

   
    private GameObject player;
    public int coin, score;
    public Text scoreText , coinText, scoreTextEnd, coinTextEnd;
    public Animator gameOverCanvas,coinCanvas;
   
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(score < player.transform.position.y)
        {
            score = (int) player.transform.position.y;
        }
        scoreText.text = "" + score;
        coinText.text = "" + coin;
        scoreTextEnd.text = "" + score;
        coinTextEnd.text = "" + coin;
    }
    public void GameOver()
    {
        gameOverCanvas.SetTrigger("Appear");
    }
    public void AddCoin()
    {
        coinCanvas.SetTrigger("Add");
        coin++;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
