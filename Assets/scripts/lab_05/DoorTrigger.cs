using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public List<Door> doors; // lista drzwi, kt�re maj� by� otwarte/zamkni�te

    // Metoda wywo�ywana, gdy obiekt wejdzie w obszar wykrywania
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Otwieranie drzwi");
            foreach (Door door in doors)
            {
                door.SetPlayer(true);
                door.OpenDoor();
            }    
        }
    }

    // Metoda wywo�ywana, gdy obiekt opu�ci obszar wykrywania
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Zamykanie drzwi");
            foreach (Door door in doors)
            {
                door.SetPlayer(false);
                door.CloseDoor();
            }
        }
    }
}