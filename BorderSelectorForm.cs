using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotsSaver
{
    public partial class BorderSelectorForm : Form
    {
        private Point mouseOffset;
        private bool isMouseDown = false;
        private bool isMoveArea = false;
        private bool isSizingArea = false;
        private Point point;

        public BorderSelectorForm()
        {
            InitializeComponent();
        }

        private void BorderSelectorForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK; 
                this.Close();
            }
        }

        private void BorderSelectorForm_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;
            if (e.Button == MouseButtons.Left)
            {
                point = e.Location;

                xOffset = -e.X;
                yOffset = -e.Y;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
                var rect = new Rectangle(0, 0, Width - 1, Height - 1);
                var square = new Rectangle(0, 0, 15, 15);
                isMoveArea = square.Contains(e.X, e.Y);
                square.Offset(rect.Width - square.Width, rect.Height - square.Height);
                isSizingArea = square.Contains(e.X, e.Y);
            }
        }

        private void BorderSelectorForm_MouseMove(object sender, MouseEventArgs e)
        {
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            var square = new Rectangle(0, 0, 15, 15);
            isMoveArea = square.Contains(e.X, e.Y);
            square.Offset(rect.Width - square.Width, rect.Height - square.Height);
            var isSizeArea = square.Contains(e.X, e.Y);
            Cursor = isMoveArea ? Cursors.SizeAll : isSizeArea ? Cursors.SizeNWSE : DefaultCursor;
            if (isMouseDown && !isSizingArea)
            {
                Point mousePos = Control.MousePosition;
                var workingArea = Screen.GetWorkingArea(Control.MousePosition);
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                if (mousePos.X < workingArea.X) mousePos.X = 0;
                if (mousePos.Y < workingArea.Y) mousePos.Y = 0;
                if (mousePos.X + Width > workingArea.X + workingArea.Width) mousePos.X = workingArea.Width - Width;
                if (mousePos.Y + Height > workingArea.Y + workingArea.Height) mousePos.Y = workingArea.Height - Height;
                Location = mousePos;
            }
            else if (isMouseDown && isSizingArea)
            {
                var workingArea = Screen.GetWorkingArea(Control.MousePosition);
                var width = Width + e.X - point.X;
                var height = Height + e.Y - point.Y;
                if (width < 5) width = 5;
                if (height < 5) height = 5;
                if (width > workingArea.Width - Location.X) width = workingArea.Width - Location.X;
                if (height > workingArea.Height - Location.Y) height = workingArea.Height - Location.Y;
                Size = new Size(width, height);
                point = e.Location;
                Invalidate();
            }
        }

        private void BorderSelectorForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMouseDown = false;
        }

        private void BorderSelectorForm_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            e.Graphics.FillRectangle(Brushes.White, rect);
            e.Graphics.DrawRectangle(Pens.Magenta, rect);
            var square = new Rectangle(0, 0, 15, 15);
            e.Graphics.FillRectangle(Brushes.Magenta, square);
            square.Offset(rect.Width - square.Width, rect.Height - square.Height);
            e.Graphics.FillRectangle(Brushes.Magenta, square);
        }
    }
}
