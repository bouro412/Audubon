using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExpNode : MonoBehaviour
{
    public IAst expression;
    AudubonValue LangValue { get; set; }
    TextMesh info;
    public GameObject[] argObjects;
    List<IAst> args;
    List<IAst> argsCache;
    GameObject CatchingHand;

    // Use this for initialization
    void Start()
    {
        if(argObjects == null) {
            args = new List<IAst>();
        }else {
            args = argObjects.Select(a => a.GetComponent<IAst>()).ToList();
        }
        argsCache = new List<IAst>(args);
        expression = new Const((int)3);
    }

    // Update is called once per frame
    protected void Update()
    {
        displayInformation();
        if (hasValue())
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        if (isEdited())
        {
            expression.UpdateArgs(args);
        }
    }

    bool isEdited()
    {
        var ret = args.SequenceEqual(argsCache);
        if (!ret)
        {
            argsCache = args;
            return true;
        }
        return false;
    }

    public virtual bool hasValue()
    {
        return LangValue != null;
    }

    public virtual AudubonValue GetLangValue()
    {
        return LangValue;
    }

    protected virtual void SetLangValue(AudubonValue value)
    {
        LangValue = value;
    }

    void run()
    {

    }

    protected virtual string information()
    {
        return expression.information();
    }
    void displayInformation()
    {
        if (info == null)
        {
            info = this.GetComponentInChildren<TextMesh>();
        }
        info.text = this.information();
    }
    public virtual AudubonValue eval(AudubonEnv env)
    {
        return expression.eval(env);
    }

    void OnTriggerStay(Collider collider) {
        if (collider.gameObject.tag == "GameController") {
            var controller = collider.gameObject.GetComponentInParent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)controller.index);
            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {

            }
        }
    }

}