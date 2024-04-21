using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Object : MonoBehaviour
{
    public GameObject vfxTouch;

    private bool canTouch;

    int index = 0;

    public List<GameObject> states;

    private void Awake()
    {
        canTouch = true;
    }

    private void Start()
    {
        ScaleStateByIndex(0, 1);
    }

    private void OnMouseDown()
    {
        if (!canTouch) return;

        canTouch = false;

        PlayVFX();

        states[index].gameObject.transform.DOScale(0, 0.5f).OnComplete(() => {
            index += 1;

            ScaleStateByIndex(index, 1);

            if (index == states.Count - 1)
            {
                GameManager.Instance.CheckLevelUp();
            }

            canTouch = true;
        });
    }

    private void PlayVFX()
    {
        GameObject vfx = Instantiate(vfxTouch, transform.position, Quaternion.identity) as GameObject;

        Destroy(vfx, 1f);
    }

    private void ScaleStateByIndex(int index,int endValue)
    {
        states[index].gameObject.SetActive(true);
        states[index].gameObject.transform.DOScale(endValue, 0.5f);
    }
}
