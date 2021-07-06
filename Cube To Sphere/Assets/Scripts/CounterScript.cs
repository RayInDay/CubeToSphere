using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class CounterScript : MonoBehaviour
{
    private readonly string temple = "Points: {0}";
    private uint value;
    private Text counter;
    private void Start()
    {
        counter = GetComponent<Text>();
    }
    public void AddToCounter()
    {
        value++;
        counter.text = string.Format(temple, value);
    }

}
