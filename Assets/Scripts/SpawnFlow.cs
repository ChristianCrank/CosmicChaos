using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnFlow : MonoBehaviour
{
    public TextMeshProUGUI text; //For testing (can be commented out if out)
    public Transform[] bigShipSpawn; // Array of transforms where big ship spawn
    public GameObject bigShip; //Big Ship

    public Transform[] smallShipSpawn; //Array of transforms where small ships spawn
    public GameObject smallShip; //Small Ship

    float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.text = "Time: " + timer;
        if (timer > 10.000f) // Basic set up to spawn ships every 10 seconds
        {
            SpawnShips();
        }

    }

    void SpawnShips()
    {
        Debug.Log("Spawning Big Ships");
        Instantiate(bigShip, bigShipSpawn[0].position, bigShipSpawn[0].rotation);
        Instantiate(bigShip, bigShipSpawn[1].position, bigShipSpawn[1].rotation);
        Instantiate(bigShip, bigShipSpawn[2].position, bigShipSpawn[2].rotation);

        Debug.Log("Spawning Small Ships");
        Instantiate(smallShip, smallShipSpawn[0].position, smallShipSpawn[0].rotation);
        Instantiate(smallShip, smallShipSpawn[1].position, smallShipSpawn[1].rotation);
        Instantiate(smallShip, smallShipSpawn[2].position, smallShipSpawn[2].rotation);
        Instantiate(smallShip, smallShipSpawn[3].position, smallShipSpawn[3].rotation);
        Instantiate(smallShip, smallShipSpawn[4].position, smallShipSpawn[4].rotation);

        timer = 0;
    }
}
