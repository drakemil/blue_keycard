using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolManage : MonoBehaviour
{
    public static int activetool=1;
    public static int nexttool=1;
    public static bool swingtool=false;
    public static bool changetool=false;
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){
      // Take nexttool input
      if (Input.GetKeyDown("1")){
        nexttool=1;
      }else if (Input.GetKeyDown("2")){
        nexttool=2;
      }
      
      //Check nextool
      if (!(changetool)){
        if (nexttool==activetool){
          //they ARE the same tool...
            if(!(swingtool)){
              if (Input.GetButton("Fire1")) {
				  //print("grifin firing");
				  swingtool=true;
			  }
            }
        }else{
          //they ARE NOT the same tool...
          if(!(swingtool)){
            changetool = true;
            //other script changes #
          }
        }
      }
    }
}
