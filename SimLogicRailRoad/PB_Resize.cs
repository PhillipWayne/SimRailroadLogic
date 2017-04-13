using System;
using System.Drawing;
using System.Windows.Forms;
using testsim;
using System.Collections.Generic;
class SizeablePictureBox : PictureBox
{


    public SizeablePictureBox()
    {
        this.ResizeRedraw = true;
        this.DoubleBuffered = true;
        this.SetStyle(ControlStyles.ResizeRedraw, true);
    }

   

    private const int
    HTLEFT = 10,
    HTRIGHT = 11,
    HTTOP = 12,
    HTTOPLEFT = 13,
    HTTOPRIGHT = 14,
    HTBOTTOM = 15,
    HTBOTTOMLEFT = 16,
    HTBOTTOMRIGHT = 17;

    const int _ = 10; // you can rename this variable if you like

    private string []  bitsofcomponents;
    
    public string[] Bitsofcomponents
    {
        get { return bitsofcomponents; }
        set { bitsofcomponents = value; }
    }

    
    private string [] componentval;
    public string [] Componentval
    {
        get { return componentval; }
        set { componentval = value; }
    }
    Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, _); } }
    Rectangle Left { get { return new Rectangle(0, 0, _, this.ClientSize.Height); } }
    Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - _, this.ClientSize.Width, _); } }
    Rectangle Right { get { return new Rectangle(this.ClientSize.Width - _, 0, _, this.ClientSize.Height); } }
    Rectangle TopLeft { get { return new Rectangle(0, 0, _, _); } }
    Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); } }
    Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - _, _, _); } }
    Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - _, this.ClientSize.Height - _, _, _); } }


    protected override void WndProc(ref Message message)
    {
        base.WndProc(ref message);

        if (message.Msg == 0x84) // WM_NCHITTEST
        {
            
                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }

        
            {
                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }
        }
        
    


   
        
 






//}
    //protected override void OnPaint(PaintEventArgs e) {
    //    base.OnPaint(e);
    //    var rc = new Rectangle(this.ClientSize.Width - grab, this.ClientSize.Height - grab, grab, grab);
    //    ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
    //}
    //protected override void WndProc(ref Message m) {
    //    base.WndProc(ref m);
    //    if (m.Msg == 0x84)

    //    {  // Trap WM_NCHITTEST
    //        var pos = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
    //        if (pos.X >= this.ClientSize.Width - grab && pos.Y >= this.ClientSize.Height - grab)
    //            m.Result = new IntPtr(11);  // HT_BOTTOMRIGHT
    //          }
    //}
    //private const int grab = 16;



    //protected override CreateParams CreateParams
    //{
    //    get
    //    {
    //        var cp = base.CreateParams;
    //        cp.Style |= 0x0400;  // Turn on WS_BORDER + WS_THICKFRAME
    //        return cp;
    //    }
    //}
//}