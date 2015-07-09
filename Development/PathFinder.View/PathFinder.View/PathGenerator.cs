using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PathFinder.View
{
    public partial class PathGenerator : Form
    {
        private const float PaneWidth = 3;

        public PathGenerator()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                ProbabilityCmb.Items.Add(i);
            }
            _pathGenerator = new PathFinder.PathGenerator();
            MaxAmplitudeFluctuationsTb.Text = "10";
            MaxOscillationFrequencyTb.Text = "1";
            MinIntervalWidthTb.Text = "5";
            ProbabilityCmb.SelectedItem = 50;
            StartX.Text = "10";
            StartY.Text = "10";
            EndY.Text = "300";
            EndX.Text = "300";
            _graphics = RouteView.CreateGraphics();
        }

        public static List<Point> HelPoints = new List<Point>();

        private static int GetRandomValueInRange(string minVal, string maxVal)
        {
            var min = Convert.ToInt32(minVal);
            var max = Convert.ToInt32(maxVal);
            var rand = new Random();
            return rand.Next(min, max);
        }

        private void CleanBtn_Click(object sender, EventArgs e)
        {
            RouteView.CreateGraphics().Clear(Color.White);
        }

        private void AddHelpPoitnsBtn_Click(object sender, EventArgs e)
        {
            var helpPoints = new HelpPointsDialog();
            helpPoints.ShowDialog();
        }

        private void PathGenerator_Resize(object sender, EventArgs e)
        {
            _graphics.Clear(Color.White);
            _graphics = RouteView.CreateGraphics();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) { return; }

                var map = new Map(RouteView.Width, RouteView.Height);
                var probability = Convert.ToInt32(ProbabilityCmb.Text);
                var route = GetRoute(map, probability);
                var resultPoints = route.GetFullPath();

                DrawStartPoints(_startPoint, _endPoint);
                _graphics.Clear(Color.White);
                if (BezierCurveCb.Checked)
                {
                    DrawBezierCurve(route.GetPointsForBeziers());
                }

                if (SimplePath.Checked)
                {
                    DrawSimpleCurve(resultPoints);
                }

                if (Curve.Checked)
                {
                    //var count = resultPoints.Count();
                    //Point[] points = new Point[count + 2];
                    //points[0] = _startPoint;
                    //for (int i = 0; i < count; i++)
                    //{
                    //    DrawCurve(points[i+1], resultPoints[i]);    
                    //}
                    //points[count] = _endPoint;

                    //_graphics.DrawCurve(new Pen(Color.Firebrick, PaneWidth), points);

                    DrawCurve(_startPoint, _endPoint);

                    //DrawCurve(resultPoints[count - 1], _endPoint);    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Route GetRoute(Map map, int probability)
        {
            Route route;
            if (HelPoints.Count > 0)
            {
                var points = new List<Point>();
                points.Add(_startPoint);
                points.AddRange(HelPoints);
                points.Add(_endPoint);
                route = _pathGenerator.GetPath(map, points, probability);
            }
            else
            {
                route = _pathGenerator.GetPath(map, _startPoint, _endPoint, probability);
            }
            return route;
        }
        
        private int GetAmplitudeAmplitudeFluctuations()
        {
            if (String.IsNullOrEmpty(MinAmplitudeFluctuationsTb.Text) &&
               String.IsNullOrEmpty(MaxAmplitudeFluctuationsTb.Text))
            {
                throw new ArgumentException("Incorect Amplitude");
            }
            return GetRandomValueInRange(MinAmplitudeFluctuationsTb.Text, MaxAmplitudeFluctuationsTb.Text);
        }

        private int GetOscillationFrequency()
        {
            if (String.IsNullOrEmpty(MinOscillationFrequencyTb.Text) &&
                           String.IsNullOrEmpty(MaxOscillationFrequencyTb.Text))
            {
                throw new ArgumentException("Incorect Frequency");
            }
            return GetRandomValueInRange(MinOscillationFrequencyTb.Text, MaxOscillationFrequencyTb.Text);
        }

        private bool ValidateInput()
        {
            bool res = true;
            try
            {
                if (!String.IsNullOrEmpty(MinAmplitudeFluctuationsTb.Text))
                {
                    _pathGenerator.AmplitudeFluctuations = GetAmplitudeAmplitudeFluctuations();
                }

                if (!String.IsNullOrEmpty(MinOscillationFrequencyTb.Text))
                {
                    _pathGenerator.OscillationFrequency = GetOscillationFrequency();
                }

                if (!String.IsNullOrEmpty(MinIntervalWidthTb.Text))
                {
                    _pathGenerator.MinIntervalWidth = Convert.ToInt32(MinIntervalWidthTb.Text);
                }

                if (!(String.IsNullOrEmpty(StartX.Text) && String.IsNullOrEmpty(StartY.Text)
                    && String.IsNullOrEmpty(EndX.Text) && String.IsNullOrEmpty(EndY.Text)))
                {
                    _startPoint.X = Convert.ToInt32(StartX.Text);
                    _startPoint.Y = Convert.ToInt32(StartY.Text);
                    _endPoint.X = Convert.ToInt32(EndX.Text);
                    _endPoint.Y = Convert.ToInt32(EndY.Text);
                }
                else
                {
                    throw new Exception("Incorect input data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                res = false;
            }
            return res;
        }

        private void DrawStartPoints(Point start, Point end)
        {
            _graphics.FillEllipse(Brushes.Red, start.X, start.Y, 3, 2);
            _graphics.FillEllipse(Brushes.Red, end.X, end.Y, 3, 2);
        }

        private void DrawSimpleCurve(IEnumerable<Point> points)
        {
            try
            {
                var pen = new Pen(Color.Yellow, PaneWidth);
                _graphics.DrawLines(pen, points.ToArray());
            }
            catch (Exception)
            {
                MessageBox.Show("Incorect params for Simple Curve ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawCurve(Point start, Point end)
        {
            DrawCurve(start, end, Color.Blue);
        }

        private void DrawCurve(Point start, Point end, Color color)
        {
            try
            {
                var pen = new Pen(color, PaneWidth);
                _graphics.DrawLine(pen, start, end);
            }
            catch (Exception)
            {
                MessageBox.Show("Incorect params for Curve ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawBezierCurve(IEnumerable<Point> points)
        {
            try
            {
                var pen = new Pen(Color.DarkMagenta, PaneWidth);
                _graphics.DrawBeziers(pen, points.ToArray());
            }
            catch (Exception)
            {
                MessageBox.Show("Incorect params for Bezier ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawSimpleCurve(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(SCEndX.Text) || String.IsNullOrEmpty(SCEndY.Text) ||
                    String.IsNullOrEmpty(SCStartX.Text) || String.IsNullOrEmpty(SCStartY.Text))
                {
                    throw new ArgumentException();
                }
                var start = new Point(Convert.ToInt32(SCStartX.Text), Convert.ToInt32(SCStartY.Text));
                var end = new Point(Convert.ToInt32(SCEndX.Text), Convert.ToInt32(SCEndY.Text));

                DrawCurve(start, end, Color.ForestGreen);
            }
            catch (Exception)
            {
                MessageBox.Show("Incorect values for simple curve");
            }
        }

        private Point _startPoint;
        private Point _endPoint;
        private Graphics _graphics;
        private readonly PathFinder.PathGenerator _pathGenerator;
    }
}
