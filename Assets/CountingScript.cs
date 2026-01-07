using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountingScript : MonoBehaviour
{
    public static CountingScript instance;
    public TMP_Text countText;
    int count = 0;
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        countText.text = count.ToString();
    }
    
    public void CountUp()
    {
        count++;
        countText.text = count.ToString();
    }
}
