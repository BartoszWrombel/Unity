using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab03_zad3 : MonoBehaviour
{
    public float speed = 2.0f; // Prędkość poruszania się obiektu
    private Vector3 startPosition; // Pozycja startowa
    void Start()
    {
        startPosition = transform.position; // Pobranie pozycji startowej
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0); // Przesunięcie obiektu

        // Sprawdzamy, czy obiekt przemieścił się o 10 jednostek od pozycji startowej
        if (Vector3.Distance(transform.position, startPosition) >= 10)
        {
            // Resetujemy pozycję startową dla kolejnego boku kwadratu
            startPosition = transform.position;

            // Obracamy obiekt o 90 stopni wokół osi Y
            transform.Rotate(0, 90, 0);
        }
    }
}
