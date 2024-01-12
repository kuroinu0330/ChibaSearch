using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BadgeAlbumManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> badgeAllStars;
    
    [SerializeField]
    private List<BadgeIndex> badgeIndexs = new List<BadgeIndex>();

    [SerializeField]
    private Vector3 scaleSpeed;

    public static BadgeAlbumManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            for (int i = 0; i < badgeAllStars.Count; i++)
            {
                BadgeIndex index = new BadgeIndex();
                index.badgeObject = badgeAllStars[i];
                badgeIndexs.Add(index);
            }
        }
    }

    [Serializable]
    private class BadgeIndex
    {
        public GameObject badgeObject = null;
        public bool firstAcquisitionFlag = false;
    }

    public void GetBadgeThis(int num)
    {
        if (num < badgeIndexs.Count)
        {
            badgeIndexs[num].firstAcquisitionFlag = true;
        }
    }

    public void BadgeActionCheck()
    {
        bool canPlaySE = true;
        for (int i = 0; i < badgeIndexs.Count; i++)
        {
            if (badgeIndexs[i].firstAcquisitionFlag)
            {
                StartCoroutine(BadgeScaleDown(badgeIndexs[i], canPlaySE));

                if (canPlaySE)
                {
                    canPlaySE = false;
                }
            }
        }
    }

    private IEnumerator BadgeScaleDown(BadgeIndex Badge,bool se)
    {
        Badge.badgeObject.SetActive(true);
        Badge.firstAcquisitionFlag = false;
        while (Badge.badgeObject.transform.localScale.x > 1f)
        {
            Badge.badgeObject.transform.localScale -= scaleSpeed * Time.deltaTime;
            yield return null;
        }

        if (se)
        {
            SoundManager.instance.PlayAudioSorce(SoundManager.AudioOfType.SYSTEMSE, 5);
        }
        yield break;
    }
}
