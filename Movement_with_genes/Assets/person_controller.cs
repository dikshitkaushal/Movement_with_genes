using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Rendering;

public class person_controller : MonoBehaviour
{
    CharacterController m_character;
    Animator m_animator;
    Vector3 move;
    public float Speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        m_character = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
    }

    public void moveforward()
    {
        if (m_animator)
        {
            move = Vector3.forward * Speed * Time.deltaTime;
            m_animator.SetTrigger("forward");
        }
    }
    public void movebackward()
    {
        if(m_animator)
        {
            move = Vector3.forward * (-1) * Speed * Time.deltaTime;
            m_animator.SetTrigger("backward");
        }
    }
    public void moveright()
    {
        if(m_animator)
        {
            move = Vector3.right * Speed * Time.deltaTime;
            m_animator.SetTrigger("right");
        }
    }
    public void moveleft()
    {
        if(m_animator)
        {
            move = Vector3.right * (-1) * Speed * Time.deltaTime;
            m_animator.SetTrigger("left");
        }
    }
    public void dance()
    {
        if(m_animator)
        {
            m_animator.SetTrigger("dance");
        }
    }
    // Update is called once per frame
    void Update()
    {
        m_character.Move(move);
    }
}
