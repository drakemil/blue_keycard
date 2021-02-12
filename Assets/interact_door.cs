using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact_door : MonoBehaviour
{
    public int openstate;
    private Vector3 moveVector;
    public float doorspeed;
    private float yinit;
    private double ht;
    private float htc;
    private float ymax;
    //0 = closed, 1 is opening, 2 is open, 3 is closing
    // Start is called before the first frame update
    void Start()
    {
      openstate = 0;
      yinit = transform.position.y;
      ht = GetComponent<Collider>().bounds.size[0];
      htc = (float) ht;
      print(htc);
      ymax = yinit + 10f*htc;
    }

    // Update is called once per frame
    void Update()
    {
      switch(openstate)
      { //test how to move
        case(1): //opening
            moveVector = new Vector3(0f,1f,0f);
            break;
        case(3): //closing
            moveVector = new Vector3(0f,-1f,0f);
            break;
        case (0): // closed
            moveVector = new Vector3(0f,0f,0f);
            break;
        case (2): //open
            moveVector = new Vector3(0f,0f,0f);
            break;
      }
      //print(moveVector);
      transform.position += moveVector*Time.deltaTime*doorspeed; //move

      //check open/close
      if (transform.position.y >= ymax)
      {
        transform.position = new Vector3 (transform.position.x, ymax, transform.position.z);
        openstate = 2;
      }
      else if (transform.position.y <= yinit)
      {
        transform.position = new Vector3 (transform.position.x, yinit, transform.position.z);
        openstate = 0;
      }
    }

    public void oclose()
    {
      switch(openstate)
      {
        case (1):
          openstate = 3;
          break;
        case (2):
          openstate = 3;
          break;
        case (0):
          openstate = 1;
          break;
        case (3):
          openstate = 1;
          break;
      }
    }

}
