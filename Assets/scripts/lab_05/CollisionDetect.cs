using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Sprawdzenie, czy obiekt, z którym zderzył się gracz, ma tag "przeszkoda"
        if (hit.gameObject.CompareTag("przeszkoda"))
        {
            // Wyświetlanie komunikatu z nazwą obiektu, z którym doszło do kolizji
            Debug.Log("Player zderzył się z przeszkodą: " + hit.gameObject.name);
        }
    }
}