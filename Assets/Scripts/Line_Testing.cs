using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Testing : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Line_Controller line;
    // Start is called before the first frame update
    void Start()
    {
        line.SetUpLine(points);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
