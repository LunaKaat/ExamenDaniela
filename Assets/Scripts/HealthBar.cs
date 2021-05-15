using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image UIHealthFrame;
    public Image UIHealthBar;

    private Boy boy;
    // Start is called before the first frame update
    void Start()
    {
        boy = GameObject.FindGameObjectWithTag("Player").GetComponent<Boy>();
    }


    void Update()
    {
        UIHealthBar.fillAmount = (float)boy.currentHp / (float)boy.HP;
    }
}
