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
            Debug.LogError("Brak punkt�w docelowych");
        }

    }

    void Update()
    {
        Vector3 targetPosition = postions[currentTarget]; // pobranie pozycji docelowej z listy
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // przesuni�cie platformy w kierunku pozycji docelowej

        // Je�li osi�gniemy punkt docelowy
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Przesuwamy do nast�pnego punktu lub zawracamy, je�li dotarli�my do ko�ca
            if (direction) // je�li kierunek jest zgodny z list�
            {
                if (currentTarget < postions.Count - 1) // je�li nie jeste�my na ko�cu listy
                {
                    currentTarget++;
                }
                else // je�li jeste�my na ko�cu listy
                {
                    direction = false;
                    currentTarget--;
                }
            }
            else // je�li kierunek jest przeciwny do listy
            {
                if (currentTarget > 0) // je�li nie jeste�my na pocz�tku listy
                {
                    currentTarget--;
                }
                else // je�li jeste�my na pocz�tku listy
                {
                    direction = true;
                    currentTarget++;
                }
            }
        }
    }
}
