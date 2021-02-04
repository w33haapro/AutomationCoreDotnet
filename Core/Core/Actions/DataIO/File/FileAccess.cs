using OfficeOpenXml;
using System.Data;
using System.IO;
using System.Linq;

public static class FileAccess
{
    public static string ReadText(string fileName)
    {
        return File.ReadAllText(fileName);
    }

    public static DataTable ReadCsv(string filename, bool hasHeader = true)
    {

        DataTable dtCsv = new DataTable();
        string Fulltext;

        using (StreamReader sr = new StreamReader(filename))
        {
            while (!sr.EndOfStream)
            {
                Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                string[] rows = Fulltext.Split('\n'); //split full file text into rows

                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i].EndsWith("\r"))
                    {
                        rows[i] = rows[i].Substring(0, rows[i].Length - 1);
                    }
                }

                var firstRowValues = rows[0].Split(',');



                for (int j = 0; j < firstRowValues.Count(); j++)
                {
                    dtCsv.Columns.Add(hasHeader ? firstRowValues[j] : "Column " + j);
                }

                var firstItemIndex = 0;
                if (hasHeader)
                {
                    firstItemIndex = 1;
                }


                for (int i = firstItemIndex; i < rows.Count(); i++)
                {
                    string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                    {
                        DataRow dr = dtCsv.NewRow();
                        for (int k = 0; k < rowValues.Count(); k++)
                        {
                            dr[k] = rowValues[k].ToString();
                        }
                        dtCsv.Rows.Add(dr); //add other rows  

                    }
                }
            }

        }
        return dtCsv;
    }

    public static string ReadJson(string filename)
    {
        string result = ReadText(filename);
        return result;
    }

    public static DataTable ReadExcel(string path, int worksheetIndex = 0, bool hasHeader = true)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var pck = new ExcelPackage())
        {
            using (var stream = File.OpenRead(path))
            {
                pck.Load(stream);
            }
            ExcelWorksheet ws = pck.Workbook.Worksheets[worksheetIndex];
            DataTable tbl = new DataTable();
            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
            {
                tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            }
            var startRow = hasHeader ? 2 : 1;
            for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
            {
                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                DataRow row = tbl.Rows.Add();
                foreach (var cell in wsRow)
                {
                    row[cell.Start.Column - 1] = cell.Text;
                }
            }
            return tbl;
        }
    }

    public static DataTable ReadExcel(string path, string worksheetIndex, bool hasHeader = true)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var pck = new ExcelPackage())
        {
            using (var stream = File.OpenRead(path))
            {
                pck.Load(stream);
            }
            ExcelWorksheet ws = pck.Workbook.Worksheets[worksheetIndex];
            DataTable tbl = new DataTable();
            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
            {
                tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            }
            var startRow = hasHeader ? 2 : 1;
            for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
            {
                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                DataRow row = tbl.Rows.Add();
                foreach (var cell in wsRow)
                {
                    row[cell.Start.Column - 1] = cell.Text;
                }
            }
            return tbl;
        }
    }
}
