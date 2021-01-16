using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallInteract : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void runInteraction()
    {
      //CallInteract.runInteraction()
      switch (gameObject.tag)
      {
        case "Door":
          gameObject.GetComponent<interact_door>().oclose();
          break;
        default:
          print("default, baby!!");
          break;
      }
    }
}
