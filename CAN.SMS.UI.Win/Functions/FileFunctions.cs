using CAN.SMS.Common.Messages;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using CAN.SMS.Common.Enums;
using DevExpress.Export;
using DevExpress.XtraPrinting;

namespace CAN.SMS.UI.Win.Functions
{
    public static class FileFunctions
    {
        public static void FormLocationSave(this string tableName, int left, int top, int width, int height,
            FormWindowState windowState)
        {
            try
            {
                if (!Directory.Exists(Application.StartupPath + @"\Files\"))
                    Directory.CreateDirectory(Application.StartupPath + @"\Files");

                var settings = new XmlWriterSettings { Indent = true };
                var writer = XmlWriter.Create(Application.StartupPath + $@"\Files\{tableName}_location.xml", settings);
                writer.WriteStartDocument();
                writer.WriteComment("Created By Can Ozaytekin");
                writer.WriteStartElement("Table");
                writer.WriteStartElement("Location");
                writer.WriteAttributeString("Left", left.ToString());
                writer.WriteAttributeString("Top", top.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("FormSize");
                if (windowState == FormWindowState.Maximized)
                {
                    writer.WriteAttributeString("Width", "-1");
                    writer.WriteAttributeString("Height", "-1");
                }
                else
                {
                    writer.WriteAttributeString("width", width.ToString());
                    writer.WriteAttributeString("height", height.ToString());
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            catch (Exception e)
            {
                Messages.ErrorMessage(e.Message);
            }
        }

        public static void FormViewLoading(this string tableName, XtraForm frm)
        {
            var list = new List<string>();

            try
            {
                if (File.Exists(Application.StartupPath + $@"\Files\{tableName}_location.xml"))
                {
                    var reader = XmlReader.Create(Application.StartupPath + $@"\Files\{tableName}_location.xml");

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Location")
                        {
                            list.Add(reader.GetAttribute(0));
                            list.Add(reader.GetAttribute(1));
                        }
                        else if (reader.NodeType == XmlNodeType.Element && reader.Name == "FormSize")
                        {
                            list.Add(reader.GetAttribute(0));
                            list.Add(reader.GetAttribute(1));
                        }
                    }

                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (Exception e)
            {
                Messages.ErrorMessage(e.Message);
            }

            if (list.Count <= 0) return;

            frm.Location = new System.Drawing.Point(int.Parse(list[0]), int.Parse(list[1]));

            if (list[2] == "-1" && list[3] == "-1")
                frm.WindowState = FormWindowState.Maximized;
            else
                frm.Size = new Size(int.Parse(list[2]), int.Parse(list[3]));
        }

        public static void TableViewSave(this GridView table, string tableName)
        {
            try
            {
                table.ClearColumnsFilter();

                if (!Directory.Exists(Application.StartupPath + @"\Files\"))
                    Directory.CreateDirectory(Application.StartupPath + @"\Files");

                table.SaveLayoutToXml(Application.StartupPath + $@"\Files\{tableName}.xml");
            }
            catch (Exception e)
            {
                Messages.ErrorMessage(e.Message);
            }
        }

        public static void TableViewLoading(this GridView table, string tableName)
        {
            try
            {
                if (File.Exists(Application.StartupPath + $@"\Files\{tableName}_location.xml"))
                    table.RestoreLayoutFromXml(Application.StartupPath + $@"\Files\{tableName}.xml");
            }
            catch (Exception e)
            {
                Messages.ErrorMessage(e.Message);
            }
        }

        public static void TableExport(this GridView table, FileType fileType, string fileFormat, string excelPageName = null)
        {
            if (Messages.TableExportMessage(fileFormat) != DialogResult.Yes) return;

            if (!Directory.Exists(Application.StartupPath + @"\Temp"))
                Directory.CreateDirectory(Application.StartupPath + @"\Temp");

            var fileName = Guid.NewGuid().ToString();
            var filePath = $@"{Application.StartupPath}\Temp\{fileName}";

            switch (fileType)
            {
                case FileType.ExcelStandart:
                    {
                        var opt = new XlsxExportOptionsEx
                        {
                            ExportType = DevExpress.Export.ExportType.Default,
                            SheetName = excelPageName,
                            TextExportMode = TextExportMode.Text
                        };

                        filePath = filePath + ".Xlsx";
                        table.ExportToXlsx(filePath, opt);
                    }
                    break;
                case FileType.ExcelFormat:
                    {
                        var opt = new XlsxExportOptionsEx
                        {
                            ExportType = DevExpress.Export.ExportType.WYSIWYG,
                            SheetName = excelPageName,
                            TextExportMode = TextExportMode.Text
                        };

                        filePath = filePath + ".Xlsx";
                        table.ExportToXlsx(filePath, opt);
                    }
                    break;
                case FileType.ExcelUnformatted:
                    {
                        var opt = new CsvExportOptionsEx
                        {
                            ExportType = DevExpress.Export.ExportType.WYSIWYG,
                            TextExportMode = TextExportMode.Text
                        };

                        filePath = filePath + ".Csv";
                        table.ExportToCsv(filePath, opt);
                    }
                    break;
                case FileType.WordFile:
                    {
                        filePath = filePath + ".Rtf";
                        table.ExportToRtf(filePath);
                    }
                    break;
                case FileType.PdfFile:
                    {
                        filePath = filePath + ".Pdf";
                        table.ExportToPdf(filePath);
                    }
                    break;
                case FileType.TxtFile:
                    {
                        var opt = new TextExportOptions { TextExportMode = TextExportMode.Text };
                        filePath = filePath + ".Txt";
                        table.ExportToText(filePath, opt);
                    }
                    break;
            }

            if (!File.Exists(filePath))
            {
                Messages.ErrorMessage("File not found.");
                return;
            }

            Process.Start(filePath);
        }
    }
}