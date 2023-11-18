using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DialogManager : MonoBehaviour
{
    public TMP_Text textNama;
    public TMP_Text textDialog;
    public Image charPotrait;

    private Queue<string> kalimat;
    private Queue<string> nama;
    private Queue<string> foto;

    // Start is called before the first frame update
    void Start()
    {
        kalimat = new Queue<string>();
        nama = new Queue<string>();
        foto = new Queue<string>();
    }

    public void startDialog(Dialog dialog)
    {
        nama.Clear();
        kalimat.Clear();
        foto.Clear();

        foreach(string name in dialog.nama)
        {
            nama.Enqueue(name);
        }

        foreach(string kata in dialog.kalimat)
        {
            kalimat.Enqueue(kata);
        }
        foreach (string gambar in dialog.foto)
        {
            foto.Enqueue(gambar);
        }

        if (dialog.nama.Length.Equals(0))
        {
            nextKalimatDialogOnly();
        }
        else
        {
            nextKalimat();
        }
    }

    public void nextKalimat()
    {
        if (kalimat.Count == 0)
        {
            FindObjectOfType<DialogTrigger>().beres();
            return;
        }
        string name = nama.Dequeue();
        string kata = kalimat.Dequeue();
        string gambar = "";

        if (foto.Count != 0)
        {
            gambar = foto.Dequeue();
        }

        StopAllCoroutines();
        StartCoroutine(ketikKata(kata,name,gambar));
    }

    public void nextKalimatDialogOnly()
    {
        if (kalimat.Count == 0)
        {
            FindObjectOfType<DialogTrigger>().beres();
            return;
        }   
        string kata = kalimat.Dequeue();

        StopAllCoroutines();
        StartCoroutine(ketikKata2(kata));
    }

    IEnumerator ketikKata(string kata, string nama,string foto)
    {
        if(foto != "")
        {
            charPotrait.sprite = Resources.Load<Sprite>(foto);
        }
        else
        {
            charPotrait.sprite = null;
        }
        textNama.text = nama;
        textDialog.text = "";
        foreach (char huruf in kata.ToCharArray())
        {
            textDialog.text += huruf;
            yield return null;
        }
    }
    IEnumerator ketikKata2(string kata)
    {
        textDialog.text = "";
        foreach (char huruf in kata.ToCharArray())
        {
            textDialog.text += huruf;
            yield return null;
        }
    }
}
