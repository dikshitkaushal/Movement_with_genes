using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class Brain : MonoBehaviour
{
    public int dnalength = 1;
    public float timealive ;
    public DNA dna;

    ThirdPersonCharacter m_thirdpersoncharacter;
    Vector3 m_move;
    bool jump;
    bool alive = true;

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
        dna = new DNA(dnalength, 6);
        timealive = 0;
        alive = true;
    }
    private void FixedUpdate()
    {
        //read DNA
        float v = 0;
        float h = 0;
        bool crouch = false;
        if (dna.getgene(0) == 0) v = 1;
        else if (dna.getgene(0) == 1) v = -1;
        else if (dna.getgene(0) == 2) h = 1;
        else if (dna.getgene(0) == 3) h = -1;
        else if (dna.getgene(0) == 4) jump = true;
        else if (dna.getgene(0) == 5) crouch = true;

        m_move = v * Vector3.forward + h * Vector3.right;
        m_thirdpersoncharacter.Move(m_move, crouch, jump);
        jump = false;
        if(alive)
        {
            timealive += Time.deltaTime;
        }
    }
}
