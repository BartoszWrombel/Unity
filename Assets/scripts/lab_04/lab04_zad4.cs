using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab04_zad4 : MonoBehaviour
{
    // ruch wok� osi Y b�dzie wykonywany na obiekcie gracza, wi�c
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;

    private float restriction = 0f;

    void Start()
    {
        // zablokowanie kursora na �rodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy warto�ci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // wykonujemy rotacj� wok� osi Y
        player.Rotate(Vector3.up * mouseXMove);

        // Obr�t kamery w osi X (g�ra-d�), z ograniczeniem k�ta
        restriction -= mouseYMove; // -mouseYMove, aby unikn�� efektu odwr�cenia
        restriction = Mathf.Clamp(restriction, -90f, 90f); // Ograniczenie k�ta mi�dzy -90 a +90

        // Ograniczenie k�ta obrotu kamery
        transform.localRotation = Quaternion.Euler(restriction, 0f, 0f);

    }
}