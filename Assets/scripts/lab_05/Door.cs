using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float doorSpeed = 2f; // prêdkoœæ otwierania drzwi
    public float distance = 3.0f; // odleg³oœæ otwierania drzwi
    // dla lewych drzwi trzeba ustawiæ w edytorze wartoœæ ujemn¹
    private bool isOpening = false; // czy drzwi siê otwieraj¹
    private bool isClosed = true; // czy drzwi s¹ zamkniête
    private bool isPlayer = false; // czy gracz jest w zasiêgu drzwi
    private float closedPosition; // pozycja zamkniêtych drzwi
    private float openPosition; // pozycja otwartych drzwi

    void Start()
    {
        // Ustawienie pozycji startowej i koñcowej drzwi
        closedPosition = transform.position.z;
        openPosition = transform.position.z + distance;
    }

    void Update()
    {
        // Sprawdzamy, czy drzwi s¹ w trakcie otwierania
        if (isOpening)
        {
            // Sprawdzamy, czy drzwi s¹ zamkniête, jeœli tak, to otwieramy je
            if (isClosed)
            {
                // Wykonujemy ruch drzwi w kierunku otwarcia
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, openPosition), doorSpeed * Time.deltaTime);
                // Sprawdzamy, czy drzwi osi¹gnê³y pozycjê otwarcia
                if (transform.position.z >= openPosition && distance > 0 || transform.position.z <= openPosition && distance < 0)
                {
                    isOpening = false;
                    isClosed = false;
                }
            }
            // Jeœli drzwi s¹ otwarte, zamykamy je
            else
            {
                // Wykonujemy ruch drzwi w kierunku zamkniêcia
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, closedPosition), doorSpeed * Time.deltaTime);
                // Sprawdzamy, czy drzwi osi¹gnê³y pozycjê zamkniêcia
                if (transform.position.z <= closedPosition && distance > 0 || transform.position.z >= closedPosition && distance < 0)
                {
                    isOpening = false;
                    isClosed = true;
                }
            }
            // Jeœli gracz nie jest w zasiêgu drzwi i wyszed³ z zasiêgu przed zakoñczeniem otwierania, zamykamy drzwi
            if (!isPlayer)
            {
                CloseDoor();
            }

        }
    }

    public void OpenDoor()
    {
        if (isClosed) // Otwieramy tylko, jeœli drzwi s¹ zamkniête
        {
            isOpening = true;
        }
    }

    public void CloseDoor()
    {
        if (!isClosed) // Zamykamy tylko, jeœli drzwi s¹ otwarte
        {
            isOpening = true;
        }
    }
    // Ustawienie, czy gracz jest w zasiêgu drzwi
    public void SetPlayer(bool player)
    {
        isPlayer = player;
    }
}