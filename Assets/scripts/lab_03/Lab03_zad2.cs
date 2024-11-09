using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lab03_zad2 : MonoBehaviour
{
    public float speed = 2.0f; // Prędkość poruszania się obiektu
    private Vector3 startPosition; // Pozycja startowa

    void Start()
    {
        startPosition = transform.position; // Pobranie pozycji startowej
    }

    void Update() {
        transform.Translate(speed * Time.deltaTime, 0, 0); // Przesunięcie obiektu

        //lub
        //Vector3 newPosition = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        //transform.position = newPosition;

        if (Vector3.Distance(transform.position, startPosition) >= 10)  // Sprawdzamy czy obiekt przesunął się o 10 jednostek
        {
            speed = -speed; // Odwracamy kierunek ruchu
            startPosition = transform.position; // Ustawiamy nową pozycję startową
        }
    }
}
