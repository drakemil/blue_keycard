using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolAnimation : MonoBehaviour
{

    private int activetool=0;
    private int nexttool=0;
    private bool swingtool=false;
    private bool changetool=false;
    private Vector3 toolvector1;
    private Vector3 origpos;
    private Vector3 finpos;
    private bool godown=true;
    public float switchspeed=500f;
    public Texture weapon2;
    private RawImage toolskin;
    // Start is called before the first frame update
    void Start()
    {
      toolvector1 = new Vector3(0f,-1f,0f);
      origpos = new Vector3(535f,86f,0f); //transform.position; //new Vector3(200f,-65f,0f);
      finpos = new Vector3(200f,-120f,0f);
    }

    // Update is called once per frame
    void Update()
    {
      //update from shared script
      activetool = PlayerToolManage.activetool;
      nexttool = PlayerToolManage.nexttool;
      swingtool = PlayerToolManage.swingtool;
      changetool = PlayerToolManage.changetool;

      if (changetool){
        //Do thing
        if (godown){
          transform.position += toolvector1*Time.deltaTime*switchspeed;
        }else{
          transform.position -= toolvector1*Time.deltaTime*switchspeed;
        }
        //Check thing
        if (transform.position.y < finpos.y){
          //at bottom
          godown = false;
          //change image
          toolskin = gameObject.GetComponent<RawImage>();
          toolskin.texture = weapon2;
          //update origpos from database

        }else if( (godown==false) && transform.position.y > origpos.y){
          transform.position = origpos; //nuance changing to "new tool"
          godown = true;
          PlayerToolManage.changetool = false;
          PlayerToolManage.activetool=nexttool;
        }
      }

      //update other script
    }
}
