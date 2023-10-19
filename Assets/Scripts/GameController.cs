using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    [Header("GENEL")]
    public GameObject level1;
    public GameObject level2;
    public int heartPieceCount;
    public int keyPieceCount;
    public AudioSource src;

    [Header("UI")]
    public Image heart;
    public Image key;
    public TMP_Text levelText;

    public Sprite pearl;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    public bool LoadNextLevel()
    {
        if(heartPieceCount ==0)
        {
            level1.SetActive(false);
            level2.SetActive(true);
            levelText.text = "Level 2";
            return true;
        }
        return false;
    }

    public void CollectHeart()
    {
        heartPieceCount--;
        float newFill = heart.fillAmount + 0.33f;
        heart.DOFillAmount(newFill, 0.3f);
    }

    public void CollectKey()
    {
        keyPieceCount--;
        float newFill = key.fillAmount + 0.33f;
        key.DOFillAmount(newFill, 0.3f);
    }
    public bool OpenChest(Chest chest)
    {
        if (keyPieceCount == 0)
        {
            SpriteRenderer pearl = chest.transform.GetChild(0).GetComponent<SpriteRenderer>();
            pearl.gameObject.SetActive(true);

            Sequence seq = DOTween.Sequence();
            seq.Append(pearl.DOColor(new Color(1f, 1f, 1f, 1f), 0.5f));
            seq.Append(pearl.transform.DOPunchScale(new Vector3(2f, 2f, 2f), 3f, 3, 1));
            seq.Append(pearl.transform.DOMove(Vector2.zero, 5f));
            seq.Append(pearl.transform.DOScale(4f, 3f));

            seq.OnComplete(() =>
            {
                SceneManager.LoadScene(2);
            }
            );
            return true;
        }

        return false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }


    public void EndGame()
    {
        PlayerController pc = FindObjectOfType<PlayerController>();
        pc.GetComponent<Animator>().enabled = false;
        Destroy(pc.GetComponent<Rigidbody2D>());
        pc.enabled = false;

    }

    public void PlayAudio(AudioClip clip)
    {
        src.PlayOneShot(clip);
    }
}
