using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab04_zad4 : MonoBehaviour
{
    // ruch wok� osi Y b�dzie wykonywany na obiekcie gracza, wi�c
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    // Zmienna do przechowywania obecnego k�ta obrotu kamery w osi X
    private float cameraRotation = 0f;

    void Start()
    {
        // zablokowanie kursora na �rodku ekranu, oraz ukrycie kursora
        // aby w UnityEditor ponownie pojawi� si� kursor (w�a�ciwie deaktywowac kursor w trybie play)
        // wciskamy klawisz ESC
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy warto�ci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * Time.deltaTime * 100f;
        float mouseYMove = Input.GetAxis("Mouse Y") * Time.deltaTime * 100f;

        // wykonujemy rotacj� wok� osi Y
        player.Rotate(Vector3.up * mouseXMove);

        cameraRotation -= mouseYMove;
        cameraRotation = Mathf.Clamp(cameraRotation, -90f, 90f);

        transform.Rotate(new Vector3(mouseYMove, 0f, 0f), Space.Self);
    }
}