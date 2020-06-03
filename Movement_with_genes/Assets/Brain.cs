using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Brain : MonoBehaviour
{
    public int dnalength = 1;
    public float timealive ;
    public DNA dna;

    person_controller controller;
    Vector3 m_move;
    bool jump;
    public bool alive = true;

    private void Start()
    {
        controller = GetComponent<person_controller>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="dead")
        {
            alive = false;
        }
    }
    public void init()
    {
        //initialize DNA
        //0 forward
        //1 backward
        //2 left
        //3 right
        //4 jump
        //5 crouch
        dna = new DNA(dnalength, 5);
        timealive = 0;
        alive = true;
    }
    private void FixedUpdate()
    {
        //read DNA
        if (dna.getgene(0) == 0) controller.moveforward();
        else if (dna.getgene(0) == 1) controller.movebackward();
        else if (dna.getgene(0) == 2) controller.moveleft();
        else if (dna.getgene(0) == 3) controller.moveright();
        else if (dna.getgene(0) == 4) controller.dance();
        
        if(alive)
        {
            timealive += Time.deltaTime;
        }
    }
}
