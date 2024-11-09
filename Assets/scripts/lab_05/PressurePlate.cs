using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UIElements;

public class PressurePlate : MonoBehaviour
{
    public float force = 3f; // siła nacisku
    // Ustawienie wysokości skoku w edytorze zmieniając tutaj jedynie oddzielnie
    //public float jump = 10f; // wysokość skoku

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na płytkę naciskową.");
            MoveWithCharacterControllerLab5 CharacterController = other.GetComponent<MoveWithCharacterControllerLab5>();

            // Sprawdzenie, czy obiekt posiada komponent MoveWithCharacterControllerLab5
            if (CharacterController != null)
            {
                // Przypisanie wartości skoku z klasy MoveWithCharacterControllerLab5
                float jump = CharacterController.jumpHeight;
                float launchForce = jump * force;
                CharacterController.LaunchPlayer(launchForce);
            }
        }
    }
}
