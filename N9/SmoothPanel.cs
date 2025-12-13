using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace N9 // Đã thêm Namespace N9
{
    public class SmoothPanel : Panel
    {
        private int cornerRadius = 30;

        // Thuộc tính để bạn có thể chỉnh Radius trong Properties
        public int CornerRadius
        {
            get { return cornerRadius; }
            set { cornerRadius = value; this.Invalidate(); } // Gọi Invalidate() để vẽ lại
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 1. THIẾT LẬP KHỬ RĂNG CƯA (ANTI-ALIASING)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // 2. Định nghĩa hình dạng bo tròn (GraphicsPath)
            using (GraphicsPath path = GetRoundedPath(this.ClientRectangle, cornerRadius))
            {
                // 3. Cài đặt Region (Khu vực hiển thị)
                this.Region = new Region(path);

                // 4. Vẽ nền (Màu nền của Panel)
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
            base.OnPaint(e); // Gọi base để đảm bảo Control con được vẽ
        }

        // Hàm tạo GraphicsPath (dùng để vẽ)
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rect.Location, size);

            // Góc trên trái, trên phải, dưới phải, dưới trái
            path.AddArc(arc, 180, 90); arc.X = rect.Right - diameter; path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter; path.AddArc(arc, 0, 90); arc.X = rect.Left;
            path.AddArc(arc, 90, 90); path.CloseFigure();
            return path;
        }
    }
}