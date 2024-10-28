using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab03_zad6 : MonoBehaviour
{
    public Transform target; // Obiekt, kt�ry b�dzie �ledzony
    public float smoothTime = 0.3f; // Czas wyg�adzania
    private Vector3 velocity = Vector3.zero; // Pr�dko��, kt�ra b�dzie u�ywana w SmoothDamp
    public float lerpSpeed = 0.1f; // Pr�dko�� Lerp

    void Update()
    {
        // Obliczenie nowej pozycji
        Vector3 targetPosition = target.position; // Pozycja obiektu �ledzonego

        // SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Lerp
        //transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed);
    }
}