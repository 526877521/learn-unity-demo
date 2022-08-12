/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
    public partial class UI_Main : GComponent
    {
        public GComponent m_login_btn;
        public GTextField m_des_tip;
        public const string URL = "ui://fjgrewmxkcnv0";

        public static UI_Main CreateInstance()
        {
            return (UI_Main)UIPackage.CreateObject("Login", "Main");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_login_btn = (GComponent)GetChildAt(2);
            m_des_tip = (GTextField)GetChildAt(3);
        }
    }
}