using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid; 
    int scoreplayerOne;
    int scoreplayerTwo;
    Text scoreTextOne;
    Text scoreTextTwo;
    Text winnerText;
    GameObject finishState;
    public AudioClip mediumHit;
    public AudioClip heavyHit;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
        Vector2 heading = new Vector2(2, 0).normalized;
        rigid.AddForce(heading * force);
        scoreplayerOne = 0;
        scoreplayerTwo = 0;
        scoreTextOne = GameObject.Find("Score1").GetComponent<Text>();
        scoreTextTwo = GameObject.Find("Score2").GetComponent<Text>();
        finishState = GameObject.Find("Finish");
        winnerText = GameObject.Find("Winner").GetComponent<Text>();
        finishState.SetActive(false);
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "LeftBorder")
        {
            
            ResetBall();
            Vector2 heading = new Vector2(2, 0).normalized;
            rigid.AddForce(heading * force);
            scoreplayerTwo += 1;
            DisplayScore();
            if (scoreplayerTwo == 5)
            {
                finishState.SetActive(true);
                winnerText.text = "sudut kanan pemenang!";
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.name == "RightBorder")
        {
            ResetBall();
            Vector2 heading = new Vector2(-2, 0).normalized;
            rigid.AddForce(heading * force);
            scoreplayerOne += 1;
            DisplayScore();
            if (scoreplayerOne == 5)
            {
                finishState.SetActive(true);
                winnerText.text = "sudut kiri pemenang!";
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.name =="Paddle1"|| collision.gameObject.name == "Paddle2")
        {
            audio.PlayOneShot(heavyHit);
            float degree = (transform.position.y - collision.transform.position.y) * 5f;
            Vector2 heading = new Vector2(rigid.velocity.x, degree).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(heading * force * 2);

        }
        else
        {
            audio.PlayOneShot(mediumHit);

        }



    }
    void DisplayScore()
    {
        scoreTextOne.text = scoreplayerOne + "";
        scoreTextTwo.text = scoreplayerTwo + "";
    }


}
