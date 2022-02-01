using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{
    //tüm sahnelerde kullanmak için 
    public static DataManager Instance;

    EasyFileSave myFile;

    private float skor;
    public float totalSkor;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        // önceden oluþturulan instance yi olduðu gibi kullanmak için
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float Skor
    {
        get
        {
            return skor;

        }
        set
        {
            skor = value;
            GameObject.Find("SkorText").GetComponent<Text>().text = "" + skor.ToString();
        }
    }

    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }

    public void SaveData()
    {
        totalSkor += skor;
        myFile.Add("totalSkor", totalSkor);

        myFile.Save();
    }

    public void LoadData()
    {
        if (myFile.Load())
        {
            totalSkor = myFile.GetFloat("totalSkor");
        }
    }
}
