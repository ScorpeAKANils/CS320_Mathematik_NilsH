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
    public Aufgaben curAuf = Aufgaben.einsA;
    [Range(0, 3)]
    public float slopeSpeedFactor=1;

    private void Update()
    {
        switch (curAuf)
        {
            case Aufgaben.einsA:
                AufgabeEinsA();
                break;
            case Aufgaben.einsB:
                AufgabeEinsB();
                break;

        }
    }
    public void AufgabeEinsA()
    {
        float newYPos =  Mathf.Sin(transform.position.x +frequenz)*WaveHeight;
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y + newYPos * speed * Time.deltaTime, transform.position.z);
    }

    public void AufgabeEinsB()
    {
        float newYPos = Mathf.Sin((transform.position.x + Time.time * speed) * frequenz) * WaveHeight;
        float yAbleitung = Mathf.Cos((transform.position.x + Time.time * speed) * frequenz) * frequenz * WaveHeight;
        float newXPos = transform.position.x + speed * Time.deltaTime;
        float newY = transform.position.y + newYPos - (yAbleitung * slopeSpeedFactor * Time.deltaTime);
        transform.position = new Vector3(newXPos, newY, transform.position.z);
    }
}
