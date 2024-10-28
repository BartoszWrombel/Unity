using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab04_zad4 : MonoBehaviour
{
    // ruch wokó³ osi Y bêdzie wykonywany na obiekcie gracza, wiêc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;

    private float restriction = 0f;

    void Start()
    {
        // zablokowanie kursora na œrodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartoœci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // wykonujemy rotacjê wokó³ osi Y
        player.Rotate(Vector3.up * mouseXMove);

        // Obrót kamery w osi X (góra-dó³), z ograniczeniem k¹ta
        restriction -= mouseYMove; // -mouseYMove, aby unikn¹æ efektu odwrócenia
        restriction = Mathf.Clamp(restriction, -90f, 90f); // Ograniczenie k¹ta miêdzy -90 a +90

        // Ograniczenie k¹ta obrotu kamery
        transform.localRotation = Quaternion.Euler(restriction, 0f, 0f);

    }
}