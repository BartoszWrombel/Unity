using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab04_zad4 : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;

    private float restriction = 0f;

    void Start()
    {
        // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartości dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // wykonujemy rotację wokół osi Y
        player.Rotate(Vector3.up * mouseXMove);

        // Obrót kamery w osi X (góra-dół), z ograniczeniem kąta
        restriction -= mouseYMove; // -mouseYMove, aby uniknąć efektu odwrócenia
        restriction = Mathf.Clamp(restriction, -90f, 90f); // Ograniczenie kąta między -90 a +90

        // Ograniczenie kąta obrotu kamery
        transform.localRotation = Quaternion.Euler(restriction, 0f, 0f);

    }
}