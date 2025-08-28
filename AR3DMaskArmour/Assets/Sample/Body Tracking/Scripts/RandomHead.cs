using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RandomHead : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<GameObject> heads =new List<GameObject>();
        foreach (Transform child in transform)
        {
                heads.Add(child.gameObject);
        }
        int randomIndex = Random.Range(0, heads.Count);
        for (int i = 0; i < heads.Count; i++)
        {
            if (i == randomIndex)
            {
                heads[i].SetActive(true);
            }
            else
            {
                heads[i].SetActive(false);
            }
        }
    }
}
