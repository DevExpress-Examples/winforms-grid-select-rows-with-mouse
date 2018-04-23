using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1);
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        private void SelectRows(GridView view, int startRow, int endRow)
        {
            if (startRow > -1 && endRow > -1)
            {
                view.BeginSelection();
                view.ClearSelection();
                view.SelectRange(startRow, endRow);
                view.EndSelection();
            }
        }

        private int GetRowAt(GridView view, int x, int y)
        {
            return view.CalcHitInfo(new Point(x, y)).RowHandle;
        }

        private int StartRowHandle = -1;
        private int CurrentRowHandle = -1;

        private void gridView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            StartRowHandle = GetRowAt(sender as GridView, e.X, e.Y);
        }

        private void gridView1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int newRowHandle = GetRowAt(sender as GridView, e.X, e.Y);
            if (CurrentRowHandle != newRowHandle)
            {
                CurrentRowHandle = newRowHandle;
                SelectRows(sender as GridView, StartRowHandle, CurrentRowHandle);
            }
        }

        private void gridView1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            StartRowHandle = -1;
            CurrentRowHandle = -1;
        }
    }
}