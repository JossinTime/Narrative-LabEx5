using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAreaTrigger : MonoBehaviour
{
    public TMPro.TextMeshProUGUI titleText;
    public TMPro.TextMeshProUGUI byLineText;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        AreaTrigger area = collision.GetComponent<AreaTrigger>();

        titleText.text = area.title;
        byLineText.text = "By: " + area.author;

        if (area != null)
        {

            StopAllCoroutines();
            StartCoroutine(AnimateTitle(area, 5));
        }
    }

    public IEnumerator AnimateTitle(AreaTrigger area, float duration)
    { 
        titleText.text = area.title;
        byLineText.text = "By: " + area.author;

        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            float percentage = timeElapsed / duration;
            titleText.alpha = 1f - percentage;
            byLineText.alpha = 1f - percentage;
            yield return new WaitForEndOfFrame();
            timeElapsed += Time.deltaTime;
        }
        yield return new WaitForSeconds(duration);
        titleText.text = "";
        byLineText.text = "";
    }
}
