using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    public InputField x0, x1, y0, y1;
    public InputField lWeight, rWeight, lTangent, rTangent;
    public InputField frameRange, valueRange;
    public Button convertBtn;
    // Start is called before the first frame update

    private void Start()
    {
        frameRange.text = "1.0";
        valueRange.text = "1.0";
        convertBtn.onClick.AddListener(() => { Calc(); });
    }

    void Calc()
    {
        float f_x0 = 0.0f, f_x1 = 0.0f, f_y0 = 0.0f, f_y1 = 0.0f;
        float frame_range = 1.0f, value_range = 1.0f;
        float.TryParse(x0.text, out f_x0);
        float.TryParse(x1.text, out f_x1);
        float.TryParse(y0.text, out f_y0);
        float.TryParse(y1.text, out f_y1);
        float.TryParse(frameRange.text, out frame_range);
        float.TryParse(valueRange.text, out value_range);
        f_x0 = Mathf.Clamp01(f_x0);
        f_x1 = Mathf.Clamp01(f_x1);
        f_y0 = Mathf.Clamp(f_y0, -5.0f, 5.0f);
        f_y1 = Mathf.Clamp(f_y1, -5.0f, 5.0f);
        x0.text = f_x0.ToString();
        x1.text = f_x1.ToString();
        y0.text = f_y0.ToString();
        y1.text = f_y1.ToString();

        float ratio = value_range / frame_range;

        lTangent.text = (ratio * (f_y0 / f_x0)).ToString();
        rTangent.text = (ratio * ((1.0 - f_y1) / (1.0 - f_x1))).ToString();

        float lLength = Mathf.Sqrt(f_x0 * f_x0 + f_y0 * f_y0);
        float rLength = Mathf.Sqrt((1 - f_x1) * (1 - f_x1) + (1 - f_y1) * (1 - f_y1));

        lWeight.text = (lLength / (lLength + rLength)).ToString();
        rWeight.text = (rLength / (lLength + rLength)).ToString();
    }
}
