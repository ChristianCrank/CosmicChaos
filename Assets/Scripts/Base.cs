using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int health = 100;
    private string rocketTag = "Rocket";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(rocketTag))
        {
            Debug.Log("Missile hit");
            health -= 5;
        }
    }
}
