using UnityEngine;
using System.Collections;



public class CounterScript : MonoBehaviour
{
    public GameObject[] faces;
    public 
    int nextNumber;
    int currentFaceFacingCamera;
    int counterNumber;
    int lastface;
    int lastnumbert;
    int frameCounter;
    // Use this for initialization
    void Start()
    {
        frameCounter = 1;
        counterNumber = 0;
        currentFaceFacingCamera = 0;
        StartCoroutine(rotateCube());
        nextNumber = 0;
    }


    void TheMagic()
    {
        if (currentFaceFacingCamera == 4)
            currentFaceFacingCamera = 0;
        if (counterNumber == 10)
            counterNumber = 0;
        for (int i = 0; i <= 9; i++)
        {
            if (currentFaceFacingCamera == 0)
                faces[2].GetComponent<FaceScript>().faces[i].SetActive(false);
            if (currentFaceFacingCamera == 1)
                faces[3].GetComponent<FaceScript>().faces[i].SetActive(false);
            if (currentFaceFacingCamera == 2)
                faces[0].GetComponent<FaceScript>().faces[i].SetActive(false);
            if (currentFaceFacingCamera == 3)
                faces[1].GetComponent<FaceScript>().faces[i].SetActive(false);
        }
        faces[currentFaceFacingCamera].GetComponent<FaceScript>().faces[counterNumber].SetActive(true);
        if (currentFaceFacingCamera < 3 && counterNumber < 9)
            faces[currentFaceFacingCamera + 1].GetComponent<FaceScript>().faces[counterNumber + 1].SetActive(true);
        if (currentFaceFacingCamera == 3 && counterNumber < 9)
            faces[0].GetComponent<FaceScript>().faces[counterNumber + 1].SetActive(true);
        if (currentFaceFacingCamera < 3 && counterNumber == 9)
            faces[currentFaceFacingCamera + 1].GetComponent<FaceScript>().faces[0].SetActive(true);
        if (currentFaceFacingCamera == 3 && counterNumber == 9)
            faces[0].GetComponent<FaceScript>().faces[0].SetActive(true);
        currentFaceFacingCamera++;
        counterNumber++;
    }

    IEnumerator rotateCube()
    {
        while (true)
        {
            if (frameCounter % 101 == 0)
            {
                TheMagic();
                frameCounter = 1;
            }
            transform.Rotate(Vector3.down * 0.9f);
            frameCounter++;
            yield return new WaitForSeconds(0.01f);
        }
    }
}