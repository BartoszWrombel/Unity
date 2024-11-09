using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    public List<Vector3> postions;
    public float speed = 2f;
    private int currentTarget = 0;
    private bool direction = true;

    void Start()
    {
        if (postions.Count == 0)
        {
            Debug.LogError("Brak punktów docelowych");
        }

    }

    void Update()
    {
        Vector3 targetPosition = postions[currentTarget]; // pobranie pozycji docelowej z listy
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // przesunięcie platformy w kierunku pozycji docelowej

        // Jeśli osiągniemy punkt docelowy
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Przesuwamy do następnego punktu lub zawracamy, jeśli dotarliśmy do końca
            if (direction) // jeśli kierunek jest zgodny z listą
            {
                if (currentTarget < postions.Count - 1) // jeśli nie jesteśmy na końcu listy
                {
                    currentTarget++;
                }
                else // jeśli jesteśmy na końcu listy
                {
                    direction = false;
                    currentTarget--;
                }
            }
            else // jeśli kierunek jest przeciwny do listy
            {
                if (currentTarget > 0) // jeśli nie jesteśmy na początku listy
                {
                    currentTarget--;
                }
                else // jeśli jesteśmy na początku listy
                {
                    direction = true;
                    currentTarget++;
                }
            }
        }
    }
}
