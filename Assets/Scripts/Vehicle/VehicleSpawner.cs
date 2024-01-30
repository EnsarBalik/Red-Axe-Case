using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    //Araclar spawn olduðunda bozuk spawn oluyor bu yüzden bu sistemden vazgectim...
    //Denemek için sahnedeki araçlarý kapatýn vehicle spawneri ve spawn points'i açýp deneyebilirsiniz.

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
