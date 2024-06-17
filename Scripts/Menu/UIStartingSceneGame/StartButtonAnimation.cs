using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StartButtonAnimation : MonoBehaviour
{
        [Header("___")]

        [Header("Scale Button")] 

        [SerializeField] private Vector3 _scaleTo;

        [SerializeField] private Vector3 _scaleFrom;
        [Header("Time")]

        [SerializeField][Min(0.0f)] private float _duration;


        private void Start()
        {
            StartCoroutine(PlayerLoopedScalingAnimation(transform, _scaleFrom, _scaleTo, _duration));
        }

  

        private IEnumerator PlayerLoopedScalingAnimation(Transform transformToAnimate , Vector3 _startingScale , Vector3 to , float duration)
        {
            while (true)
            {
                yield return StartCoroutine(PlayerScalingAnimation(transformToAnimate , to , duration));
                yield return StartCoroutine(PlayerScalingAnimation(transformToAnimate, _startingScale, duration));
            }
        }

        private IEnumerator PlayerScalingAnimation(Transform transformToAnimate , Vector3 to , float duration) 
        {
            float timeEnter = Time.time;

            Vector3 enterScale = transformToAnimate.localScale;

            while (Time.time < timeEnter + duration)
            {

                float elapsedTimePercent = (Time.time - timeEnter) / duration; // 0/2 = 0 me

                transformToAnimate.localScale = Vector3.Lerp(enterScale, to, elapsedTimePercent);

                yield return null;
            }
        }


}



