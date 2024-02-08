using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resourcemanager : MonoBehaviour
{
    public int wood;
    public int stone;
    public int steel;
    public int coins;
    void Start()
    {
        
    }
    void Update()
    {
        wood += 1;
        stone += 1;
        steel += 1;
        coins += 1;
    }
}
