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
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // przesuniêcie platformy w kierunku pozycji docelowej

        // Jeœli osi¹gniemy punkt docelowy
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Przesuwamy do nastêpnego punktu lub zawracamy, jeœli dotarliœmy do koñca
            if (direction) // jeœli kierunek jest zgodny z list¹
            {
                if (currentTarget < postions.Count - 1) // jeœli nie jesteœmy na koñcu listy
                {
                    currentTarget++;
                }
                else // jeœli jesteœmy na koñcu listy
                {
                    direction = false;
                    currentTarget--;
                }
            }
            else // jeœli kierunek jest przeciwny do listy
            {
                if (currentTarget > 0) // jeœli nie jesteœmy na pocz¹tku listy
                {
                    currentTarget--;
                }
                else // jeœli jesteœmy na pocz¹tku listy
                {
                    direction = true;
                    currentTarget++;
                }
            }
        }
    }
}
