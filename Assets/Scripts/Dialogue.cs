using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextAsset dialogueDataJson;
    private List<DialogueData> _dialogueDataList;

    public LevelController levelController;
    
    public int dialogueIndex = 0;

    public Image backGroundImage;
    public Image avatarChara;
    public TMP_Text textCharaName;
    public TMP_Text textCharaContent;
    public AudioSource audioChara;

    private int _count;

    private void Start()
    {
        DialogueLoad();
        DialogueStart(0);
    }

    private void OnDestroy()
    {
        // GOTO levelx
        levelController.LevelStart();
    }

    public void DialogueLoad()
    {
        if (dialogueDataJson != null)
        {
            _dialogueDataList = JsonUtility.FromJson<DialogList>(dialogueDataJson.text).dialogItems;
            _count = _dialogueDataList.Count;
        }
        else
        {
            Debug.LogError("JSON文件加载失败");
        }
    }

    public void NextClicked()
    {
        dialogueIndex++;
        if (dialogueIndex == _count - 1)
        {
            Destroy(this.gameObject);
        }

        DialogueStart(dialogueIndex);
    }

    public void DialogueStart(int index)
    {
        DialogueData data = _dialogueDataList[index];
        if (data.hasImageChange)
        {
            Debug.Log(data.imageFileName);
            Sprite image = Resources.Load<Sprite>("Assets/Sprites/" + data.imageFileName) as Sprite;
            backGroundImage.sprite = image;
            backGroundImage.GetComponent<Image>().color = Color.white;
        }

        if (data.hasAvatar)
        {
            Sprite image = Resources.Load<Sprite>("Assets/Sprites/" + data.avatarFileName) as Sprite;
            avatarChara.sprite = image;
        }

        if (data.hasSound)
        {
            AudioClip audioSource = Resources.Load<AudioClip>("Sounds/" + data.soundFileName);
            audioChara.PlayOneShot(audioSource);
        }

        textCharaName.SetText(data.characterName);
        textCharaContent.SetText(data.content);
    }
}