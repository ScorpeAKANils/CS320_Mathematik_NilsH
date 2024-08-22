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

public class MathePruefung : MonoBehaviour
{
    public float frequenz;
    public float WaveHeight;
    public float speed = 1;
    public RenderPath render;
    public Aufgaben curAuf = Aufgaben.einsA;
    [Range(0, 1)]
    public float slopeSpeedFactor = 1;

    private void Update()
    {
        switch (curAuf)
        {
            case Aufgaben.einsA:
                AufgabeEinsA();
                render.AufgabeEinsARenderer();
                break;
            case Aufgaben.einsB:
                AufgabeEinsB();
                render.AufgabeEinsBRenderer();
                break;
            case Aufgaben.einsC:
                AufgabeEinsC();
                render.AufgabeEinsCRenderer();
                break;
            case Aufgaben.zweiA:
                AufgabeZweiA();
                render.AufgabeZweiARenderer();
                break;
            case Aufgaben.zweiB:
                AufgabeZweiB();
                render.AufgabeZweiBRenderer();
                break;
            case Aufgaben.zweiC:
                AufgabeZweiC();
                render.AufgabeZweiCRenderer();
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
        float xPos = transform.position.x;
        float zPos = transform.position.z;
        float yPos = Mathf.Sin((xPos + Time.time * speed) * frequenz) * WaveHeight;
        float yAbleitung = Mathf.Cos((xPos + Time.time * speed) * frequenz) * frequenz * WaveHeight;

        // Korrekte Berechnung der Neigung
        float newRotationZ = Mathf.Atan2(yAbleitung, 1) * Mathf.Rad2Deg; // Neigung entlang der X-Achse
        float newY = yPos - (yAbleitung * slopeSpeedFactor * Time.deltaTime);

        Vector3 lastPos = transform.position; 
        transform.position = new Vector3(xPos + speed * Time.deltaTime, newY, zPos);
        Vector3 dir = transform.position - lastPos;
        transform.rotation = Quaternion.LookRotation(dir.normalized, Vector3.down);
    }

    public void AufgabeZweiA()
    {
        float newYPos = Mathf.Cos(transform.position.x + Time.time * speed) * (0.25f * transform.position.x) + Mathf.Sin(transform.position.z + Time.time * speed) * WaveHeight;
        transform.position = new Vector3(transform.position.x, newYPos, transform.position.z + speed * Time.deltaTime);
    }

    public void AufgabeZweiB()
    {
        float xPos = transform.position.x;
        float zPos = transform.position.z;
        float yPos = Mathf.Cos(xPos + Time.time * speed) * (0.25f * xPos) + Mathf.Sin(zPos + Time.time * speed) * WaveHeight;
        float yAbleitungX = -Mathf.Sin(xPos + Time.time * speed) * (0.25f * xPos) * WaveHeight;
        float yAbleitungZ = Mathf.Cos(zPos + Time.time * speed) * WaveHeight;
        float newY = yPos - (yAbleitungX * slopeSpeedFactor * Time.deltaTime) - (yAbleitungZ * slopeSpeedFactor * Time.deltaTime);
        transform.position = new Vector3(xPos + speed * Time.deltaTime, newY, zPos + speed * Time.deltaTime);
    }

    public void AufgabeZweiC()
    {
        float xPos = transform.position.x;
        float zPos = transform.position.z;
        float yPos = Mathf.Cos(xPos + Time.time * speed) * (0.25f * xPos) + Mathf.Sin(zPos + Time.time * speed) * WaveHeight;
        float yAbleitungX = -Mathf.Sin(xPos + Time.time * speed) * (0.25f * xPos) * WaveHeight;
        float yAbleitungZ = Mathf.Cos(zPos + Time.time * speed) * WaveHeight;

        // Korrekte Berechnung der Neigungen in beiden Achsen
        float newRotationX = Mathf.Atan2(yAbleitungZ, 1) * Mathf.Rad2Deg; // Neigung entlang der Z-Achse
        float newRotationZ = Mathf.Atan2(yAbleitungX, 1) * Mathf.Rad2Deg; // Neigung entlang der X-Achse
        float newY = yPos - (yAbleitungX * slopeSpeedFactor * Time.deltaTime) - (yAbleitungZ * slopeSpeedFactor * Time.deltaTime);

        //transform.rotation = Quaternion.Euler(newRotationX, 0, newRotationZ);
        Vector3 lastPos = transform.position; 
        transform.position = new Vector3(xPos + speed * Time.deltaTime, newY, zPos + speed * Time.deltaTime);
        Vector3 dir = transform.position - lastPos;
        transform.rotation = Quaternion.LookRotation(dir.normalized, Vector3.down);
    }
}

