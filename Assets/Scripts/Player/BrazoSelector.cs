using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazoSelector : MonoBehaviour
{
    public GameObject brazoDer;
    public GameObject brazoIzq;
    public GameObject brazoArr;
    public GameObject brazoDown;

    public Animator animator;

    
    void Update()
    {
        var currentAnim = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

        if (currentAnim.Contains("Down"))
        {
            brazoArr.SetActive(false);
            brazoDer.SetActive(false);
            brazoDown.SetActive(true);
            brazoIzq.SetActive(false);
        }
        if (currentAnim.Contains("Up"))
        {
            brazoArr.SetActive(true);
            brazoDer.SetActive(false);
            brazoDown.SetActive(false);
            brazoIzq.SetActive(false);
        }
        if (currentAnim.Contains("Left"))
        {
            brazoArr.SetActive(false);
            brazoDer.SetActive(false);
            brazoDown.SetActive(false);
            brazoIzq.SetActive(true);
        }
        if (currentAnim.Contains("Right"))
        {
            brazoArr.SetActive(false);
            brazoDer.SetActive(true);
            brazoDown.SetActive(false);
            brazoIzq.SetActive(false);
        }
    }
}
