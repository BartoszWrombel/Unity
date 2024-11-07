using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UIElements;

public class PressurePlate : MonoBehaviour
{
    public float force = 3f; // si�a nacisku
    // Ustawienie wysoko�ci skoku w edytorze zmieniaj�c tutaj jedynie oddzielnie
    //public float jump = 10f; // wysoko�� skoku

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed� na p�ytk� naciskow�.");
            MoveWithCharacterControllerLab5 CharacterController = other.GetComponent<MoveWithCharacterControllerLab5>();

            // Sprawdzenie, czy obiekt posiada komponent MoveWithCharacterControllerLab5
            if (CharacterController != null)
            {
                // Przypisanie warto�ci skoku z klasy MoveWithCharacterControllerLab5
                float jump = CharacterController.jumpHeight;
                float launchForce = jump * force;
                CharacterController.LaunchPlayer(launchForce);
            }
        }
    }
}
