using UnityEngine;
using System.Collections;

public class ASTNode : MonoBehaviour
{
    AudubonValue LangValue { get; set; }
    TextMesh info;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    protected void Update()
    {
        displayInformation();
        if (hasValue())
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
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
        return "hogei";
    }
    void displayInformation()
    {
        if (info == null)
        {
            info = this.GetComponentInChildren<TextMesh>();
        }
        info.text = this.information();
    }
    public virtual AudubonValue eval()
    {
        return GetLangValue();
    }
}