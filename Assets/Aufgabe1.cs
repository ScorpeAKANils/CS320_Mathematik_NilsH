using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Aufgaben
{
    einsA,
    einsB,
    einsC,
    zweiA,
    zweiB,
    zweiC,
}
[ExecuteAlways]
public class Aufgabe1 : MonoBehaviour
{
    public float frequenz;
    public float WaveHeight;
    public float speed = 1; 
    private void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y+AufgabeEinsA()*speed*Time.deltaTime, transform.position.z); 
    }
    public float AufgabeEinsA()
    {
        return Mathf.Sin(transform.position.x +frequenz)*WaveHeight; 
    }
}
