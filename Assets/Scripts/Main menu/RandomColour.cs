using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColour : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        Debug.Log(text);

        Color randomColour = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));

        text.color = randomColour;
    }
}
