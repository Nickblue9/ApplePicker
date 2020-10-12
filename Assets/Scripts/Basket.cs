using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    
    void Start(){
        //Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        //Get the Text Component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();

        //Set the starting number of points to 0
        if(SceneManager.GetActiveScene().name == "_Scene_0"){
            scoreGT.text = "0";
        }
        else if(SceneManager.GetActiveScene().name == "_Scene_1"){
            scoreGT.text = "5000";
        }
    }

    void Update()
    {
        //Get the current mouse position
        Vector3 mousePos2D = Input.mousePosition;

        //The Camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3d game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the x position of this Basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll){
        //Find out what hit the basket
        GameObject collideWith = coll.gameObject;
        if(collideWith.tag=="Red_Apple" || collideWith.tag=="Green_Apple"){
            Destroy(collideWith);

            //Parse the text of the scoreGT int an int
            int score = int.Parse(scoreGT.text);
            
            //add points for catching the apple
            if(collideWith.tag=="Red_Apple"){
                score += 100;
                if(score==5000){
                    SceneManager.LoadScene("_Scene_1");
                }
            }
            else if(collideWith.tag=="Green_Apple"){
                score += 250;
            }

            //Convert the score back to a string and display it
            scoreGT.text = score.ToString();

            if (score > HighScore.score){
                HighScore.score = score;
            }
        }
    }
}
