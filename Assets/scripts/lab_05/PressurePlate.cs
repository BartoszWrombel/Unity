using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UIElements;

public class PressurePlate : MonoBehaviour
{
    public float force = 3f; // si³a nacisku
    // Ustawienie wysokoœci skoku w edytorze zmieniaj¹c tutaj jedynie oddzielnie
    //public float jump = 10f; // wysokoœæ skoku

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na p³ytkê naciskow¹.");
            MoveWithCharacterControllerLab5 CharacterController = other.GetComponent<MoveWithCharacterControllerLab5>();

            // Sprawdzenie, czy obiekt posiada komponent MoveWithCharacterControllerLab5
            if (CharacterController != null)
            {
                // Przypisanie wartoœci skoku z klasy MoveWithCharacterControllerLab5
                float jump = CharacterController.jumpHeight;
                float launchForce = jump * force;
                CharacterController.LaunchPlayer(launchForce);
            }
        }
    }
}
