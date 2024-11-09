using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab03_zad6 : MonoBehaviour
{
    public Transform target; // Obiekt, który będzie śledzony
    public float smoothTime = 0.3f; // Czas wygładzania
    private Vector3 velocity = Vector3.zero; // Prędkość, która będzie używana w SmoothDamp
    public float lerpSpeed = 0.1f; // Prędkość Lerp

    void Update()
    {
        // Obliczenie nowej pozycji
        Vector3 targetPosition = target.position; // Pozycja obiektu śledzonego

        // SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Lerp
        //transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed);
    }
}