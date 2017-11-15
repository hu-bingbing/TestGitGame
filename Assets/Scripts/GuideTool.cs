
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogBaseData
{
    public Vector3 FogPosition;
    public float FogHight;
    public float FogWidth;
    public float FogTime;

    public FogBaseData(Vector3 _pos,float _hight,float _width,float _time)
    {
        FogPosition = _pos;
        FogHight = _hight;
        FogWidth = _width;
        FogTime = _time;
    }
}

public class GuideTextData
{
    public Vector3 TextPosition;
    public string TextContant;
    public GuideTextData(Vector3 _pos,string _contant)
    {
        TextPosition = _pos;
        TextContant = _contant;
    }
}

public class GuideSoundData
{
    public float DelayTime;
    public string SoundPath;
    public bool IsLoop;
    public GuideSoundData(float time,string path,bool isLoop)
    {
        DelayTime = time;
        SoundPath = path;
        IsLoop = isLoop ;
    }
}
public class GuideTool :MonoBehaviour {

    Transform fogTra;
    private Material fogMaterial;
    AudioSource CurrentSource;

    private void Awake()
    {
        fogTra = transform.FindChild("Fog").transform;
        fogMaterial = fogTra.GetComponent<Renderer>().material;
        fogMaterial.shader = Shader.Find("Custom/GaussBlurWithAlpha");
        OpenGuide();
    }

    public void SetFogData(FogBaseData data)
    {
        if(data == null)
        {
            return;
        }
        var pos = data.FogPosition;
        fogMaterial.SetVector("_Center", new Vector4(pos.x, pos.y, pos.z, 0));
        fogMaterial.SetFloat("_Hight", data.FogHight);
        fogMaterial.SetFloat("_Width", data.FogWidth);
        fogMaterial.SetFloat("_StartSpread", 1);
        fogMaterial.SetFloat("_StartTime", Time.time);
        fogMaterial.SetFloat("_TotalTime", data.FogTime);
    }

    //public UIWindow ShowGuideText(GuideTextData textData)
    //{
    //    UIWindow guideW = UIManager.Instance.OpenWindow(UIDef.UIGuideText);
    //    guideW.GetComponent<UIGuidText>().SetTextData(textData);
    //    CurrentGuideTextWnd = guideW;
    //    return guideW;
    //}
   
    //public void SetGuideAudio(string fileName)
    //{
    //    AudioManager.Instance.PlayAudio(fileName);
    //    //AudioClip clip = Resources.Load(soundData.SoundPath) as AudioClip;
    //    //AudioSource source = gameObject.AddComponent<AudioSource>();
    //    //source.clip = clip;
    //    //source.loop = soundData.IsLoop;
    //    //CurrentSource = source;
    //    //source.Play();
    //}

    public void OpenGuide()
    {
        fogTra.gameObject.SetActive(true);
        fogTra.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
    public void OpenGuide(FogBaseData fogData, GuideTextData textData, string fileName)
    {
        fogTra.gameObject.SetActive(true);
        fogTra.GetComponent<SpriteRenderer>().sortingOrder = 2;
        SetFogData(fogData);
        //ShowGuideText(textData);
        //SetGuideAudio(fileName);
    }


    //public void CloseGuide()
    //{
    //    fogTra.GetComponent<SpriteRenderer>().sortingOrder = 0;
    //    fogTra.gameObject.SetActive(false);
    //    if (CurrentGuideTextWnd != null)
    //    {
    //        CurrentGuideTextWnd.Close();
    //    }
    //    if(CurrentSource != null)
    //    {
    //        CurrentSource.Stop();
    //    }
       
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            OpenGuide();
            FogBaseData data = new FogBaseData(new Vector3(958f, 633f, 0f), 200f, 600f, 1f);
            SetFogData(data);
            GuideTextData textData = new GuideTextData(new Vector3(48, -168, 22), "今天天气好晴朗");
            //ShowGuideText(textData);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            FogBaseData data = new FogBaseData(new Vector3(958f, 603f, 0f), 300f, 20f, 0.5f);
            SetFogData(data);
            GuideTextData textData = new GuideTextData(new Vector3(48, 0, 22), "不晴朗");
            //ShowGuideText(textData);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //SetGuideAudio(AudioData.bgm_main);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            //CloseGuide();
        }
    }
}
