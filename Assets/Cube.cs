using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool isFalling = true;
    public float speed = 0.5f;
    private int stoppedX, stoppedY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Tick");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && isFalling == true && transform.position.x >= -4)
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && isFalling == true && transform.position.x <= 4)
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            speed = .25f;
            if (isFalling == true)
            {
                StopCoroutine("Tick");
                StartCoroutine("Tick");
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            speed = 0.5f;
        }
    }

    IEnumerator Tick()
    {
        yield return new WaitForSeconds(speed);
        if (isFalling == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        }
        StartCoroutine("Tick");
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.name == "Floor" || other.name.StartsWith("Cube")) && isFalling == true)
        {
            isFalling = false;

            for (int index = 0; index < Game.single.rows.Count; index += 1)
            {
                Game.single.rows[index].FallCheck();
            }

            Game.single.CreateCube();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
