using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lab04_zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int number = 1;
    int objectCounter = 0;
    Collider m_Collider;
    float x_min, x_max, z_min, z_max;
    // obiekt do generowania
    public GameObject block;
    public Material[] materials;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        x_min = m_Collider.bounds.min.x;
        x_max = m_Collider.bounds.max.x;
        z_min = m_Collider.bounds.min.z;
        z_max = m_Collider.bounds.max.z;
        // w momecie uruchomienia generuje n kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)x_min, (int)x_max).OrderBy(x => Guid.NewGuid()).Take(number));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)z_min, (int)z_max).OrderBy(x => Guid.NewGuid()).Take(number));

        for (int i = 0; i < number; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 0.5f, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);

            if (materials.Length > 0)
            {
                Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
                newBlock.GetComponent<Renderer>().material = randomMaterial; // Przypisanie materia³u do kostki
            }

            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
