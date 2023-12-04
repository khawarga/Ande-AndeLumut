using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dialog
{
    public string[] nama;
    public Color[] warnaNama;
    public string[] foto;

    [TextArea(3, 10)]
    public string[] kalimat;
}
