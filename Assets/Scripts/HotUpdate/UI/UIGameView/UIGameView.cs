using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using F8Framework.Core;
using F8Framework.Launcher;
using UnityEngine.Networking;

public class UIGameView : BaseView
{
    private List<Transform> hps = new List<Transform>();

    private int hp = 5;
    // Awake
    protected override void OnAwake()
    {
        FF8.Message.AddEventListener(GameDataModule.MessageEvent.SubHp, SubHp, this);
    }

    private void SubHp()
    {
        hp -= 1;
        for (int i = 0; i < hps.Count; i++)
        {
            hps[i].gameObject.SetActive(hp > i);
        }

        tf_group_tf.ScaleTween(Vector3.one * 2, 0.1f).SetOnComplete(
            () =>
            {
                tf_group_tf.ScaleTween(Vector3.one, 0.25f);
            });
    }

    private int timeid = 0;
    // 参数传入
    protected override void OnAdded(int uiId, object[] args = null)
    {
        hps.Add(tf_hp_tf);
        for (int i = 1; i < 5; i++)
        {
            hps.Add(Instantiate(tf_hp_tf, tf_group_tf));
        }

        int count = 0;
        timeid = FF8.Timer.AddTimer(this, 1f, 0f, -1, () =>
        {
            count += 1;
            TimeSpan timeSpan = TimeSpan.FromSeconds(count);
            TextLegacy_TextLegacy.text = timeSpan.Minutes.ToString("D2") + ":" + timeSpan.Seconds.ToString("D2");
        }, () =>
        {
            
        });
    }
    
    private string[] fileInfos = new[]
    {
        "https://raw.githubusercontent.com/TippingGame/F8Framework/refs/heads/main/Tests/Logo.png"
    };
    
    private Downloader downloader;
    
    // Start
    protected override void OnStart()
    {
        
        // 创建下载器
        downloader = FF8.Download.CreateDownloader("Download", new Downloader());
        
        // 设置超时时间，默认为无超时时间
        downloader.DownloadTimeout = 30;
            
        // 设置下载器回调
        downloader.OnDownloadSuccess += OnDownloadSucess;
        downloader.OnDownloadFailure += OnDownloadFailure;
        downloader.OnDownloadStart += OnDownloadStart;
        downloader.OnDownloadOverallProgress += OnDownloadOverall;
        downloader.OnAllDownloadTaskCompleted += OnDownloadFinish;
            
        int count = 0;
        // 添加下载清单
        foreach (var fileInfo in fileInfos)
        {
            count += 1;
            
            string downloadPath = Application.dataPath + "/Logo_" + count + ".png";
            long fileSizeInBytes = 0;
            
            // 断点续传
            if (File.Exists(downloadPath))
            {
                FileInfo downloadFileInfo = new FileInfo(downloadPath);
                fileSizeInBytes = downloadFileInfo.Length;
            }
            
            downloader.AddDownload(fileInfo, downloadPath, fileSizeInBytes, true);
        }
            
        // 下载器开始下载
        downloader.LaunchDownload();
    }
    
    // 开始下载
    void OnDownloadStart(DownloadStartEventArgs eventArgs)
    {
        LogF8.Log(eventArgs.DownloadInfo.DownloadUrl);
    }
        
    void OnDownloadOverall(DonwloadUpdateEventArgs eventArgs)
    {
        LogF8.Log(eventArgs.DownloadInfo.DownloadProgress);
        // 测试断点续传，暂停下载
        // if (eventArgs.DownloadInfo.DownloadProgress > 0.4f)
        // {
        //     downloader.CancelDownload();
        //     return;
        // }
        
        // 部分下载任务本身仅知道下载连接，无法获取需要下载的二进制长度，无法使用更精准的进度。
        float currentTaskIndex = (float)eventArgs.CurrentDownloadTaskIndex;
        float taskCount = (float)eventArgs.DownloadTaskCount;

        // 计算进度百分比
        float progress = currentTaskIndex / taskCount * 100f;
        // LogF8.Log(progress);
    }
        
    // 下载成功
    void OnDownloadSucess(DownloadSuccessEventArgs eventArgs)
    {
        LogF8.Log($"DownloadSuccess {eventArgs.DownloadInfo.DownloadUrl}");
    }
        
    // 下载失败
    void OnDownloadFailure(DownloadFailureEventArgs eventArgs)
    {
        LogF8.LogError($"DownloadFailure {eventArgs.DownloadInfo.DownloadUrl}\n{eventArgs.ErrorMessage}");
    }
        
    // 所有下载完成
    void OnDownloadFinish(DownloadTasksCompletedEventArgs eventArgs)
    {
        LogF8.Log($"DownloadFinish {eventArgs.TimeSpan}");
        
        string downloadPath = Application.dataPath + "/Logo_1.png";
        StartCoroutine(DownloadImage(downloadPath));
    }
    
    IEnumerator DownloadImage(string downloadPath)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(downloadPath);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
            LogF8.LogError(request.error);
        else
        {
            rimg_logo_rimg.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
    
    protected override void OnViewTweenInit()
    {
        //transform.localScale = Vector3.one * 0.7f;
    }
    
    // 自定义打开界面动画
    protected override void OnPlayViewTween()
    {
        //transform.ScaleTween(Vector3.one, 0.1f).SetEase(Ease.Linear).SetOnComplete(OnViewOpen);
    }
    
    // 打开界面动画完成后
    protected override void OnViewOpen()
    {
        
    }
    
    // 删除之前
    protected override void OnBeforeRemove()
    {
        FF8.Timer.RemoveTimer(timeid);
    }
    
    // 删除
    protected override void OnRemoved()
    {
        FF8.Message.RemoveEventListener(GameDataModule.MessageEvent.SubHp, SubHp, this);
    }
    
    // 自动获取组件（自动生成，不能删除）
    [SerializeField] private Transform tf_group_tf;
    [SerializeField] private Text TextLegacy_TextLegacy;
    [SerializeField] private Text TextLegacy1_TextLegacy;
    [SerializeField] private RawImage rimg_logo_rimg;
    [SerializeField] private GameObject rimg_logo_go;
    [SerializeField] private Transform tf_hp_tf;

#if UNITY_EDITOR
    protected override void SetComponents()
    {
        tf_group_tf = transform.Find("tf_group").GetComponent<Transform>();
        TextLegacy_TextLegacy = transform.Find("Text (Legacy)").GetComponent<Text>();
        TextLegacy1_TextLegacy = transform.Find("Text (Legacy) (1)").GetComponent<Text>();
        rimg_logo_rimg = transform.Find("rimg_logo").GetComponent<RawImage>();
        rimg_logo_go = transform.Find("rimg_logo").gameObject;
        tf_hp_tf = transform.Find("tf_group/tf_hp").GetComponent<Transform>();
    }
#endif
    // 自动获取组件（自动生成，不能删除）
}