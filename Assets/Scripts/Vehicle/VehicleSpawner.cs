using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    //Araclar spawn oldu�unda bozuk spawn oluyor bu y�zden bu sistemden vazgectim...
    //Denemek i�in sahnedeki ara�lar� kapat�n vehicle spawneri ve spawn points'i a��p deneyebilirsiniz.

    public GameObject[] cars;
    public Transform[] spawnPoints;

    private void Start()
    {
        CreateVehicle();
    }

    private void CreateVehicle()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            var random = Random.Range(cars.Length - cars.Length, cars.Length);

            Debug.Log($"Test List {cars.Length - 1}");
            Debug.Log("Normal List " + cars.Length);

            var car = Instantiate(cars[random]);
            car.GetComponent<RCC_CarControllerV3>().enabled = false;
            car.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            car.transform.position = spawnPoints[i].transform.position;
            car.transform.rotation = Quaternion.Euler(new Vector3(0, -65, 0));
        }
    }

}
