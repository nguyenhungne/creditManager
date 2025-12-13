using System.IO;
using System.Text;
using System.Windows.Forms;

namespace N9.Helpers
{
    public static class ExcelExporter
    {
        public static void ExportToCsv(DataGridView dgv, string filePath)
        {
            var sb = new StringBuilder();

            // Headers
            var headers = new string[dgv.Columns.Count];
            int visibleIndex = 0;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible)
                {
                    if (visibleIndex > 0) sb.Append(",");
                    sb.Append("\"" + dgv.Columns[i].HeaderText.Replace("\"", "\"\"") + "\"");
                    visibleIndex++;
                }
            }
            sb.AppendLine();

            // Data rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                visibleIndex = 0;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible)
                    {
                        if (visibleIndex > 0) sb.Append(",");
                        var value = row.Cells[i].Value?.ToString() ?? "";
                        sb.Append("\"" + value.Replace("\"", "\"\"") + "\"");
                        visibleIndex++;
                    }
                }
                sb.AppendLine();
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
    }
}
