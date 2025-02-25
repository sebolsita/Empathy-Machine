using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;   

public class DrHeadAim : MonoBehaviour
{
    public MultiAimConstraint headAimConstraint;
    public float lookSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartLookingAtPlayer();
    }

    public void StartLookingAtPlayer()
    {
        StartCoroutine(LookAtPlayer());
    }

    private IEnumerator LookAtPlayer()
    {
       
        float personLook = 0;
        float laptopLook = 1;
        while (personLook < 1)
        {
            Debug.Log(personLook);
            personLook += Time.deltaTime * lookSpeed;
            laptopLook -= Time.deltaTime * lookSpeed;
            headAimConstraint.data.sourceObjects.SetWeight(0, personLook);
            headAimConstraint.data.sourceObjects.SetWeight(1, laptopLook);
            yield return null;
        }
    }
 
}
