using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ColorHSV
{
    public float h;
    public float s;
    public float v;
    public float a;

    public ColorHSV(float h, float s, float v, float a)
    {
        this.h = h;
        this.s = s;
        this.v = v;
        this.a = a;
    }

    public override string ToString()
    {
        return string.Format("HSVA: ({0:F3}, {1:F3}, {2:F3}, {3:F3})", h, s, v, a);
    }

    public static bool operator ==(ColorHSV lhs, ColorHSV rhs)
    {
        if (lhs.a != rhs.a)
        {
            return false;
        }

        if (lhs.v == 0 && rhs.v == 0)
        {
            return true;
        }

        if (lhs.s == 0 && rhs.s == 0)
        {
            return lhs.v == rhs.v;
        }

        return lhs.h == rhs.h &&
               lhs.s == rhs.s &&
               lhs.v == rhs.v;
    }

    public static implicit operator ColorHSV(Color c)
    {
        return c.ToHSV();
    }

    public static implicit operator Color(ColorHSV hsv)
    {
        return hsv.ToRGB();
    }

    public static implicit operator ColorHSV(Color32 c32)
    {
        return ((Color)c32).ToHSV();
    }

    public static implicit operator Color32(ColorHSV hsv)
    {
        return hsv.ToRGB();
    }

    public static bool operator !=(ColorHSV lhs, ColorHSV rhs)
    {
        return !(lhs == rhs);
    }

    public override bool Equals(object other)
    {
        if (other == null)
        {
            return false;
        }

        if (other is ColorHSV || other is Color || other is Color32)
        {
            return this == (ColorHSV)other;
        }

        return false;
    }

    public override int GetHashCode()
    {
        // This is maybe not a good implementation :)
        return ((Color)this).GetHashCode();
    }

    public Color ToRGB()
    {
        Vector3 rgb = HUEtoRGB(h);
        Vector3 vc = ((rgb - Vector3.one) * s + Vector3.one) * v;

        return new Color(vc.x, vc.y, vc.z, a);
    }

    private static Vector3 HUEtoRGB(float h)
    {
        float r = Mathf.Abs(h * 6 - 3) - 1;
        float g = 2 - Mathf.Abs(h * 6 - 2);
        float b = 2 - Mathf.Abs(h * 6 - 4);

        return new Vector3(Mathf.Clamp01(r), Mathf.Clamp01(g), Mathf.Clamp01(b));
    }
}

public static class ColorExtension
{
    private const float EPSILON = 1e-10f;

    public static ColorHSV ToHSV(this Color rgb)
    {
        Vector3 hcv = RGBtoHCV(rgb);
        float s = hcv.y / (hcv.z + EPSILON);

        return new ColorHSV(hcv.x, s, hcv.z, rgb.a);
    }

    private static Vector3 RGBtoHCV(Color rgb)
    {
        Vector4 p = rgb.g < rgb.b ? new Vector4(rgb.b, rgb.g, -1, 2f / 3f) : new Vector4(rgb.g, rgb.b, 0, -1f / 3f);
        Vector4 q = rgb.r < p.x ? new Vector4(p.x, p.y, p.w, rgb.r) : new Vector4(rgb.r, p.y, p.z, p.x);
        float c = q.x - Mathf.Min(q.w, q.y);
        float h = Mathf.Abs((q.w - q.y) / (6 * c + EPSILON) + q.z);

        return new Vector3(h, c, q.x);
    }
}

public class HSVtoRGB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
