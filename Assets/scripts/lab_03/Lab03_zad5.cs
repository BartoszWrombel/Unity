using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab03_zad5 : MonoBehaviour
{
    public GameObject block; // Prefabrykat kostki
    private HashSet<Vector3> busy = new HashSet<Vector3>(); // Zajęte pozycje

    void Start()
    {
        GenerateCubes(10); // Generujemy 10 kostek
    }

    void GenerateCubes(int number) 
    {
        for (int i = 0; i < number; i++) // Pętla generująca kostki
        {
            Vector3 random; 

            do
            {
                // Generujemy losowe pozycje w obrębie płaszczyzny 10x10
                int x = UnityEngine.Random.Range(-5, 5); // Losowy X
                int z = UnityEngine.Random.Range(-5, 5); // Losowy Z
                random = new Vector3(x, 0.5f, z); // Tworzymy Vector3 z X, Y i Z
            } while (busy.Contains(random)); // Sprawdzamy, czy pozycja jest już zajęta

            busy.Add(random); // Dodajemy pozycję do zajętych

            Instantiate(block, random, Quaternion.identity); // Tworzymy kostkę na danej pozycji
        }
    }
}
