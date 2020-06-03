using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA 
{
    List<int> genes = new List<int>();
    int dnalength = 0;
    int maxvalues = 0;

    public DNA(int l, int v)
    {
        dnalength = l;
        maxvalues = v;
        setrandom();
    }

    public void setrandom()
    {
        for (int i = 0; i < dnalength; i++)
        {
            genes.Add(UnityEngine.Random.Range(0, maxvalues));
        }
    }

    public void SetInt(int pos, int value)
    {
        genes[pos] = value;
    }

    public void combine(DNA d1, DNA d2)
    {
        for (int i = 0; i < dnalength; i++)
        {
            if (i < dnalength / 2)
            {
                /*genes[i] = d1.genes[i];*/
                int c= d1.genes[i];
                genes[i] = c;
            }
            else
            {
                /*genes[i] = d2.genes[i];*/
                int c = d2.genes[i];
                genes[i] = c;
            }
        }
    }
    
    public void Mutate()
    {
        genes[UnityEngine.Random.Range(0, dnalength)] = UnityEngine.Random.Range(0, maxvalues);
    }

    public int getgene(int pos)
    {
        return genes[pos];
    }
 }