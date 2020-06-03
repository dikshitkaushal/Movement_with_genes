using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopulationManager : MonoBehaviour
{
    public GameObject botprefab;
    public int population_size = 50;
    List<GameObject> population = new List<GameObject>();
    public static float elapsed = 0;
    public float trialtime = 5;
    int generation = 1;

    GUIStyle guiStyle = new GUIStyle();

    private void OnGUI()
    {
        guiStyle.fontSize = 25;
        guiStyle.normal.textColor = Color.white;
        GUI.BeginGroup(new Rect(10, 10, 250, 150));
        GUI.Box(new Rect(0, 0, 140, 140),"Stats : ",guiStyle);
        GUI.Label(new Rect(10, 25, 200, 30), "Gen : " + generation, guiStyle);
        GUI.Label(new Rect(10, 50, 200, 30), string.Format("Time : {0:0:00}", elapsed), guiStyle);
        GUI.Label(new Rect(10, 75, 200, 30), "Population : " + population.Count, guiStyle);
        GUI.EndGroup();
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<population_size;i++)
        {
            Vector3 startingpos = new Vector3(this.transform.position.x + UnityEngine.Random.Range(-2, 2), this.transform.position.y, this.transform.position.z + UnityEngine.Random.Range(-2, 2));
            GameObject b = Instantiate(botprefab, startingpos, this.transform.rotation);
            b.GetComponent<Brain>().init();
            population.Add(b);
        }
    }

    GameObject breed(GameObject parent1,GameObject parent2)
    {
        Vector3 startingpos = new Vector3(this.transform.position.x + UnityEngine.Random.Range(-2, 2), this.transform.position.y, this.transform.position.z + UnityEngine.Random.Range(-2, 2));
        DNA dna1 = parent1.GetComponent<Brain>().dna;
        DNA dna2 = parent2.GetComponent<Brain>().dna;
        GameObject offspring = Instantiate(botprefab, startingpos, this.transform.rotation);
        Brain b = offspring.GetComponent<Brain>();
        if(Random.Range(0,100)==1)
        {
            b.init();
            b.dna.Mutate();
        }
        else
        {
            b.init();
            b.dna.combine(dna1, dna2);
        }
        return offspring;
    }
    void BreedNewPopulation()
    {
        List<GameObject> sortedlist = population.OrderBy(o => o.GetComponent<Brain>().timealive).ToList();
        population.Clear();
        for(int i=(int)(sortedlist.Count/2.0f)-1;i<sortedlist.Count-1;i++)
        {
            population.Add(breed(sortedlist[i], sortedlist[i + 1]));
            population.Add(breed(sortedlist[i + 1], sortedlist[i]));
        }
        //destroy all parents
        for(int i=0;i<sortedlist.Count;i++)
        {
            Destroy(sortedlist[i]);
        }
        generation++;
    }
    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if(elapsed>trialtime)
        {
            elapsed = 0;
            BreedNewPopulation();
        }
    }
}
