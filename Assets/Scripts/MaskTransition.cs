using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskTransition : MonoBehaviour
{
    [SerializeField] private float _Speed = .000000001f;
    [SerializeField] private Image _KeyholeImage;

    public struct SizePos
    {
        public Vector2 Size;
        public Vector2 Pos;
    }

    [SerializeField] private SizePos PointA = new SizePos() { Size = new Vector2(12508, 14433), Pos = new Vector2(-5293.748f, -6725.214f) }, 
        PointB = new SizePos() { Size = new Vector2(2, 2), Pos = new Vector2(346f, 375f) };

    public enum Sides
    {
        Left, Right, Top, Bottom
    }
    private RectTransform[] _SideRects = new RectTransform[(int)Sides.Bottom + 1];
    [SerializeField] Image MaskImage;

    void OnEnable()
    {
        for(int i =0; i < _SideRects.Length; i++)
        {
            if (_SideRects[i] != null) continue;
            GameObject newSideRect = new GameObject("RectSide_" + (Sides)i, typeof(Image));
            newSideRect.transform.SetParent(MaskImage.transform);

            Image img = newSideRect.GetComponent<Image>();
            img.color = Color.black;
            _SideRects[i] = img.rectTransform;
            _SideRects[i].SetParent(MaskImage.transform.parent);
            _SideRects[i].transform.SetSiblingIndex(_SideRects[i].parent.childCount - 2);
            _SideRects[i].anchorMin = Vector2.zero;
            _SideRects[i].anchorMax = Vector2.zero;
            _SideRects[i].pivot = Vector2.zero;

            SetRectSizePosBySide(_SideRects[i], (Sides)i);
        }
    }

    private void SetRectSizePosBySide(RectTransform sideRect, Sides side)
    {
        Vector2 MaskPos = _KeyholeImage.rectTransform.anchoredPosition;
        Vector2 MaskSize = _KeyholeImage.rectTransform.sizeDelta;

        switch (side)
        {
            case Sides.Left:
                sideRect.anchoredPosition = Vector2.zero;
                sideRect.sizeDelta = new Vector2(MaskPos.x, Screen.height);
                break;
            case Sides.Right:
                sideRect.anchoredPosition = new Vector2(MaskPos.x + MaskSize.x, 0);
                sideRect.sizeDelta = new Vector2(Screen.width - (MaskPos.x + MaskSize.x), Screen.height);
                break;
            case Sides.Top:
                sideRect.anchoredPosition = new Vector2(MaskPos.x, MaskPos.y + MaskSize.y);
                sideRect.sizeDelta = new Vector2(MaskSize.x, Screen.height - (MaskPos.y + MaskSize.y));
                break;
            case Sides.Bottom:
                sideRect.anchoredPosition = new Vector2(MaskPos.x, 0);
                sideRect.sizeDelta = new Vector2(MaskSize.x, MaskPos.y);
                break;
        }
    }

    IEnumerator LerpSizePos()
    {
        yield return new WaitForSeconds(5f);
        // Fade in 
        for (float f = 0; f <= 1f; f += _Speed * Time.fixedDeltaTime * .2f)
        {
            _KeyholeImage.rectTransform.sizeDelta = Vector2.Lerp(PointA.Size, PointB.Size, f);
            _KeyholeImage.rectTransform.anchoredPosition = Vector2.Lerp(PointA.Pos, PointB.Pos, f);
            UpdateRects();
            yield return null;
        }
        _KeyholeImage.rectTransform.sizeDelta = PointB.Size;
        _KeyholeImage.rectTransform.anchoredPosition = PointB.Pos;
        UpdateRects();

        // Wait
        yield return new WaitForSeconds(2f);

        // Fade Out
        for (float f = 0.0f; f <= 1.0f; f += _Speed * Time.fixedDeltaTime * .2f)
        {
            _KeyholeImage.rectTransform.sizeDelta = Vector2.Lerp(PointB.Size, PointA.Size, f);
            _KeyholeImage.rectTransform.anchoredPosition = Vector2.Lerp(PointB.Pos, PointA.Pos, f);
            UpdateRects();
            yield return null;
        }
        _KeyholeImage.rectTransform.sizeDelta = PointA.Size;
        _KeyholeImage.rectTransform.anchoredPosition = PointA.Pos;
        UpdateRects();

        yield return new WaitForSeconds(2f);
    }

    public IEnumerator TransitionOutro(Vector2 maskCoordinates)
    {
        for (float f = 0.0f; f <= 1.0f; f += _Speed * Time.fixedDeltaTime * .2f)
        {
            _KeyholeImage.rectTransform.sizeDelta = Vector2.Lerp(PointA.Size, PointB.Size, f);
            _KeyholeImage.rectTransform.anchoredPosition = Vector2.Lerp(PointA.Pos, maskCoordinates, f);
            UpdateRects();
            yield return null;
        }
        _KeyholeImage.rectTransform.sizeDelta = PointB.Size;
        _KeyholeImage.rectTransform.anchoredPosition = PointB.Pos;
        UpdateRects();
    }

    public IEnumerator TransitionIntro(Vector2 maskCoordinates)
    {
        for (float f = 0.0f; f <= 1.0f; f += _Speed * Time.fixedDeltaTime * .2f)
        {
            _KeyholeImage.rectTransform.sizeDelta = Vector2.Lerp(PointB.Size, PointA.Size, f);
            _KeyholeImage.rectTransform.anchoredPosition = Vector2.Lerp(maskCoordinates, new Vector2(-5595, -7906), f);
            UpdateRects();
            yield return null;
        }
        _KeyholeImage.rectTransform.sizeDelta = PointA.Size;
        _KeyholeImage.rectTransform.anchoredPosition = PointA.Pos;
        UpdateRects();
    }

    private void UpdateRects()
    {
        for (int i = 0; i < _SideRects.Length; i++)
        {
            if (_SideRects[i] != null)
                SetRectSizePosBySide(_SideRects[i], (Sides)i);
        }
    }
}
