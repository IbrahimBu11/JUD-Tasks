using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Queue : MonoBehaviour
{
    public Queue<string> bari ;

    public InputField input;
    public TextMeshProUGUI text;


    void start()
    {
        bari = new Queue<string>();
    }
    string GetName()
    {
        return input.text;
    }
    public void OnEnque()
    {
        bari = new Queue<string>();
        string name = GetName();
        Add(name);
        foreach (string str in bari)
        {
            text.text += "\n" + str;
        }
    }
    void Add(string name)
    {
        bari.Enqueue(name);
    }
    public void Sub()
    {
        bari.Dequeue();
        foreach(string str in bari)
        {
            text.text += "\n" + str + "\n" + bari.Count;
            
        } 
    }


}
