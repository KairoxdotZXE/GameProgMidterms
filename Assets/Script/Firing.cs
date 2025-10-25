using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEditor.ShaderGraph;
using UnityEngine;


public class Firing : MonoBehaviour
{
    
    public Transform BulletSpawn;
    public GameObject Bullet;
    public GameObject baseTank, tankCannon;
    public MeshRenderer rend1, rend2, bulletRend;
    private Color[] ColorSwap = new Color[3];
    private String[] colors = new string[3] { "red", "green", "blue" };
    private int colorIndex = 0;
    void Start()
    {
        ColorSwap[0] = Color.red;
        ColorSwap[1] = Color.green;
        ColorSwap[2] = Color.blue;
        rend1 = baseTank.GetComponent<MeshRenderer>();
        rend2 = tankCannon.GetComponent<MeshRenderer>();
        bulletRend = Bullet.GetComponent<MeshRenderer>();
        ChangeColor();
        StartCoroutine(Shoot());
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            

            ChangeColor();
            Debug.Log("colorIndex is " +  colorIndex);
            colorIndex++;
            
        }
    }
    void ChangeColor()
    {
        if (colorIndex == ColorSwap.Length)
        {
            Debug.Log("Swapping To" + colors);
            colorIndex = 0;
            rend1.material.color = ColorSwap[colorIndex];
            rend2.material.color = ColorSwap[colorIndex];
            bulletRend.sharedMaterial.color = ColorSwap[colorIndex];
        }
        else
        {
            Debug.Log("ChangeColor Function Called");
            Debug.Log("ColorChange");
            rend1.material.color = ColorSwap[colorIndex];
            rend2.material.color = ColorSwap[colorIndex];
            bulletRend.sharedMaterial.color = ColorSwap[colorIndex];
        }
        GameManager.instance.GetBulletColor(colorIndex);
    }

    IEnumerator Shoot(){ yield return new WaitForSeconds(1f); /*Debug.Log("Shooting");*/ Instantiate(Bullet, BulletSpawn.position, transform.rotation);StartCoroutine(Shoot()); }
}
