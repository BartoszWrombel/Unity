using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab03_zad6 : MonoBehaviour
{
    public Transform target; // Obiekt, który bêdzie œledzony
    public float smoothTime = 0.3f; // Czas wyg³adzania
    private Vector3 velocity = Vector3.zero; // Prêdkoœæ, która bêdzie u¿ywana w SmoothDamp
    public float lerpSpeed = 0.1f; // Prêdkoœæ Lerp

    void Update()
    {
        // Obliczenie nowej pozycji
        Vector3 targetPosition = target.position; // Pozycja obiektu œledzonego

        // SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Lerp
        //transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed);
    }
}