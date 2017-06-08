using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionTerrian : MonoBehaviour
{
    Car driver;


    private void OnTriggerStay2D(Collider2D other)
    {
        driver = other.GetComponent<Car>();
        driver.Speed = 10;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        driver = other.GetComponent<Car>();
        driver.Speed = 1;
    }
}
