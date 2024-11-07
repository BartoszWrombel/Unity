using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Sprawdzenie, czy obiekt, z którym zderzy³ siê gracz, ma tag "przeszkoda"
        if (hit.gameObject.CompareTag("przeszkoda"))
        {
            // Wyœwietlanie komunikatu z nazw¹ obiektu, z którym dosz³o do kolizji
            Debug.Log("Player zderzy³ siê z przeszkod¹: " + hit.gameObject.name);
        }
    }
}