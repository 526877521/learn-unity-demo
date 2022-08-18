using UnityEngine;

namespace Data.EditorTool
{
    public class ExcelConfig
    {
        /// <summary>
        /// 存放excel表文件夹的的路径，本例xecel表放在了"Assets/Excels/"当中
        /// </summary>
        public static readonly string excelsFolderPath = Application.dataPath + "/Data/Excels/";
        public static readonly string newExcelsFolderPath = Application.dataPath + "/Data/Excel/";
 
        /// <summary>
        /// 存放Excel转化CS文件的文件夹路径
        /// </summary>
        public static readonly string assetPath = "Assets/Resources/DataAssets/";
      
    }
}