using ChartDirector;
using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ChartDirector로3DScatterPlot그리기
{
    public partial class Form1 : Form
    {
        private double rotationAngle = 45;
        private double elevationAngle = 30;
  

        private bool openFileFlag = false;

        private DataTable dt1;
        private SurfaceChart c;

        public Form1()
        {
            InitializeComponent();

            // Initialize the WinChartViewer
            initChartViewer(winChartViewer1);

        }
        //
        // Initialize the WinChartViewer
        //
        private void initChartViewer(WinChartViewer viewer)
        {

            // Enable mouse wheel zooming by setting the zoom ratio to 1.1 per wheel event
            viewer.MouseWheelZoomRatio = 1.1;
            // Initially set the mouse usage to "Pointer" mode (Drag to Scroll mode)
            PointerPB.Checked = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Display the chart
            winChartViewer1.updateViewPort(true, false);

        }


        //
        // The ViewPortChanged event handler
        //
        private void winChartViewer1_ViewPortChanged(object sender, WinViewPortEventArgs e)
        {
            // In addition to updating the chart, we may also need to update other controls that
            // changes based on the view port.
            updateControls(winChartViewer1);

            // Update the chart if necessary
            if (e.NeedUpdateChart)
            {
                drawChart(winChartViewer1);
            }
        }

        //
        // Update controls when the view port changed
        //
        private void updateControls(WinChartViewer viewer)
        {

            // Update the scroll bar to reflect the view port position and width of the view port.
            hScrollBar1.Enabled = winChartViewer1.ViewPortWidth < 1;
            hScrollBar1.LargeChange = (int)Math.Ceiling(winChartViewer1.ViewPortWidth *
                (hScrollBar1.Maximum - hScrollBar1.Minimum));
            hScrollBar1.SmallChange = (int)Math.Ceiling(hScrollBar1.LargeChange * 0.1);
            hScrollBar1.Value = (int)Math.Round(winChartViewer1.ViewPortLeft *
                (hScrollBar1.Maximum - hScrollBar1.Minimum)) + hScrollBar1.Minimum;
    
        }


        public void drawChart(WinChartViewer viewer)
        {
            if (openFileFlag == false)
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    openFileFlag = true;
                    string filename = openFileDialog1.FileName;
                    dt1 = GetDataTableFromCsv(filename, false);
                }
            }

            double[] xData = new double[dt1.Rows.Count * dt1.Columns.Count];
            double[] yData = new double[dt1.Rows.Count * dt1.Columns.Count];
            double[] zData = new double[dt1.Rows.Count * dt1.Columns.Count];

            int temp = 0;

            for (int x = 0; x < dt1.Rows.Count; x++)
            {
                for (int y = 0; y < dt1.Columns.Count; y++)
                {
                    xData[temp] = x;
                    yData[temp] = y;

                    zData[temp] = Convert.ToInt64(dt1.Rows[x][y]);
                   

                    temp += 1;
                }
            }

            c = null;
            // Create a SurfaceChart object of size 720 x 600 pixels
             c = new SurfaceChart(720, 600);

            // Set the center of the plot region at (330, 290), 
            //and set width x depth x height to
            // 360 x 360 x 270 pixels
            c.setPlotRegion(330, 290, 360, 360, 270);

            // Set the data to use to plot the chart
            c.setData(xData, yData, zData);

            // Spline interpolate data to a 80 x 80 grid for a smooth surface
            c.setInterpolation(80, 80);

            // Set the view angles
            c.setViewAngle(elevationAngle, rotationAngle);

            // Check if draw frame only during rotation
            if (isDragging && DrawFrameOnRotate.Checked)
            {
                c.setShadingMode(Chart.RectangularFrame);
            }

            // Add a color axis (the legend) in which the left center is anchored
            //at (650, 270). Set the length to 200 pixels and the labels on the
            //right side.
            c.setColorAxis(650, 270, Chart.Left, 200, Chart.Right);

            // Set the x, y and z axis titles using 10 points Arial Bold font
            c.xAxis().setTitle("X", "Arial Bold", 15);
            c.yAxis().setTitle("Y", "Arial Bold", 15);

            // Set axis label font
            c.xAxis().setLabelStyle("Arial", 10);
            c.yAxis().setLabelStyle("Arial", 10);
            c.zAxis().setLabelStyle("Arial", 10);
            c.colorAxis().setLabelStyle("Arial", 10);

            // Output the chart
            viewer.Chart = c;
        }



        // keep track of the last mouse position to compute mouse movement
        private int lastMouseX = -1;
        private int lastMouseY = -1;
        private bool isDragging = false;

        private void winChartViewer1_MouseDown(object sender, MouseEventArgs e)
        {
            if (0 != (e.Button & MouseButtons.Left))
            {
                // Start Drag
                isDragging = true;
                lastMouseX = e.X;
                lastMouseY = e.Y;
                (sender as WinChartViewer).updateViewPort(true, false);
            }
        }

        private void winChartViewer1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // The chart is configured to rotate by 90 degrees when the mouse moves from 
                // left to right, which is the plot region width (360 pixels). Similarly, the
                // elevation changes by 90 degrees when the mouse moves from top to buttom,
                // which is the plot region height (270 pixels).
                rotationAngle += (lastMouseX - e.X) * 90.0 / 360;
                elevationAngle += (e.Y - lastMouseY) * 90.0 / 270;
                lastMouseX = e.X;
                lastMouseY = e.Y;
                (sender as WinChartViewer).updateViewPort(true, false);
            }
        }

        private void winChartViewer1_MouseUp(object sender, MouseEventArgs e)
        {
            if (0 != (e.Button & MouseButtons.Left))
            {
                // End Drag
                isDragging = false;
                (sender as WinChartViewer).updateViewPort(true, false);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileFlag = false;

        }

        //
        // Zoom In button event handler
        //
        private void zoomInPB_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                winChartViewer1.MouseUsage = WinChartMouseUsage.ZoomIn;
            }
        }
        //
        // Zoom Out button event handler
        //
        private void zoomOutPB_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                winChartViewer1.MouseUsage = WinChartMouseUsage.ZoomOut;
            
            }
        }

        //
        // Pointer (Drag to Scroll) button event handler
        //
        private void pointerPB_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                winChartViewer1.MouseUsage = WinChartMouseUsage.ScrollOnDrag;
        }

        static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader)
        {
            Console.WriteLine(path);
            string header = isFirstRowHeader ? "Yes" : "No";

            string pathOnly = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);

            string sql = @"SELECT * FROM [" + fileName + "]";

            using (OleDbConnection connection = new OleDbConnection(
                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                      ";Extended Properties=\"Text;HDR=" + header + "\""))
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
