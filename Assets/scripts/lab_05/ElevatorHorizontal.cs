using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorHorizontal : MonoBehaviour
{
    public float elevatorSpeed = 2f; // prędkość platformy
    public float distance = 6.6f; // odległość jaką ma przebyć platforma
    private bool isRunning = false; // czy platforma jest w ruchu
    private bool movingToEnd = true; // kierunek ruchu
    private float startPosition; // pozycja startowa
    private float endPosition; // pozycja końcowa

    void Start()
    {
        // Ustawienie pozycji startowej i końcowej
        startPosition = transform.position.x;
        endPosition = transform.position.x + distance;
    }

    void Update()
    {
        // Jeśli platforma jest w ruchu
        if (isRunning)
        {
            // Przesuwanie platformy względem osi X
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime; 
            transform.Translate(move);

            // Jeśli platforma osiągnęła punkt końcowy
            if (movingToEnd && transform.position.x >= endPosition)
            {
                movingToEnd = false; // zmiana kierunku ruchu na przeciwny
                elevatorSpeed = -elevatorSpeed; // ruch w przeciwną stronę
            }
            // Jeśli platforma osiągnęła punkt początkowy
            else if (!movingToEnd && transform.position.x <= startPosition)
            {
                isRunning = false; // zatrzymanie platformy
                transform.position = new Vector3(startPosition, transform.position.y, transform.position.z); // ustawienie platformy na pozycji startowej w przypadku przesunięcia
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            // Upewnienie się, że platforma się nie porusza
            if (!isRunning)
            {
                movingToEnd = true; // ustawienie kierunku ruchu na punkt końcowy
                elevatorSpeed = Mathf.Abs(elevatorSpeed); // ruch w stronę punktu końcowego
                isRunning = true;  // uruchomienie platformy
            }
            other.transform.SetParent(transform); // przypisanie gracza do platformy
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.transform.SetParent(null); // usunięcie przypisania gracza do platformy
        }
    }
}