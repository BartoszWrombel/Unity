using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab04_zad4 : MonoBehaviour
{
    // ruch wokó³ osi Y bêdzie wykonywany na obiekcie gracza, wiêc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    // Zmienna do przechowywania obecnego k¹ta obrotu kamery w osi X
    private float cameraRotation = 0f;

    void Start()
    {
        // zablokowanie kursora na œrodku ekranu, oraz ukrycie kursora
        // aby w UnityEditor ponownie pojawi³ siê kursor (w³aœciwie deaktywowac kursor w trybie play)
        // wciskamy klawisz ESC
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartoœci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * Time.deltaTime * 100f;
        float mouseYMove = Input.GetAxis("Mouse Y") * Time.deltaTime * 100f;

        // wykonujemy rotacjê wokó³ osi Y
        player.Rotate(Vector3.up * mouseXMove);

        cameraRotation -= mouseYMove;
        cameraRotation = Mathf.Clamp(cameraRotation, -90f, 90f);

        transform.Rotate(new Vector3(mouseYMove, 0f, 0f), Space.Self);
    }
}