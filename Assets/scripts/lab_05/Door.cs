using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float doorSpeed = 2f; // prędkość otwierania drzwi
    public float distance = 3.0f; // odległość otwierania drzwi
    // dla lewych drzwi trzeba ustawić w edytorze wartość ujemną
    private bool isOpening = false; // czy drzwi się otwierają
    private bool isClosed = true; // czy drzwi są zamknięte
    private bool isPlayer = false; // czy gracz jest w zasięgu drzwi
    private float closedPosition; // pozycja zamkniętych drzwi
    private float openPosition; // pozycja otwartych drzwi

    void Start()
    {
        // Ustawienie pozycji startowej i końcowej drzwi
        closedPosition = transform.position.z;
        openPosition = transform.position.z + distance;
    }

    void Update()
    {
        // Sprawdzamy, czy drzwi są w trakcie otwierania
        if (isOpening)
        {
            // Sprawdzamy, czy drzwi są zamknięte, jeśli tak, to otwieramy je
            if (isClosed)
            {
                // Wykonujemy ruch drzwi w kierunku otwarcia
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, openPosition), doorSpeed * Time.deltaTime);
                // Sprawdzamy, czy drzwi osiągnęły pozycję otwarcia
                if (transform.position.z >= openPosition && distance > 0 || transform.position.z <= openPosition && distance < 0)
                {
                    isOpening = false;
                    isClosed = false;
                }
            }
            // Jeśli drzwi są otwarte, zamykamy je
            else
            {
                // Wykonujemy ruch drzwi w kierunku zamknięcia
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, closedPosition), doorSpeed * Time.deltaTime);
                // Sprawdzamy, czy drzwi osiągnęły pozycję zamknięcia
                if (transform.position.z <= closedPosition && distance > 0 || transform.position.z >= closedPosition && distance < 0)
                {
                    isOpening = false;
                    isClosed = true;
                }
            }
            // Jeśli gracz nie jest w zasięgu drzwi i wyszedł z zasięgu przed zakończeniem otwierania, zamykamy drzwi
            if (!isPlayer)
            {
                CloseDoor();
            }

        }
    }

    public void OpenDoor()
    {
        if (isClosed) // Otwieramy tylko, jeśli drzwi są zamknięte
        {
            isOpening = true;
        }
    }

    public void CloseDoor()
    {
        if (!isClosed) // Zamykamy tylko, jeśli drzwi są otwarte
        {
            isOpening = true;
        }
    }
    // Ustawienie, czy gracz jest w zasięgu drzwi
    public void SetPlayer(bool player)
    {
        isPlayer = player;
    }
}