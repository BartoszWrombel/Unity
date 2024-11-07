using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorHorizontal : MonoBehaviour
{
    public float elevatorSpeed = 2f; // pr�dko�� platformy
    public float distance = 6.6f; // odleg�o�� jak� ma przeby� platforma
    private bool isRunning = false; // czy platforma jest w ruchu
    private bool movingToEnd = true; // kierunek ruchu
    private float startPosition; // pozycja startowa
    private float endPosition; // pozycja ko�cowa

    void Start()
    {
        // Ustawienie pozycji startowej i ko�cowej
        startPosition = transform.position.x;
        endPosition = transform.position.x + distance;
    }

    void Update()
    {
        // Je�li platforma jest w ruchu
        if (isRunning)
        {
            // Przesuwanie platformy wzgl�dem osi X
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime; 
            transform.Translate(move);

            // Je�li platforma osi�gn�a punkt ko�cowy
            if (movingToEnd && transform.position.x >= endPosition)
            {
                movingToEnd = false; // zmiana kierunku ruchu na przeciwny
                elevatorSpeed = -elevatorSpeed; // ruch w przeciwn� stron�
            }
            // Je�li platforma osi�gn�a punkt pocz�tkowy
            else if (!movingToEnd && transform.position.x <= startPosition)
            {
                isRunning = false; // zatrzymanie platformy
                transform.position = new Vector3(startPosition, transform.position.y, transform.position.z); // ustawienie platformy na pozycji startowej w przypadku przesuni�cia
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed� na wind�.");
            // Upewnienie si�, �e platforma si� nie porusza
            if (!isRunning)
            {
                movingToEnd = true; // ustawienie kierunku ruchu na punkt ko�cowy
                elevatorSpeed = Mathf.Abs(elevatorSpeed); // ruch w stron� punktu ko�cowego
                isRunning = true;  // uruchomienie platformy
            }
            other.transform.SetParent(transform); // przypisanie gracza do platformy
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed� z windy.");
            other.transform.SetParent(null); // usuni�cie przypisania gracza do platformy
        }
    }
}