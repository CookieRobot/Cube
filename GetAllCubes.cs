using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllCubes : MonoBehaviour {

    public Animator[] anim;
	// Use this for initialization
	void Start () {
        anim = GetComponentsInChildren<Animator>();
        for (int i = 0; i < anim.Length; i++)
        {



           
            anim[i].SetBool("AllClear", false);

           
        }
    }
	
	public void allFadeOut()
    {
        anim = GetComponentsInChildren<Animator>();
        for (int i = 0; i<anim.Length;i++)
        {

           

            //if (anim[i]!= null)
            //{
                anim[i].SetBool("AllClear", true);

           // }
        }


    }
}
