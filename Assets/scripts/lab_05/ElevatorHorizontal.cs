using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorHorizontal : MonoBehaviour
{
    public float elevatorSpeed = 2f; // prêdkoœæ platformy
    public float distance = 6.6f; // odleg³oœæ jak¹ ma przebyæ platforma
    private bool isRunning = false; // czy platforma jest w ruchu
    private bool movingToEnd = true; // kierunek ruchu
    private float startPosition; // pozycja startowa
    private float endPosition; // pozycja koñcowa

    void Start()
    {
        // Ustawienie pozycji startowej i koñcowej
        startPosition = transform.position.x;
        endPosition = transform.position.x + distance;
    }

    void Update()
    {
        // Jeœli platforma jest w ruchu
        if (isRunning)
        {
            // Przesuwanie platformy wzglêdem osi X
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime; 
            transform.Translate(move);

            // Jeœli platforma osi¹gnê³a punkt koñcowy
            if (movingToEnd && transform.position.x >= endPosition)
            {
                movingToEnd = false; // zmiana kierunku ruchu na przeciwny
                elevatorSpeed = -elevatorSpeed; // ruch w przeciwn¹ stronê
            }
            // Jeœli platforma osi¹gnê³a punkt pocz¹tkowy
            else if (!movingToEnd && transform.position.x <= startPosition)
            {
                isRunning = false; // zatrzymanie platformy
                transform.position = new Vector3(startPosition, transform.position.y, transform.position.z); // ustawienie platformy na pozycji startowej w przypadku przesuniêcia
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na windê.");
            // Upewnienie siê, ¿e platforma siê nie porusza
            if (!isRunning)
            {
                movingToEnd = true; // ustawienie kierunku ruchu na punkt koñcowy
                elevatorSpeed = Mathf.Abs(elevatorSpeed); // ruch w stronê punktu koñcowego
                isRunning = true;  // uruchomienie platformy
            }
            other.transform.SetParent(transform); // przypisanie gracza do platformy
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed³ z windy.");
            other.transform.SetParent(null); // usuniêcie przypisania gracza do platformy
        }
    }
}