using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Sprawdzenie, czy obiekt, z kt�rym zderzy� si� gracz, ma tag "przeszkoda"
        if (hit.gameObject.CompareTag("przeszkoda"))
        {
            // Wy�wietlanie komunikatu z nazw� obiektu, z kt�rym dosz�o do kolizji
            Debug.Log("Player zderzy� si� z przeszkod�: " + hit.gameObject.name);
        }
    }
}