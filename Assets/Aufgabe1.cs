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
    [Range(0, 3)]
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
        }
    }

    // Aufgabe 1a
    public void AufgabeEinsA()
    {
        // Berechne die neue Y-Position basierend auf der Wellenfunktion
        float newYPos = Mathf.Sin((transform.position.x + Time.time * speed) * frequenz) * WaveHeight;
        // Aktualisiere die Position des Objekts
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, newYPos, transform.position.z);
    }

    // Aufgabe 1b
    public void AufgabeEinsB()
    {
        // Berechne die neue Y-Position basierend auf der Wellenfunktion
        float newYPos = Mathf.Sin((transform.position.x + Time.time * speed) * frequenz) * WaveHeight;
        // Berechne die Steigung (Ableitung) der Wellenfunktion
        float yAbleitung = Mathf.Cos((transform.position.x + Time.time * speed) * frequenz) * frequenz * WaveHeight;
        // Berechne die neue X-Position
        float newXPos = transform.position.x + speed * Time.deltaTime;
        // Aktualisiere die Y-Position unter Berücksichtigung der Steigung
        float newY = newYPos - (yAbleitung * slopeSpeedFactor * Time.deltaTime);
        // Setze die neue Position des Objekts
        transform.position = new Vector3(newXPos, newY, transform.position.z);
    }

    // Aufgabe 1c
    public void AufgabeEinsC()
    {
        // Berechne die neue Y-Position basierend auf der Wellenfunktion
        float newYPos = Mathf.Sin((transform.position.x + Time.time * speed) * frequenz) * WaveHeight;
        // Berechne die Steigung (Ableitung) der Wellenfunktion
        float yAbleitung = Mathf.Cos((transform.position.x + Time.time * speed) * frequenz) * frequenz * WaveHeight;
        // Berechne die Neigung basierend auf der Ableitung
        float neigung = Mathf.Atan(yAbleitung) * Mathf.Rad2Deg;
        // Berechne die neue X-Position
        float newXPos = transform.position.x + speed * Time.deltaTime;
        // Aktualisiere die Y-Position unter Berücksichtigung der Steigung
        float newY = newYPos - (yAbleitung * slopeSpeedFactor * Time.deltaTime);
        // Setze die Rotation des Objekts basierend auf der Neigung
        transform.rotation = Quaternion.Euler(0, 0, neigung);
        // Setze die neue Position des Objekts
        transform.position = new Vector3(newXPos, newY, transform.position.z);
    }
}

