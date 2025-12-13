using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace N9
{
    public class CirclePictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Tạo một đối tượng GraphicsPath để định nghĩa hình dạng
            GraphicsPath gp = new GraphicsPath();

            // Thêm hình elip vào GraphicsPath
            // Rectangle: Vị trí và kích thước của PictureBox
            gp.AddEllipse(0, 0, this.Width - 1, this.Height - 1);

            // Đặt vùng cắt (Region) của PictureBox bằng hình elip vừa tạo
            this.Region = new Region(gp);

            // Gọi phương thức OnPaint gốc để vẽ hình ảnh bên trong vùng đã cắt
            base.OnPaint(pe);
        }
    }
}
