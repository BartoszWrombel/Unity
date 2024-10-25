using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad6 : MonoBehaviour
{
    public Transform target; // Obiekt, kt�ry b�dzie �ledzony
    float smoothTime = 0.3f; // Czas wyg�adzania
    private Vector3 velocity = Vector3.zero; // Pr�dko��, kt�ra b�dzie u�ywana w SmoothDamp
    public float lerpSpeed = 0.1f; // Pr�dko�� dla Lerp (warto�ci od 0 do 1)

    void Update()
    {
        // Obliczenie nowej pozycji
        Vector3 targetPosition = target.position; // Pozycja obiektu �ledzonego

        // G�adkie pod��anie za pozycj� w trzech osiach
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Lerp
        //transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed);
    }
}