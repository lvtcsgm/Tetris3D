using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject cubePrefab;
    public List<Row> rows = new List<Row>(10);
    public static Game single;

    void Awake()
    {
        single = this;
    }

    public GameObject CreateCube()
    {
        return Instantiate(cubePrefab, new Vector3(0f, 5f, 0f), Quaternion.identity);
    }

    public void LowerCubesAbove(Row row)
    {
        int i = 0;
        while (i < 10)
        {
            if (true)
            {
                rows[i].MoveCubesDown();
            }
            i++;
        }
    }
}
