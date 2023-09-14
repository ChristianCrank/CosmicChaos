using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2AI : MonoBehaviour
{
    GameObject Target;// The Target is the Spacestation
    float distance; //Distance is the space bewtween the ship and the Spacestation
    bool inRange = false;//InRange is trueif the spaceship is within a certain distance of the spaceship

    float time;//Basic timer to control how fast the ship shoots
    Transform rocketSpawn;// Location where the rocket will shoot 
    GameObject rocket;// Name of rocket projecctile


    float speed = 7f;//Speed of the ship


    /// <summary>
    /// Shoot method is a basic method for ship to fire its weapon every 5 seconds
    /// </summary>
    void Shoot()
    {
        if (time > 5)
        {
            time = 0;
            transform.LookAt(Target.transform);
            Instantiate(rocket, rocketSpawn.position, rocketSpawn.rotation);
        }
    }

    /// <summary>
    /// Awake is used  to locate the the player's "HomeBase" when the ship spawns
    /// doing this allows the ships to not sit as "unactivated" game objects in the game and only spawn/take up 
    /// space when needed
    /// </summary>
    void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("HomeBase");
        Debug.Log("Name: " + Target.name);
    }


    // Start is called before the first frame update
    void Start()
    {

    }



    /// <summary>
    /// Just Verication and Adjusting things. 
    ///
    /// </summary>
    void Update()
    {
        float move = speed * Time.deltaTime; //move is made and assigned a value to control how fast the ship moves
        distance = Vector3.Distance(Target.transform.position, this.transform.position);//distance between the ship is constantly calculated

        if (distance <= 5) // If distance is less than 5, the scripts sets inRange to true which procs another statement and the ship begins to shoot
        {
            inRange = true;
            Shoot();
        }

        if (!inRange)// if inRange is not false the ship stops moving towardsthe homebase
        {
            //Debug.Log("this is being reached");
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector3((Target.transform.position.x - 20), 0, 0), move);// the stoping distance is an offset of where the HomeBase is.
        }

        time += Time.deltaTime;//Updating time...
    }
}
