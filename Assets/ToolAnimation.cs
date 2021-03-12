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
	private Vector3 Z;
	public Vector3 rotcenter;
	public float rotangle = 500f;
    private bool godown=true;
    public float switchspeed=500f;
	public Texture weapon1;
    public Texture weapon2;
    private RawImage toolskin;
	private bool swingfwd=true;
	private int count=0;
	private float accumulator =0f;
	public int maxcount;
    // Start is called before the first frame update
    void Start()
    {
      toolvector1 = new Vector3(0f,-1f,0f);
      origpos = new Vector3(577f,87f,0f); //transform.position; //new Vector3(200f,-65f,0f);
      finpos = new Vector3(200f,-120f,0f);
	  Z = new Vector3(0f,0f,1f);
    }

    // Update is called once per frame
    void Update()
    {
	
      //update from shared script
      activetool = PlayerToolManage.activetool;
      nexttool = PlayerToolManage.nexttool;
      swingtool = PlayerToolManage.swingtool;
      changetool = PlayerToolManage.changetool;

	  if (swingtool) {
		//print("swingies");
		  
		if (swingfwd) {
			//print("swongies >:(");
			transform.RotateAround(origpos+rotcenter,Z,rotangle*Time.deltaTime);
			//transform.position += toolvector1*Time.deltaTime*switchspeed;
			accumulator += rotangle*Time.deltaTime;
			count += 1;
			if (count==maxcount) {
				swingfwd=false;
				//print(accumulator);
			}
			
		} else {
			
			transform.RotateAround(origpos+rotcenter,Z,-rotangle*Time.deltaTime);
			accumulator -= rotangle*Time.deltaTime;
			//count -= 1;
			if (accumulator <= 0) {
				swingfwd=true;
				swingtool=false;
				PlayerToolManage.swingtool = false;
				transform.position = origpos;
				transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				//print(accumulator);
				count=0;
				accumulator=0;
			}
			
		}
		  
	  }

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
		  
		  switch(nexttool) {
			  
			  case 1:
				toolskin.texture = weapon1;
				break;
			
			  case 2:
				toolskin.texture = weapon2;
				break;
			  
		  }
		  
          //toolskin.texture = weapon2;
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
