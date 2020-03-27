using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private List<Cube> cubeList = new List<Cube>(11);


    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void MoveCubesDown()
    {

    }

    public void FallCheck()
    {
        if (cubeList.Count == 3)
        {
            int i = 0;
            while (i < 3)
            {
                Destroy(cubeList[i].gameObject);
                i++;
            }
            cubeList.Clear();

            //for (int i = 1; i < 11; i++)
            //{
            //    Destroy(cubeList[i].gameObject);
            //}
            //cubeList.Clear();

            Game.single.LowerCubesAbove(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("Cube"))
        {
            cubeList.Add(other.GetComponent<Cube>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.StartsWith("Cube"))
        {
            cubeList.Remove(other.GetComponent<Cube>());
        }
    }

    /*
   public void FillLine(Cube c)
   {
       line.Add(c);
       Debug.Log(line.Count);
       if (line.Count == 11)
       {
           for(int i = 10; i >= 0; i--)
           {
               Destroy(line[i].gameObject);
           }
       }
   }
   */

}
