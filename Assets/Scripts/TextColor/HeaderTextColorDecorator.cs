using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(HeaderTextColorAttribute))]
public class HeaderTextColorDecorator : DecoratorDrawer
{
    private GUIStyle headerStyle;
    private bool initialized;

    private void InitGUIStyle()
    {
        headerStyle = new GUIStyle(GUI.skin.label);
        headerStyle.fontStyle = FontStyle.Bold;
        headerStyle.normal.textColor = ((HeaderTextColorAttribute)attribute).color;
        initialized = true;
    }

    public override float GetHeight()
    {
        /*if (!initialized)
        {
            InitGUIStyle();
        }*/

        return EditorGUIUtility.singleLineHeight * 2;
    }

    public override void OnGUI(Rect position)
    {
        if (!initialized)
        {
            InitGUIStyle();
        }

        HeaderTextColorAttribute attribute = (HeaderTextColorAttribute)this.attribute;
        string headerText = attribute.headerText;

        Rect labelRect = new Rect(position.x, position.y, EditorGUIUtility.labelWidth + 100, 50);
        EditorGUI.LabelField(labelRect, headerText, headerStyle);
    }
}
[CustomPropertyDrawer(typeof(ChangeColorLabelAttribute))]
public class RedLabelDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // Get the color from the attribute
        ChangeColorLabelAttribute changeColorLabelAttribute = (ChangeColorLabelAttribute)attribute;
        Color labelColor = changeColorLabelAttribute.color;

        // Set the color
        GUIStyle coloredLabelStyle = new GUIStyle(EditorStyles.label) { normal = { textColor = labelColor } };
        float originalLabelWidth = EditorGUIUtility.labelWidth;
        EditorGUIUtility.labelWidth = EditorStyles.label.CalcSize(label).x;

        // Draw the colored label
        EditorGUI.LabelField(position, label, coloredLabelStyle);

        // Draw the property without the label
        EditorGUIUtility.labelWidth = originalLabelWidth;
        position.x += EditorGUIUtility.labelWidth;
        position.width -= EditorGUIUtility.labelWidth;
        EditorGUI.PropertyField(position, property, GUIContent.none, true);

        EditorGUI.EndProperty();
    }
}
#endif

public class HeaderTextColorAttribute : PropertyAttribute
{
    public Color color;
    public string headerText;

    public HeaderTextColorAttribute(float r, float g, float b, float a = 1.0f, string headerText = "")
    {
        color = new Color(r, g, b, a);
        this.headerText = headerText;
    }
}
public class ChangeColorLabelAttribute : PropertyAttribute
{
    public Color color;

    public ChangeColorLabelAttribute(float r, float g, float b, float a = 1.0f)
    {
        color = new Color(r, g, b, a);
    }
}
