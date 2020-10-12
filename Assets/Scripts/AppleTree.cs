using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Prefab for instantiating apples
    public GameObject rApplePrefab;
    public GameObject gApplePrefab;
    public float speed =1f;

    //Distance where AppleTree Turns around
    public float leftAndRightEdge = 20f;

    //Chance that the apple tree will change directions
    public float chanceToChangeDirections = 0.1f;

    //Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    void Start(){
        //Dropping apples every second
        Invoke("DropApple",2f);
    }

    void Update(){
        //Basic Movement
        Vector3 pos = transform.position;     
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Directions
        if( pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed);
        }
        else if(pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate(){
        //Changing Direction Randomly is now time-based because of FixedUpdate()
        if(Random.value < chanceToChangeDirections){
            speed *= -1;
        }
    }

    void DropApple(){
        
        string s = SceneManager.GetActiveScene().name;
        if(s == "_Scene_0"){
            GameObject apple = Instantiate<GameObject>(rApplePrefab);
            apple.transform.position = transform.position;
            Invoke("DropApple", secondsBetweenAppleDrops);
        }
        else{
            int i = Random.Range(0,2);
            
            GameObject apple;
            if(i == 0){
                apple = Instantiate<GameObject>(rApplePrefab);
            }
            else{
                apple = Instantiate<GameObject>(gApplePrefab);
            }
            apple.transform.position = transform.position;
            Invoke("DropApple", secondsBetweenAppleDrops);
        }
    }
}
