using System.Collections;
using UnityEngine;

namespace NoSpidersMod
{
    public class SpiderDeterrent : MonoBehaviour
    {
        private GameObject _fgSpiders;

        private void Awake()
        {
            StartCoroutine(CheckScene());
        }

        private IEnumerator CheckScene()
        {
            var _fgSpiders = GameObject.Find("fg_spiders");
            if (_fgSpiders != null)
            {
                _fgSpiders.SetActive(false);
            }

            yield break;
        }

        private void OnDisable()
        {
            _fgSpiders.SetActive(true);
        }
    }
}