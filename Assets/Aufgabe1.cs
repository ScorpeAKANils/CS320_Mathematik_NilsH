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

public class Aufgabe1 : MonoBehaviour
{
    public float frequenz;
    public float WaveHeight;
    public float speed = 1;
    public Aufgaben curAuf = Aufgaben.einsA;
    [Range(0, 1)]
    public float slopeSpeedFactor = 1;

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
            case Aufgaben.einsC:
                AufgabeEinsC();
                break;
            case Aufgaben.zweiA:
                AufgabeZweiA();
                break;
            case Aufgaben.zweiB:
                AufgabeZweiB();
                break;
            case Aufgaben.zweiC:
                AufgabeZweiC();
                break;
        }
    }

    public void AufgabeEinsA()
    {
        float newYPos = Mathf.Sin((transform.position.x + Time.time * speed) * frequenz) * WaveHeight;
        transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);
    }

    public void AufgabeEinsB()
    {
        float newYPos = Mathf.Sin((transform.position.x + Time.time * speed) * frequenz) * WaveHeight;
        float yAbleitung = Mathf.Cos((transform.position.x + Time.time * speed) * frequenz) * frequenz * WaveHeight;
        float newY = newYPos - (yAbleitung * slopeSpeedFactor * Time.deltaTime);
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, newY, transform.position.z);
    }

    public void AufgabeEinsC()
    {
        float newYPos = Mathf.Sin((transform.position.x + Time.time * speed) * frequenz) * WaveHeight;
        float yAbleitung = Mathf.Cos((transform.position.x + Time.time * speed) * frequenz) * frequenz * WaveHeight;
        float neigung = Mathf.Atan(yAbleitung) * Mathf.Rad2Deg;
        float newY = newYPos - (yAbleitung * slopeSpeedFactor * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, neigung);
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, newY, transform.position.z);
    }

    public void AufgabeZweiA()
    {
        float newYPos = Mathf.Cos(transform.position.x + Time.time * speed) * (0.25f * transform.position.x) + Mathf.Sin(transform.position.z + Time.time * speed) * WaveHeight;
        transform.position = new Vector3(transform.position.x, newYPos, transform.position.z + speed * Time.deltaTime);
    }

    public void AufgabeZweiB()
    {
        float newYPos = Mathf.Cos(transform.position.x + Time.time * speed) * (0.25f * transform.position.x) + Mathf.Sin(transform.position.z + Time.time * speed) * WaveHeight;
        float yAbleitungX = -Mathf.Sin(transform.position.x + Time.time * speed) * (0.25f * transform.position.x) * WaveHeight;
        float yAbleitungZ = Mathf.Cos(transform.position.z + Time.time * speed) * WaveHeight;
        float newY = newYPos - (yAbleitungX * slopeSpeedFactor * Time.deltaTime) - (yAbleitungZ * slopeSpeedFactor * Time.deltaTime);
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, newY, transform.position.z + speed * Time.deltaTime);
    }

    public void AufgabeZweiC()
    {
        float newYPos = Mathf.Cos(transform.position.x + Time.time * speed) * (0.25f * transform.position.x) + Mathf.Sin(transform.position.z + Time.time * speed) * WaveHeight;
        float yAbleitungX = -Mathf.Sin(transform.position.x + Time.time * speed) * (0.25f * transform.position.x) * WaveHeight;
        float yAbleitungZ = Mathf.Cos(transform.position.z + Time.time * speed) * WaveHeight;
        float neigungX = Mathf.Atan(yAbleitungX) * Mathf.Rad2Deg;
        float neigungZ = Mathf.Atan(yAbleitungZ) * Mathf.Rad2Deg;
        float newY = newYPos - (yAbleitungX * slopeSpeedFactor * Time.deltaTime) - (yAbleitungZ * slopeSpeedFactor * Time.deltaTime);
        transform.rotation = Quaternion.Euler(neigungZ, 0, neigungX);
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, newY, transform.position.z + speed * Time.deltaTime);
    }
}
