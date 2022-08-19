using System;
using System.Data;
using System.IO;
using System.Text;
using Data.EditorTool;
using ExcelDataReader;
using UnityEditor;
using UnityEngine;


namespace ExcelTool.EditorTool
{
    public class ExcelToClass
    {
        public void GenerateBaseClass(string filePath)
        {
            try
            {
                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                DataSet result = excelReader.AsDataSet();
                DataTable sheet = result.Tables[0];
                ExcelMiddleData data = new ExcelMiddleData();
                data.Init(sheet, filePath);

                string tempName = Path.GetFileNameWithoutExtension(filePath);
                tempName = tempName.Replace("t_", "");
                Debug.Log("tempName=" + tempName);
                string dataItemClassName = "EDItem_" + tempName;
                string dataTableClassName = "EDTable_" + tempName;

                StringBuilder sbProps = new StringBuilder();
                for (int i = 0; i < data.realColumns.Count; i++)
                {
                    var type = data.types[i];
                    var prop = data.props[i];
                    var noteArray = data.notes[i];

                    if (prop == "id") continue;

                    sbProps.Append("\t/// <summary>\n");
                    for (int j = 0; j < noteArray.Length; j++)
                    {
                        var note = noteArray[j];
                        sbProps.Append("\t/// " + note + "\n");
                    }

                    sbProps.Append("\t/// </summary>\n");
                    sbProps.Append(string.Format("\tpublic {0} {1};\n", type, prop));
                    sbProps.AppendLine();
                }

                string templateTxtUrl = ExcelConfig.ExcelTemplateFilePath;
                Debug.Log("templateTxtUrl="+templateTxtUrl);
                string tempStrFile = AssetDatabase.LoadAssetAtPath<TextAsset>(ExcelConfig.ExcelTemplateFilePath).text;
                Debug.Log("tempStrFile="+tempStrFile);
                tempStrFile = tempStrFile.Replace("{0}", dataItemClassName);
                tempStrFile = tempStrFile.Replace("{1}", dataTableClassName);
                tempStrFile = tempStrFile.Replace("{2}", sbProps.ToString());

                string targetFilePath =
                    ExcelConfig.GenerateCSFilePath + dataTableClassName + ".cs";
                if (!Directory.Exists(ExcelConfig.GetExcelGenerateCSFilePath()))
                {
                    Directory.CreateDirectory(ExcelConfig.GetExcelGenerateCSFilePath());
                }

                Debug.Log("tempStrFile=" + tempStrFile + "targetFilePath=" + targetFilePath);
                SaveFile(tempStrFile, targetFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public  void GenerateBaseAsset(string filePath)
        {
            try
            {
                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                DataSet result = excelReader.AsDataSet();
                DataTable sheet = result.Tables[0];
                ExcelMiddleData data = new ExcelMiddleData();
                data.Init(sheet, filePath);

                string tempName = Path.GetFileNameWithoutExtension(filePath);
                tempName = tempName.Replace("t_", "");
                Debug.Log("tempName=" + tempName);
                string json = data.ToJson(tempName);
                string targetFilePath = ExcelConfig.GetExcelGenerateAssetFilePath() + tempName + ".json";

                if (!Directory.Exists(ExcelConfig.GetExcelGenerateAssetFilePath()))
                {
                    Directory.CreateDirectory(ExcelConfig.GetExcelGenerateAssetFilePath());
                }

                SaveFile(json, targetFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void SaveFile(string str, string filePath)
        {
            if (File.Exists(filePath)) File.Delete(filePath);

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.Write(str);
                }
            }

            Debug.Log("asset create: " + filePath);
            AssetDatabase.Refresh();
        }
    }
}