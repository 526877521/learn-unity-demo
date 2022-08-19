using System.IO;
using UnityEngine;

namespace Data.EditorTool
{
    public class ExcelConfig
    {
        /// <summary>
        /// 存放excel表文件夹的的路径，本例xecel表放在了"Assets/Excels/"当中
        /// </summary>
        public static readonly string execlsFolderPath = Application.dataPath + "/ExcelTool/Excel/";
 
        /// <summary>
        /// 存放Excel转化CS文件的文件夹路径
        /// </summary>
        public static readonly string assetPath = "Assets/ExcelTool/DataAssets/";
        

        /// <summary>
        /// 模板路径
        /// </summary>
        public static readonly string ExcelTemplateFilePath ="Assets/ExcelTool/Template/ExcelDataClassTemplate.txt";

        /// <summary>
        /// 代码生成路径
        /// </summary>
        public static readonly string GenerateCSFilePath = "Assets/ExcelTool/Entity/";

        /// <summary>
        /// asset数据生成路径
        /// </summary>
        public static readonly string ASSET_OUTPUT_PATH =Application.dataPath+ "/ExcelTool/DataAssets/";

        /// <summary>
        /// 属性名行
        /// </summary>
        public const int EXCEL_ROW_INDEX_Prop = 4 - 1;

        /// <summary>
        /// 注释行
        /// </summary>
        public const int EXCEL_ROW_INDEX_Note = 5 - 1;

        /// <summary>
        /// 类型行
        /// </summary>
        public const int EXCEL_ROW_INDEX_Type = 6 - 1;

        /// <summary>
        /// 内容行
        /// </summary>
        public const int EXCEL_ROW_INDEX_Content_Start = 7 - 1;

        /// <summary>
        /// Excel表格路径
        /// </summary>
        /// <returns></returns>
        public static string GetExcelPath()
        {
            
            string excelPath = Directory.CreateDirectory(Application.dataPath).Parent.FullName + "\\Excel\\";
            
            return excelPath;
        }

        /// <summary>
        /// Excel代码完整生成路径
        /// </summary>
        /// <returns></returns>
        public static string GetExcelGenerateCSFilePath()
        {
            string hotfixPath = Application.dataPath.Replace("/Assets", GenerateCSFilePath);
            return hotfixPath;
        }

        /// <summary>
        /// asset数据完整生成路径
        /// </summary>
        /// <returns></returns>
        public static string GetExcelGenerateAssetFilePath()
        {
            string assetGeneratePath = Application.dataPath + ASSET_OUTPUT_PATH;
            assetGeneratePath = assetGeneratePath.Replace("/AssetsAssets", "/Assets");
            return assetGeneratePath;
        }
    }
}