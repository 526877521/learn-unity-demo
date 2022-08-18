﻿using System.Data;
using System.IO;
using ExcelDataReader;
using UnityEngine;

namespace Data.EditorTool
{
    public class ExcelTool
    {
        
        public static void CreateBaseClassWithExcel(string filePath)
        {
            // int columnNum = 0, rowNum = 0;
            // DataRowCollection collect = ReadExcel(filePath, ref columnNum, ref rowNum);
            //
            // string fileName = Path.GetFileNameWithoutExtension(filePath);
            CreateClass.GenerateBaseClassClass(filePath);
        }
        
        // 生产基类
        public static void CreateBaseDataWithExcel(string filePath)
        {
            // int columnNum = 0, rowNum = 0;
            // DataRowCollection collect = ReadExcel(filePath, ref columnNum, ref rowNum);
            //
            // string fileName = Path.GetFileNameWithoutExtension(filePath);
            CreateClass.GenerateBaseClass(filePath);
        }

        /// <summary>
        /// 读取表数据，生成对应的数组
        /// </summary>
        /// <param name="filePath">excel文件全路径</param>
        /// <returns>Item数组</returns>
        public static ItemType[] CreateItemArrayWithExcel(string filePath)
        {
            //获得表数据
            int columnNum = 0, rowNum = 0;
            DataRowCollection collect = ReadExcel(filePath, ref columnNum, ref rowNum);

            //根据excel的定义，第二行开始才是数据
            ItemType[] array = new ItemType[rowNum - 1];
            for (int i = 1; i < rowNum; i++)
            {
                ItemType item = new ItemType();
                //解析每列的数据
                item.itemId = uint.Parse(collect[i][0].ToString());
                item.itemName = collect[i][1].ToString();
                item.itemPrice = uint.Parse(collect[i][2].ToString());
                array[i - 1] = item;
            }

            return array;
        }

        /// <summary>
        /// 读取excel文件内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="columnNum">行数</param>
        /// <param name="rowNum">列数</param>
        /// <returns></returns>
        static DataRowCollection ReadExcel(string filePath, ref int columnNum, ref int rowNum)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet result = excelReader.AsDataSet();
            //Tables[0] 下标0表示excel文件中第一张表的数据
            columnNum = result.Tables[0].Columns.Count;
            rowNum = result.Tables[0].Rows.Count;
            return result.Tables[0].Rows;
        }
    }
}