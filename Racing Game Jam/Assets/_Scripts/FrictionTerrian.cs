using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionTerrian : MonoBehaviour
{
    Car driver;

    void OnTriggerEnter(Collider other)
    {
        driver = other.GetComponent<Car>();
        Debug.Log(driver.Speed);
    }

    private void OnTriggerStay(Collider other)
    {
        driver = other.GetComponent<Car>();
        driver.Speed = 10;
        Debug.Log(driver.Speed);
    }

    private void OnTriggerExit(Collider other)
    {
        driver = other.GetComponent<Car>();
        driver.Speed = 1;
        Debug.Log(driver.Speed);
    }
}
