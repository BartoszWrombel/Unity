using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float doorSpeed = 2f; // pr�dko�� otwierania drzwi
    public float distance = 3.0f; // odleg�o�� otwierania drzwi
    // dla lewych drzwi trzeba ustawi� w edytorze warto�� ujemn�
    private bool isOpening = false; // czy drzwi si� otwieraj�
    private bool isClosed = true; // czy drzwi s� zamkni�te
    private bool isPlayer = false; // czy gracz jest w zasi�gu drzwi
    private float closedPosition; // pozycja zamkni�tych drzwi
    private float openPosition; // pozycja otwartych drzwi

    void Start()
    {
        // Ustawienie pozycji startowej i ko�cowej drzwi
        closedPosition = transform.position.z;
        openPosition = transform.position.z + distance;
    }

    void Update()
    {
        // Sprawdzamy, czy drzwi s� w trakcie otwierania
        if (isOpening)
        {
            // Sprawdzamy, czy drzwi s� zamkni�te, je�li tak, to otwieramy je
            if (isClosed)
            {
                // Wykonujemy ruch drzwi w kierunku otwarcia
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, openPosition), doorSpeed * Time.deltaTime);
                // Sprawdzamy, czy drzwi osi�gn�y pozycj� otwarcia
                if (transform.position.z >= openPosition && distance > 0 || transform.position.z <= openPosition && distance < 0)
                {
                    isOpening = false;
                    isClosed = false;
                }
            }
            // Je�li drzwi s� otwarte, zamykamy je
            else
            {
                // Wykonujemy ruch drzwi w kierunku zamkni�cia
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, closedPosition), doorSpeed * Time.deltaTime);
                // Sprawdzamy, czy drzwi osi�gn�y pozycj� zamkni�cia
                if (transform.position.z <= closedPosition && distance > 0 || transform.position.z >= closedPosition && distance < 0)
                {
                    isOpening = false;
                    isClosed = true;
                }
            }
            // Je�li gracz nie jest w zasi�gu drzwi i wyszed� z zasi�gu przed zako�czeniem otwierania, zamykamy drzwi
            if (!isPlayer)
            {
                CloseDoor();
            }

        }
    }

    public void OpenDoor()
    {
        if (isClosed) // Otwieramy tylko, je�li drzwi s� zamkni�te
        {
            isOpening = true;
        }
    }

    public void CloseDoor()
    {
        if (!isClosed) // Zamykamy tylko, je�li drzwi s� otwarte
        {
            isOpening = true;
        }
    }
    // Ustawienie, czy gracz jest w zasi�gu drzwi
    public void SetPlayer(bool player)
    {
        isPlayer = player;
    }
}