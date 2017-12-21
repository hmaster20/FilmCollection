using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FC.Provider
{
    //public static class Reports
    //{
    //    public static DataSet ReportSource { get; set; }
    //    public static string ReportTitle { get; set; }
    //    public static ArrayList Sections { get; set; } = new ArrayList();
    //    public static ArrayList ReportFields { get; set; } = new ArrayList();
    //    public static ArrayList TotalFields { get; set; } = new ArrayList();
    //    private static Hashtable totalList { get; set; } = new Hashtable();
    //    private static StringBuilder htmlContent { get; set; } = new StringBuilder();
    //    private static string newline { get; set; } = "\n";
    //    private static string gradientStyle { get; set; } = "FILTER: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=BackColor,endColorStr=#ffffff)";
    //    public static string ReportFont { get; set; } = "Arial";
    //    private static int iLevel { get; set; } = 0;
    //    public static bool IncludeTotal { get; set; }

    //    //Chart fields
    //    public static bool IncludeChart { get; set; }
    //    public static string ChartTitle { get; set; }
    //    public static bool ChartShowAtBottom { get; set; }
    //    public static string ChartChangeOnField { get; set; }
    //    public static string ChartValueField { get; set; } = "Count";
    //    public static bool ChartShowBorder { get; set; }
    //    public static string ChartLabelHeader { get; set; } = "Label";
    //    public static string ChartPercentageHeader { get; set; } = "Percentage";
    //    public static string ChartValueHeader { get; set; } = "Value";

    //    //Folder report
    //    private static string fileReport { get; set; }
    //    public static string Getfolder() => fileReport + "_files";


    //    public static DataSet CreateDataSet<T>(List<T> list)
    //    {
    //        //list is nothing or has nothing, return nothing (or add exception handling)
    //        if (list == null || list.Count == 0) { return null; }

    //        //get the type of the first obj in the list
    //        var obj = list[0].GetType();

    //        //now grab all properties
    //        var properties = obj.GetProperties();

    //        //make sure the obj has properties, return nothing (or add exception handling)
    //        if (properties.Length == 0) { return null; }

    //        //it does so create the dataset and table
    //        var dataSet = new DataSet();
    //        var dataTable = new DataTable();

    //        //now build the columns from the properties
    //        var columns = new DataColumn[properties.Length];
    //        for (int i = 0; i < properties.Length; i++)
    //        {
    //            columns[i] = new DataColumn(properties[i].Name, properties[i].PropertyType);
    //        }

    //        //add columns to table
    //        dataTable.Columns.AddRange(columns);

    //        //now add the list values to the table
    //        foreach (var item in list)
    //        {
    //            //create a new row from table
    //            var dataRow = dataTable.NewRow();

    //            //now we have to iterate thru each property of the item and retrieve it's value for the corresponding row's cell
    //            var itemProperties = item.GetType().GetProperties();

    //            for (int i = 0; i < itemProperties.Length; i++)
    //            {
    //                dataRow[i] = itemProperties[i].GetValue(item, null);
    //            }

    //            //now add the populated row to the table
    //            dataTable.Rows.Add(dataRow);
    //        }

    //        //add table to dataset
    //        dataSet.Tables.Add(dataTable);

    //        //return dataset
    //        return dataSet;
    //    }


    //    public static void Generator(RecordCollection rCollection)
    //    {
    //        ReportTitle = "Название отчета";
    //        ReportFont = "Arial";
    //        IncludeTotal = true;

    //        List<Record> filtered = new List<Record>();
    //        rCollection.CombineList.ForEach(r => filtered.AddRange(r.recordList));

    //        ReportSource = CreateDataSet(filtered);

    //        //Create Section
    //        Section release = new Section("Release", "Release: ");
    //        //Create SubSection
    //        Section project = new Section("Project", "ProjectID: ");

    //        //Add the sections to the report
    //        release.SubSection = project;
    //        //reportHTML.Sections.Add(release);
    //        //Add report fields to the report object.
    //        //reportHTML.ReportFields.Add(new Field("TicketNo", "Ticket", 50, ALIGN.RIGHT));
    //        //reportHTML.ReportFields.Add(new Field("CreatedBy", "CreatedBy", 150));
    //        //reportHTML.ReportFields.Add(new Field("AssignedTo", "AssignedTo"));
    //        //reportHTML.ReportFields.Add(new Field("Release", "Release", 200));
    //        //reportHTML.ReportFields.Add(new Field("Project", "Project", 150, ALIGN.RIGHT));


    //        //foreach (object obj in chkLstFields.CheckedItems)
    //        //{
    //        //    Field field = (Field)fieldProps[obj.ToString()];
    //        //    report.ReportFields.Add(field);
    //        //    if (field.isTotalField)
    //        //        report.TotalFields.Add(field.FieldName);
    //        //}

    //        //var obj = filtered[0].GetType();
    //        //var properties = obj.GetProperties();
    //        //for (int i = 0; i < properties.Length; i++)
    //        //{
    //        //    if (properties[i].Name == "Visible" || properties[i].Name == "combineLink")
    //        //    {
    //        //        continue;
    //        //    }
    //        //    //reportHTML.ReportFields.Add(new Field(properties[i].Name, properties[i].PropertyType.ToString(), 50, ALIGN.RIGHT));
    //        //    reportHTML.ReportFields.Add(new Field(properties[i].Name, properties[i].Name, 50, ALIGN.RIGHT));
    //        //}

    //        ReportFields.Add(new Field("mName", "Название", 20, ALIGN.RIGHT));
    //        //ReportFields.Add(new Field("Name", "Название", 20, ALIGN.RIGHT));
    //        ReportFields.Add(new Field("FileName", "Название файла", 20, ALIGN.RIGHT));
    //        //ReportFields.Add(new Field("DirName", "Каталог", 20, ALIGN.RIGHT));
    //        ReportFields.Add(new Field("Path", "Полный путь", 50, ALIGN.RIGHT));
    //        //ReportFields.Add(new Field("mName", "mName", 20, ALIGN.RIGHT));
    //        ReportFields.Add(new Field("mDescription", "Описание", 170, ALIGN.LEFT));
    //        ReportFields.Add(new Field("mCountry", "Страна", 20, ALIGN.RIGHT));
    //        ReportFields.Add(new Field("mGenre", "Жанр", 20, ALIGN.RIGHT));
    //        ReportFields.Add(new Field("mCategory", "Категория", 20, ALIGN.RIGHT));
    //        ReportFields.Add(new Field("TimeString", "TimeString", 20, ALIGN.RIGHT));


    //        //Section section = null;
    //        //foreach (object obj in lstGroupBy.Items)
    //        //{
    //        //    if (report.Sections.Count == 0)
    //        //    {
    //        //        section = (Section)sectionProps[obj.ToString()];
    //        //        report.Sections.Add(section);
    //        //    }
    //        //    else
    //        //    {
    //        //        section.SubSection = (Section)sectionProps[obj.ToString()];
    //        //        section = section.SubSection;
    //        //    }
    //        //}

    //        using (SaveFileDialog fileDialog = new SaveFileDialog())
    //        {
    //            fileDialog.InitialDirectory = Environment.SpecialFolder.Desktop.ToString(); //Path.Combine(RCollection.Options.Source, GetNode());
    //            fileDialog.Filter = "Web-страница (*.htm)|*.htm";
    //            fileDialog.Title = "Выберите файл:";
    //            fileDialog.FileName = "Отчет";
    //            fileDialog.RestoreDirectory = true;

    //            if (fileDialog.ShowDialog() == DialogResult.OK)
    //            {
    //                if (File.Exists(fileDialog.FileName))
    //                {
    //                    try
    //                    {
    //                        File.Delete(fileDialog.FileName);
    //                    }
    //                    catch (Exception ex) { Logs.Log("Невозможно удалить файл отчета", ex); }
    //                }

    //                string currentFolder = fileDialog.FileName.Substring(0, fileDialog.FileName.LastIndexOf('\\'));

    //                string currentFolder2 = System.IO.Path.GetDirectoryName(fileDialog.FileName);
    //                FileInfo fileInfo = new FileInfo(fileDialog.FileName);
    //                string name = fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf(fileInfo.Extension));

    //                fileReport = fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf(fileInfo.Extension));

    //                string targetDir = Path.Combine(Path.GetDirectoryName(fileDialog.FileName), Getfolder());

    //                if (!Directory.Exists(targetDir))
    //                {
    //                    Directory.CreateDirectory(targetDir);
    //                }

    //                string sdfg = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
    //                string webfiles = sdfg + "\\Resources\\web";


    //                foreach (var file in Directory.GetFiles(webfiles))
    //                    File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)), true);

    //                SaveReport(fileDialog.FileName);
    //                System.Diagnostics.Process.Start(fileDialog.FileName);
    //            }
    //        }
    //    }







    //    #region Methods
    //    /// <summary>
    //    /// Generates the HTML Content for the given ReportSource.
    //    /// </summary>
    //    /// <returns>HTML String</returns>
    //    public static string GenerateReport()
    //    {
    //        foreach (Field fld in ReportFields)
    //        {
    //            if (!TotalFields.Contains(fld.FieldName) && fld.isTotalField)
    //            {
    //                TotalFields.Add(fld.FieldName);
    //            }
    //        }
    //        WriteTitle();
    //        WriteSections();
    //        //WriteFooter();
    //        return htmlContent.ToString();
    //    }

    //    /// <summary>Создание и сохранение отчета в файл.</summary>
    //    /// <param name="fileName">HTML Report file name</param>
    //    /// <returns>On success returns true</returns>
    //    public static bool SaveReport(string fileName)
    //    {
    //        try
    //        {
    //            GenerateReport();
    //            StreamWriter sw = new StreamWriter(fileName);
    //            sw.Write(htmlContent.ToString());
    //            sw.Flush();
    //            sw.Close();
    //            return true;
    //        }
    //        catch (Exception exp)
    //        {
    //            System.Diagnostics.Debug.WriteLine(exp.Message);
    //            return false;
    //        }
    //    }

    //    /// <summary>
    //    /// Writes CSS and HTML title.
    //    /// </summary>
    //    private static void WriteTitle()
    //    {
    //        //htmlContent.Append("<!DOCTYPE html PUBLIC ' -//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" + newline);
    //        htmlContent.Append("<html xmlns='http://www.w3.org/1999/xhtml' lang='ru-RU' xmlns:og='http://ogp.me/ns#' xmlns:fb='http://ogp.me/ns/fb#' xmlns:article='http://ogp.me/ns/article#'>" + newline);
    //        htmlContent.Append("<head profile='http://gmpg.org/xfn/11'>" + newline);
    //        htmlContent.Append("<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'/>" + newline);
    //        htmlContent.Append("<title>Report - " + ReportTitle + "</title>" + newline);
    //        htmlContent.Append("<meta name='author' content='Бирюков Сергей'/>" + newline);
    //        htmlContent.Append("<meta name='copyright' content='Бирюков Сергей'/>" + newline);

    //        //htmlContent.Append("<link rel='stylesheet' href='files/style.css' type='text/css' id='' media='print, projection, screen'>" + newline);
    //        //htmlContent.Append("<script type='text/javascript' src='files/jquery-latest.js'></script>" + newline);
    //        //htmlContent.Append("<script type='text/javascript' src='files /jquery.js'></script>" + newline);

    //        htmlContent.Append("<link rel='stylesheet' href='" + Getfolder() + "/style.css' type='text/css' id='' media='print, projection, screen'>" + newline);
    //        htmlContent.Append("<script type='text/javascript' src='" + Getfolder() + "/jquery-latest.js'></script>" + newline);
    //        htmlContent.Append("<script type='text/javascript' src='" + Getfolder() + "/jquery.js'></script>" + newline);
    //        htmlContent.Append("<script type='text/javascript' id='js'>$(document).ready(function() {$('table').tablesorter({sortList: [[0, 0],[2,0]]});}); </script>" + newline);

    //        //htmlContent.Append("<style>" + newline);
    //        //htmlContent.Append(" .TableStyle { border-collapse: collapse } " + newline);
    //        //htmlContent.Append(" .TitleStyle { font-family: " + ReportFont + "; font-size:15pt } " + newline);
    //        //htmlContent.Append(" .SectionHeader {font-family: " + ReportFont + "; font-size:10pt } " + newline);
    //        //htmlContent.Append(" .DetailHeader {font-family: " + ReportFont + "; font-size:9pt } " + newline);
    //        //htmlContent.Append(" .DetailData  {font-family: " + ReportFont + "; font-size:9pt } " + newline);
    //        //htmlContent.Append(" .ColumnHeaderStyle  {font-family: " + ReportFont + "; font-size:9pt; border-style:outset; border-width:1} " + newline);
    //        //htmlContent.Append("</style>" + newline);
    //        htmlContent.Append("</head>" + newline);
    //        //htmlContent.Append("<body TOPMARGIN=0 LEFTMARGIN=0 RIGHTMARGIN=0 BOTTOMMARGIN=0>" + newline);
    //        htmlContent.Append("<body>" + newline);
    //        htmlContent.Append("<TABLE Width='100%' style='FILTER: progid:DXImageTransform.Microsoft.Gradient(gradientType=1,startColorStr=#a9d4ff,endColorStr=#ffffff)' Cellpadding=5><TR><TD>");
    //        htmlContent.Append("<font face='" + ReportFont + "' size=6>" + ReportTitle + "</font>");
    //        htmlContent.Append("</TD></TR></TABLE>" + newline);
    //    }


    //    private static void WriteSections()//Заполняет содержимое таблицы
    //    {
    //        if (Sections.Count == 0)
    //        {
    //            Section dummySection = new Section();
    //            dummySection.Level = 5;
    //            dummySection.ChartChangeOnField = ChartChangeOnField;
    //            dummySection.ChartLabelHeader = ChartLabelHeader;
    //            dummySection.ChartPercentageHeader = ChartPercentageHeader;
    //            dummySection.ChartShowAtBottom = ChartShowAtBottom;
    //            dummySection.ChartShowBorder = ChartShowAtBottom;
    //            dummySection.ChartTitle = ChartTitle;
    //            dummySection.ChartValueField = ChartValueField;
    //            dummySection.ChartValueHeader = ChartValueHeader;
    //            dummySection.IncludeChart = IncludeChart;
    //            //htmlContent.Append("<table Width='100%' class='TableStyle' cellspacing=0 cellpadding=5 border=0>" + newline);
    //            htmlContent.Append("<table class='tablesorter' cellspacing='1'>" + newline);
    //            if (IncludeChart && !ChartShowAtBottom)
    //                GenerateBarChart("", dummySection);
    //            Hashtable total = WriteSectionDetail(null, "");
    //            if (IncludeTotal)
    //            {
    //                dummySection.IncludeTotal = true;
    //                //WriteSectionFooter(dummySection, total);
    //            }
    //            if (IncludeChart && ChartShowAtBottom)
    //                GenerateBarChart("", dummySection);
    //            htmlContent.Append("</tbody></table></body></html>");
    //        }
    //        foreach (Section section in Sections)
    //        {
    //            iLevel = 0;
    //            htmlContent.Append("<table Width='100%' class='TableStyle'  cellspacing=0 cellpadding=5 border=0>" + newline);
    //            RecurseSections(section, "");
    //            htmlContent.Append("</table></body></html>");
    //        }
    //    }

    //    /// <summary>
    //    /// Writes the section header information.
    //    /// </summary>
    //    /// <param name="section">The section details as Section object</param>
    //    /// <param name="sectionValue">section group field data</param>
    //    private static void WriteSectionHeader(Section section, string sectionValue)
    //    {
    //        string bg = section.backColor;
    //        string style = " style=\"font-family: " + ReportFont + "; font-weight:bold; font-size:";
    //        style += getFontSize(section.Level);
    //        if (section.GradientBackground)
    //            style += "; " + gradientStyle.Replace("BackColor", bg) + "\"";
    //        else style += "\" bgcolor='" + bg + "' ";

    //        htmlContent.Append("<TR><TD colspan='" + ReportFields.Count + "' " + style + " >");
    //        htmlContent.Append(section.TitlePrefix + sectionValue);
    //        htmlContent.Append("</TD></TR>" + newline);
    //    }

    //    /// <summary>
    //    /// Method to write Chart and Section data information
    //    /// </summary>
    //    /// <param name="section">the section details</param>
    //    /// <param name="criteria">the section selection criteria</param>
    //    private static Hashtable WriteSectionDetail(Section section, string criteria)
    //    {
    //        Hashtable totalArray = new Hashtable();
    //        totalArray = PrepareData(totalArray);
    //        if (section == null)
    //        {
    //            section = new Section();
    //        }
    //        try
    //        {
    //            //Draw DetailHeader
    //            htmlContent.Append("<thead>" + newline);
    //            htmlContent.Append("<TR>" + newline);
    //            string cellParams = "";
    //            foreach (Field field in ReportFields)
    //            {
    //                cellParams = " bgcolor='" + field.headerBackColor + "' ";
    //                if (field.Width != 0)
    //                    cellParams += " WIDTH=" + field.Width + " ";
    //                cellParams += " ALIGN='" + field.alignment + "' ";
    //                //htmlContent.Append("  <TD " + cellParams + " class='ColumnHeaderStyle'><b>" + field.HeaderName + "</b></TD>" + newline);
    //                htmlContent.Append("  <th class='header'>" + field.HeaderName + "</th>" + newline);
    //            }
    //            htmlContent.Append("</TR>" + newline);
    //            htmlContent.Append("</thead>" + newline);
    //            htmlContent.Append("<tbody>" + newline);

    //            //Draw Data
    //            if (criteria == null || criteria.Trim() == "")
    //                criteria = "";
    //            else
    //                criteria = criteria.Substring(3);


    //            foreach (DataRow dr in ReportSource.Tables[0].Select(criteria))
    //            {
    //                htmlContent.Append("<TR>" + newline);
    //                foreach (Field field in ReportFields)
    //                {
    //                    cellParams = " bgcolor='" + field.backColor + "' ";
    //                    if (field.Width != 0)
    //                        cellParams += " WIDTH=" + field.Width + " ";
    //                    //if total field, by default set to RIGHT align.
    //                    if (TotalFields.Contains(field.FieldName))
    //                        cellParams += " align='right' ";
    //                    cellParams += " ALIGN='" + field.alignment + "' ";
    //                    htmlContent.Append("  <TD " + cellParams + " VALIGN='top' class='DetailData'>" + dr[field.FieldName] + "</TD>" + newline);
    //                }
    //                htmlContent.Append("</TR>" + newline);
    //                try
    //                {
    //                    foreach (object totalField in TotalFields)
    //                    {
    //                        totalArray[totalField.ToString()] = float.Parse(totalArray[totalField.ToString()].ToString()) +
    //                            float.Parse(dr[totalField.ToString()].ToString());
    //                    }
    //                }
    //                catch (Exception)
    //                {
    //                    ;//to-do: show error message at total field
    //                }
    //            }
    //        }
    //        catch (Exception err)
    //        {
    //            htmlContent.Append("<p align=CENTER><b>Unable to generate report.<br>" + err.Message + "</b></p>");
    //        }
    //        return totalArray;
    //    }

    //    /// <summary>
    //    /// Method to write section footer information.
    //    /// </summary>
    //    /// <param name="section">The section details</param></param>
    //    private static void WriteSectionFooter(Section section, Hashtable totalArray)
    //    {
    //        string cellParams = "";
    //        //Include Total row if specified.
    //        if (section.IncludeTotal)
    //        {
    //            htmlContent.Append("<TR>" + newline);
    //            foreach (Field field in ReportFields)
    //            {
    //                cellParams = "";
    //                if (field.Width != 0)
    //                    cellParams += " WIDTH=" + field.Width + " ";
    //                cellParams += " style=\"font-family: " + ReportFont + "; font-size:";
    //                cellParams += getFontSize(section.Level + 1) + "; border-style:outline; border-width:1 \" ";
    //                if (totalArray.Contains(field.FieldName))
    //                {
    //                    htmlContent.Append("  <TD " + cellParams + " align='right'><u>Total: " + totalArray[field.FieldName].ToString() + "</u></TD> " + newline);
    //                }
    //                else
    //                {
    //                    htmlContent.Append("  <TD " + cellParams + ">&nbsp;</TD>" + newline);
    //                }
    //            }
    //            htmlContent.Append("</TR>");
    //        }
    //    }

    //    /// <summary>
    //    /// Writes the HTML closing tags
    //    /// </summary>
    //    private static void WriteFooter()
    //    {
    //        htmlContent.Append("<BR>");
    //    }

    //    /// <summary>
    //    /// A recursive funtion to write all the section headers, details and footer content.
    //    /// </summary>
    //    /// <param name="section">the section details</param>
    //    /// <param name="criteria">section data selection criteria</param>
    //    private static Hashtable RecurseSections(Section section, string criteria)
    //    {
    //        iLevel++;
    //        section.Level = iLevel;
    //        ArrayList result = GetDistinctValues(ReportSource, section.GroupBy, criteria);
    //        Hashtable ht = new Hashtable();
    //        PrepareData(ht);
    //        foreach (object obj in result)
    //        {
    //            Hashtable sectionTotal = new Hashtable();
    //            PrepareData(sectionTotal);
    //            //Construct critiera string to select data for the current section
    //            string tcriteria = criteria + "and " + section.GroupBy + "='" + obj.ToString().Replace("'", "''") + "' ";
    //            WriteSectionHeader(section, obj.ToString());
    //            //If user not specified to display chart at bottom of the section
    //            if (section.IncludeChart && !section.ChartShowAtBottom && !section.isChartCreated)
    //                GenerateBarChart(tcriteria, section);
    //            if (section.SubSection != null)
    //            {
    //                sectionTotal = RecurseSections(section.SubSection, tcriteria);
    //                iLevel--;
    //            }
    //            else
    //            {
    //                sectionTotal = WriteSectionDetail(section, tcriteria);
    //                ht = AccumulateTotal(ht, sectionTotal);
    //            }
    //            //If user specified to display chart at bottom of the section
    //            WriteSectionFooter(section, sectionTotal);
    //            if (section.IncludeChart && section.ChartShowAtBottom && !section.isChartCreated)
    //                GenerateBarChart(tcriteria, section);
    //            section.isChartCreated = false;
    //        }
    //        if (section.Level < 2)
    //            htmlContent.Append("<TR><TD colspan='" + ReportFields.Count + "'>&nbsp;</TD></TR>");

    //        return ht;
    //    }



    //    /// <summary>
    //    /// Method to generate BarChart
    //    /// </summary>
    //    /// <param name="criteria">Section data selection criteria</param>
    //    /// <param name="changeOnField">Y-Axis data field</param>
    //    /// <param name="valueField">X-Axis data field (Send "count" as value for reporting record count)</param>
    //    /// <param name="showBorder">Enable or disable chart border</param>
    //    private static void GenerateBarChart(string criteria, Section section)
    //    {
    //        string changeOnField = section.ChartChangeOnField;
    //        string valueField = section.ChartValueField;
    //        bool showBorder = section.ChartShowBorder;
    //        section.isChartCreated = true;
    //        string[] colors = { "#ff0000", "#ffff00", "#ff00ff", "#00ff00", "#00ffff", "#0000ff", "#ff0f0f", "#f0f000", "#ff00f0", "#0f00f0" };
    //        htmlContent.Append("<TR><TD colspan='" + ReportFields.Count + "' align=CENTER>" + newline);
    //        htmlContent.Append("<!--- Chart Table starts here -->" + newline);
    //        if (showBorder)
    //        {
    //            htmlContent.Append("<TABLE cellpadding=4 cellspacing=1 border=0 bgcolor='#f5f5f5' width=550> ");
    //        }
    //        else
    //        {
    //            htmlContent.Append("<TABLE border=0 cellspacing=5 width=550>");
    //        }
    //        if (criteria.ToUpper().StartsWith(" AND "))
    //        {
    //            criteria = criteria.Substring(3);
    //        }
    //        try
    //        {
    //            ArrayList result = GetDistinctValuesForChart(ReportSource, criteria, changeOnField, valueField);
    //            ArrayList labels = (ArrayList)result[0];
    //            ArrayList values = (ArrayList)result[1];
    //            float total = 0;
    //            foreach (Object obj in values)
    //            {
    //                total += float.Parse(obj.ToString());
    //            }
    //            int ChartWidth = 300;

    //            string barTitle = "<TR><TD class='DetailHeader' colspan=3 align='CENTER' width=550><B>ChartTitle</B></TD></TR>";
    //            htmlContent.Append(barTitle.Replace("ChartTitle", section.ChartTitle) + newline);

    //            string barTemplate = "<TR><TD Width=150 class='DetailData' align='right'>Label</TD>" + newline;
    //            barTemplate += " <TD  class='DetailData' Width=" + (ChartWidth + 25) + ">" + newline;
    //            barTemplate += "    <TABLE cellpadding=0 cellspacing=0 HEIGHT='20' WIDTH=" + ChartWidth + " class='TableStyle'>" + newline;
    //            barTemplate += "       <TR>" + newline;
    //            barTemplate += "          <TD Width=ChartWidth>" + newline;
    //            barTemplate += "             <TABLE class='TableStyle' HEIGHT='20' Width=ChartTWidth border=NOTZERO>" + newline;
    //            barTemplate += "                <TR>" + newline;
    //            barTemplate += "                   <TD Width=ChartWidth bgcolor='BackColor' Width=ChartWidth style=\"FILTER: progid:DXImageTransform.Microsoft.Gradient(gradientType=0,startColorStr=BackColor,endColorStr=#ffffff); \"></TD>" + newline;
    //            barTemplate += "                </TR>" + newline;
    //            barTemplate += "             </TABLE>" + newline;
    //            barTemplate += "          </TD>" + newline;
    //            barTemplate += "          <TD class='DetailData'>&nbsp;Percentage</TD>" + newline;
    //            barTemplate += "       </TR>" + newline;
    //            barTemplate += "    </TABLE>";
    //            barTemplate += "</TD><TD Width=70 class='DetailData'>Value</TD></TR>";

    //            string barHTemplate = "<TR>" + newline;
    //            barHTemplate += " <TD Width=150  class='DetailData' align='right' bgColor='#e5e5e5'>Label</TD>" + newline;
    //            barHTemplate += " <TD  bgColor='#e5e5e5' class='DetailData' Width=" + (ChartWidth + 25) + ">";
    //            barHTemplate += "Percentage</TD>" + newline;
    //            barHTemplate += " <TD Width=25  class='DetailData' bgColor='#e5e5e5'>Value</TD></TR>";
    //            barHTemplate = barHTemplate.Replace("Label", section.ChartLabelHeader);
    //            barHTemplate = barHTemplate.Replace("Percentage", section.ChartPercentageHeader);
    //            barHTemplate = barHTemplate.Replace("Value", section.ChartValueHeader);
    //            htmlContent.Append(barHTemplate + newline);

    //            string temp;
    //            float width = 0;
    //            float val = 0;
    //            float percent = 0;
    //            int cntColor = 0;
    //            for (int i = 0; i < labels.Count; i++)
    //            {
    //                temp = barTemplate;
    //                val = float.Parse(values[i].ToString());
    //                width = float.Parse(values[i].ToString()) * ChartWidth / total;
    //                percent = float.Parse(values[i].ToString()) * 100 / total;

    //                temp = temp.Replace("Label", labels[i].ToString());
    //                if (percent == 0.0)
    //                {
    //                    temp = temp.Replace("BackColor", "#f5f5f5");
    //                    temp = temp.Replace("NOTZERO", "0");
    //                }
    //                else
    //                {
    //                    temp = temp.Replace("BackColor", colors[cntColor]);
    //                    temp = temp.Replace("NOTZERO", "1");
    //                }
    //                temp = temp.Replace("ChartTWidth", Decimal.Round((Decimal)(width + 2), 0).ToString());
    //                temp = temp.Replace("ChartWidth", Decimal.Round((Decimal)width, 0).ToString());
    //                temp = temp.Replace("Value", val.ToString());
    //                temp = temp.Replace("Percentage", Decimal.Round((decimal)percent, 2).ToString() + "%");

    //                htmlContent.Append(temp + newline);
    //                cntColor++;
    //                if (cntColor == 10)
    //                    cntColor = 0;
    //            }
    //        }
    //        catch (Exception err)
    //        {
    //            htmlContent.Append("<TR><TD valign=MIDDLE align=CENTER><b>Unable to Generate Chart.<br>" + err.Message + "</b></TD></TR>");
    //        }
    //        htmlContent.Append("</TABLE>" + newline);
    //        htmlContent.Append("<!--- Chart Table ends here -->");
    //        htmlContent.Append("</TD></TR>");
    //    }


    //    /// <summary>
    //    /// Method to get distinct values for given Column name from the dataset for generating Chart.
    //    /// </summary>
    //    /// <param name="dataSet">report source dataset</param>
    //    /// <param name="criteria">data selection criteria</param>
    //    /// <param name="changeOnField">Column name</param>
    //    /// <param name="valueField">Column name</param>
    //    /// <returns>List of distinct labels and values</returns>
    //    private static ArrayList GetDistinctValuesForChart(DataSet dataSet, string criteria, string changeOnField, string valueField)
    //    {
    //        ArrayList result = new ArrayList();
    //        ArrayList distinctValues = new ArrayList();
    //        if (criteria == null || criteria.Trim() == "")
    //        {
    //            criteria = "";
    //        }
    //        else
    //        {
    //            criteria = criteria.Substring(3);
    //        }
    //        foreach (DataRow dr in dataSet.Tables[0].Select(criteria))
    //        {
    //            if (!distinctValues.Contains(dr[changeOnField].ToString()))
    //            {
    //                distinctValues.Add(dr[changeOnField].ToString());
    //            }
    //        }
    //        ArrayList totalValues = new ArrayList();
    //        if (criteria.Trim() != "")
    //            criteria += " and ";
    //        foreach (object obj in distinctValues)
    //        {
    //            DataRow[] rows = ReportSource.Tables[0].Select(criteria + changeOnField + "='" + obj.ToString().Replace("'", "''") + "' ");
    //            if (valueField.Trim().ToUpper() == "COUNT")
    //            {
    //                totalValues.Add(rows.Length.ToString());
    //            }
    //            else
    //            {
    //                float sum = 0;
    //                foreach (DataRow row in rows)
    //                    sum += float.Parse(row[valueField].ToString());
    //                totalValues.Add(sum.ToString());
    //            }
    //        }
    //        result.Add(distinctValues);
    //        result.Add(totalValues);
    //        return result;
    //    }


    //    /// <summary>
    //    /// Method to get distinct values for the column in the report source dataset
    //    /// </summary>
    //    /// <param name="dataSet">report source dataset</param>
    //    /// <param name="columnName">Column name</param>
    //    /// <param name="criteria">Data selection criteria</param>
    //    /// <returns>List of distinct values</returns>
    //    private static ArrayList GetDistinctValues(DataSet dataSet, string columnName, string criteria)
    //    {
    //        ArrayList distinctValues = new ArrayList();
    //        if (criteria == null || criteria.Trim() == "")
    //        {
    //            criteria = "";
    //        }
    //        else
    //        {
    //            criteria = criteria.Substring(3);
    //        }
    //        foreach (DataRow dr in dataSet.Tables[0].Select(criteria))
    //        {
    //            if (!distinctValues.Contains(dr[columnName].ToString()))
    //            {
    //                distinctValues.Add(dr[columnName].ToString());
    //            }
    //        }
    //        return distinctValues;
    //    }


    //    private static Hashtable PrepareData(Hashtable totalArray)
    //    {
    //        foreach (object obj in TotalFields)
    //        {
    //            if (!totalArray.Contains(obj.ToString()))
    //            {
    //                totalArray.Add(obj.ToString(), 0.0F);
    //            }
    //        }
    //        return totalArray;
    //    }

    //    private static Hashtable AccumulateTotal(Hashtable totalTable1, Hashtable totalTable2)
    //    {
    //        foreach (object totalField in TotalFields)
    //        {
    //            totalTable1[totalField.ToString()] = float.Parse(totalTable1[totalField.ToString()].ToString()) +
    //                float.Parse(totalTable2[totalField.ToString()].ToString());
    //        }
    //        return totalTable1;
    //    }

    //    private static string getFontSize(int level)
    //    {
    //        string fontSize = "";
    //        switch (level)
    //        {
    //            case 1:
    //                fontSize = "14pt";
    //                break;
    //            case 2:
    //                fontSize = "12pt";
    //                break;
    //            case 3:
    //                fontSize = "10pt";
    //                break;
    //            default:
    //                fontSize = "9pt";
    //                break;
    //        }
    //        return fontSize;
    //    }
    //    #endregion

    //}


    ///// <summary>
    ///// Class to hold Report section details
    ///// </summary>
    //public class Section
    //{
    //    public string GroupBy;
    //    public string TitlePrefix;
    //    public bool IncludeFooter;
    //    public bool GradientBackground;

    //    public bool IncludeTotal;
    //    public Section SubSection;
    //    /// <summary>
    //    /// HTML Color code as string
    //    /// </summary>
    //    internal string backColor;
    //    internal Color cBackColor;
    //    internal int Level;
    //    internal bool isChartCreated;

    //    public bool IncludeChart;
    //    public string ChartTitle;
    //    public bool ChartShowAtBottom;
    //    public string ChartChangeOnField;
    //    public string ChartValueField = "Count";
    //    public bool ChartShowBorder;
    //    public string ChartLabelHeader = "Label";
    //    public string ChartPercentageHeader = "Percentage";
    //    public string ChartValueHeader = "Value";

    //    public Color BackColor
    //    {
    //        set { backColor = Util.GetHTMLColorString(value); cBackColor = value; }
    //        get { return cBackColor; }
    //    }

    //    public Section()
    //    {
    //        SubSection = null;
    //        BackColor = Color.FromArgb(240, 240, 240);
    //        ChartValueField = "Count";
    //        GradientBackground = false;
    //        ChartTitle = "&nbsp;";
    //    }

    //    public Section(string groupBy, string titlePrefix)
    //    {
    //        GroupBy = groupBy;
    //        TitlePrefix = titlePrefix;
    //        SubSection = null;
    //        BackColor = Color.FromArgb(240, 240, 240);
    //        ChartValueField = "Count";
    //        GradientBackground = false;
    //        ChartTitle = "&nbsp;";
    //    }

    //    public Section(string groupBy, string titlePrefix, Color bgcolor)
    //    {
    //        GroupBy = groupBy;
    //        TitlePrefix = titlePrefix;
    //        SubSection = null;
    //        BackColor = bgcolor;
    //        ChartValueField = "Count";
    //        GradientBackground = false;
    //        ChartTitle = "&nbsp;";
    //    }
    //}

    ///// <summary>
    ///// Class to hold Report field details
    ///// </summary>
    //public class Field
    //{
    //    public string FieldName;
    //    public string HeaderName;
    //    /// <summary>
    //    /// HTML Color code as string
    //    /// </summary>
    //    internal string backColor;
    //    internal Color cBackColor;
    //    /// <summary>
    //    /// HTML Color code as string
    //    /// </summary>
    //    internal string headerBackColor;
    //    internal Color cHeaderBackColor;
    //    public int Width;
    //    public bool isTotalField = false;
    //    internal string alignment = "LEFT";

    //    /// <summary>
    //    /// Gets or sets field alignment of type ALIGN
    //    /// </summary>
    //    public ALIGN Alignment
    //    {
    //        set
    //        {
    //            switch (value)
    //            {
    //                case ALIGN.LEFT: alignment = "LEFT"; break;
    //                case ALIGN.RIGHT: alignment = "RIGHT"; break;
    //                case ALIGN.CENTER: alignment = "CENTER"; break;
    //                default: alignment = "LEFT"; break;
    //            }
    //        }
    //        get
    //        {
    //            switch (alignment)
    //            {
    //                case "LEFT": return ALIGN.LEFT;
    //                case "RIGHT": return ALIGN.RIGHT;
    //                case "CENTER": return ALIGN.CENTER;
    //                default: return ALIGN.LEFT;
    //            }
    //        }
    //    }


    //    public Color BackColor
    //    {
    //        set { backColor = Util.GetHTMLColorString(value); cBackColor = value; }
    //        get { return cBackColor; }
    //    }

    //    public Color HeaderBackColor
    //    {
    //        set { headerBackColor = Util.GetHTMLColorString(value); cHeaderBackColor = value; }
    //        get { return cHeaderBackColor; }
    //    }

    //    public Field()
    //    {
    //        FieldName = "";
    //        HeaderName = "Column Header";
    //        BackColor = Color.White;
    //        Width = 0;
    //        HeaderBackColor = Color.White;
    //    }

    //    public Field(string fieldName, string headerName)
    //    {
    //        FieldName = fieldName;
    //        HeaderName = headerName;
    //        BackColor = Color.White;
    //        Width = 0;
    //        HeaderBackColor = Color.White;
    //    }

    //    public Field(string fieldName, string headerName, int width)
    //    {
    //        FieldName = fieldName;
    //        HeaderName = headerName;
    //        BackColor = Color.White;
    //        Width = width;
    //        HeaderBackColor = Color.White;
    //    }

    //    public Field(string fieldName, string headerName, int width, Color bgcolor)
    //    {
    //        FieldName = fieldName;
    //        HeaderName = headerName;
    //        BackColor = Color.White;
    //        Width = width;
    //        BackColor = bgcolor;
    //        HeaderBackColor = Color.White;
    //    }

    //    public Field(string fieldName, string headerName, int width, ALIGN TextAlignment)
    //    {
    //        FieldName = fieldName;
    //        HeaderName = headerName;
    //        BackColor = Color.White;
    //        Width = width;
    //        BackColor = Color.White;
    //        HeaderBackColor = Color.White;
    //        Alignment = TextAlignment;
    //    }

    //    public Field(string fieldName, string headerName, int width, Color bgcolor, Color headerBgColor)
    //    {
    //        FieldName = fieldName;
    //        HeaderName = headerName;
    //        Width = width;
    //        BackColor = bgcolor;
    //        HeaderBackColor = headerBgColor;
    //    }

    //    public Field(string fieldName, string headerName, Color bgcolor, Color headerBgColor)
    //    {
    //        FieldName = fieldName;
    //        HeaderName = headerName;
    //        Width = 0;
    //        BackColor = bgcolor;
    //        HeaderBackColor = headerBgColor;
    //    }

    //    public Field(string fieldName, string headerName, Color headerBgColor)
    //    {
    //        FieldName = fieldName;
    //        HeaderName = headerName;
    //        Width = 0;
    //        BackColor = Color.White;
    //        HeaderBackColor = headerBgColor;
    //    }
    //}

    //public enum ALIGN
    //{
    //    LEFT = 0,
    //    RIGHT,
    //    CENTER
    //}

    //internal class Util
    //{
    //    public static string GetHTMLColorString(Color color)
    //    {
    //        if (color.IsNamedColor)
    //            return color.Name;
    //        else
    //            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
    //    }
    //}
}
