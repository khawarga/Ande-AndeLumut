using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TMP_Text textNama;
    public TMP_Text textDialog;
    public Image charPotrait;

    public GameObject nameBox;
    public GameObject potraitBox;
    public AudioSource typingSound;
    public Image triangle;

    private bool typing;

    private Queue<string> kalimat;
    private Queue<string> nama;
    private Queue<string> foto;
    private Queue<Color> warnanama;

    // Start is called before the first frame update
    void Start()
    {
        kalimat = new Queue<string>();
        nama = new Queue<string>();
        foto = new Queue<string>();
        warnanama = new Queue<Color>();
    }

    public void startDialog(Dialog dialog)
    {
        nama.Clear();
        kalimat.Clear();
        foto.Clear();
        warnanama.Clear();

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
        foreach (Color warna in dialog.warnaNama)
        {
            warnanama.Enqueue(warna);
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
        Color warna = warnanama.Dequeue();

        if (foto.Count != 0)
        {
            gambar = foto.Dequeue();
        }

        StopAllCoroutines();
        StartCoroutine(ketikKata(kata,name,gambar, warna));
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

    IEnumerator ketikKata(string kata, string nama,string foto, Color warnanama)
    {
        typing = true;
        triangle.enabled = false;

        charPotrait.gameObject.SetActive(false);
        if (foto != "")
        {
            potraitBox.SetActive(true);
            charPotrait.gameObject.SetActive(true);
            charPotrait.sprite = Resources.Load<Sprite>(foto);
        }
        else
        {
            potraitBox.SetActive(false);
            charPotrait.sprite = null;
        }

        if(nama != "")
        {
            nameBox.SetActive(true);
        }
        else
        {
            nameBox.SetActive(false);
        }
        textNama.text = nama;
        textDialog.text = "";
        textNama.color = warnanama;

        typingSound.enabled = true;

        foreach (char huruf in kata.ToCharArray())
        {
            textDialog.text += huruf;
            yield return null;
        }

        typingSound.enabled = false;
        triangle.enabled = true;
        yield return new WaitForSecondsRealtime(1);

        typing = false;
    }

    IEnumerator ketikKata2(string kata)
    {
        typing = true;
        triangle.enabled = false;

        textDialog.text = "";

        typingSound.enabled = true;

        foreach (char huruf in kata.ToCharArray())
        {
            textDialog.text += huruf;
            yield return null;
        }
        typingSound.enabled = false;
        triangle.enabled = true;

        yield return new WaitForSecondsRealtime(1);

        typing = false;
    }

    public bool getTyping()
    {
        return typing;
    }
}
