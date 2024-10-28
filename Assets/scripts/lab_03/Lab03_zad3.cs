using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab03_zad3 : MonoBehaviour
{
    public float speed = 2.0f; // Prêdkoœæ poruszania siê obiektu
    private Vector3 startPosition; // Pozycja startowa
    void Start()
    {
        startPosition = transform.position; // Pobranie pozycji startowej
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0); // Przesuniêcie obiektu

        // Sprawdzamy, czy obiekt przemieœci³ siê o 10 jednostek od pozycji startowej
        if (Vector3.Distance(transform.position, startPosition) >= 10)
        {
            // Resetujemy pozycjê startow¹ dla kolejnego boku kwadratu
            startPosition = transform.position;

            // Obracamy obiekt o 90 stopni wokó³ osi Y
            transform.Rotate(0, 90, 0);
        }
    }
}
