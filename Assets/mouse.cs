using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouse : MonoBehaviour
{   
    public InputField Fuerza;
   
    public Vector3 fAplicada;
    float mFuerza;
 
 Vector3 pos_base, pos_click, pos_click_sig, pos_Mouse, VectorF, Ang;
    // Start is called before the first frame update
    void Start()
    {
       
        pos_base = transform.position;
    }

    // Update is called once per frame
    void OnMouseDrag()
    {

        pos_Mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20);

        pos_click = Camera.main.ScreenToWorldPoint(pos_Mouse);

        transform.position = pos_click;
    }

    void OnMouseUp()
    {

        VectorF.x = Mathf.Abs(pos_click.x - pos_base.x);
        VectorF.y = Mathf.Abs(pos_click.y - pos_base.y);
        VectorF.z = Mathf.Abs(pos_click.z - pos_base.z);
        mFuerza = VectorF.magnitude;
        Ang = VectorF.normalized;
        fAplicada.y = (mFuerza * Ang.x);
        if(pos_click.x<0 && pos_click.z>pos_click_sig.z)
        {
            fAplicada.y = -fAplicada.y;
        }
        else if (pos_click.x > 0 && pos_click.z >pos_click_sig.z)
        {
            fAplicada.y = -fAplicada.y;
        }
         
        Fuerza.text  = fAplicada.y.ToString();
        pos_click_sig = pos_click;
    }
}



