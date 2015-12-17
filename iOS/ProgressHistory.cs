using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using DrawShape;
using DrawShape.iOS;
using System.Drawing;
using testlistview;
using UIKit;
using CoreGraphics;
using CoreAnimation;

[assembly:ExportRenderer (typeof(StepHistoryView), typeof(ProgressHistory))]
namespace DrawShape.iOS
{
    public class ProgressHistory : VisualElementRenderer<StepHistoryView>
    {
        private readonly float QuarterTurnCounterClockwise = (float)(-1f * (Math.PI * 0.5f));

        CATextLayer dateLayer;
        CATextLayer percentLayer;
        CATextLayer stepLayer;

        public ProgressHistory()
        {

        }

        public override void Draw (CGRect rect)
        {
            var currentContext = UIGraphics.GetCurrentContext ();
            var properRect = AdjustForThickness (rect);
            HandleShapeDraw (currentContext, properRect);
        }

        protected RectangleF AdjustForThickness (CGRect rect)
        {
            var x = rect.X + Element.Padding.Left;
            var y = rect.Y + Element.Padding.Top;
            var width = rect.Width - Element.Padding.HorizontalThickness;
            var height = rect.Height - Element.Padding.VerticalThickness;
            return new RectangleF ((float)x, (float)y, (float)width, (float)height);
        }

        protected virtual void HandleShapeDraw (CGContext currentContext, RectangleF rect)
        {
            // Only used for circles
            var centerX = rect.X + (rect.Width / 2);
            var centerY = rect.Y + (rect.Height / 2);
            var radius = rect.Width / 2;
            const float endAngle = (float)(Math.PI * 2);

            currentContext.SetStrokeColor (UIColor.LightGray.CGColor);
            HandleStandardDraw (currentContext, rect, () => currentContext.AddArc (centerX, centerY, radius, 0, endAngle, true));


            currentContext.SetStrokeColor (Element.StrokeColor.ToCGColor ());
            HandleStandardDraw(currentContext, rect, () => currentContext.AddArc(centerX, centerY, radius, QuarterTurnCounterClockwise, (endAngle * (Element.IndicatorPercentage)) + QuarterTurnCounterClockwise, false));
        
            if (dateLayer == null)
            {
                dateLayer = new CATextLayer()
                {
                    Frame = new CGRect(rect.X , rect.Top + rect.Height - 15, rect.Width, rect.Height / 2 - 5),
                    ForegroundColor = UIColor.Black.CGColor,
                    AlignmentMode = CATextLayer.AlignmentCenter,
                    FontSize = 12
                };
                
                Layer.AddSublayer(dateLayer);
            }


            if (percentLayer == null)
            {
                percentLayer = new CATextLayer
                    {
                        Frame = new CGRect(rect.X, centerY - 15, rect.Width, rect.Height / 2 - 5),
                        ForegroundColor = UIColor.Black.CGColor,
                        AlignmentMode = CATextLayer.AlignmentCenter,
                        FontSize = 13
                    };

                Layer.AddSublayer(percentLayer);
            }

            if (stepLayer == null)
            {
                stepLayer = new CATextLayer
                    {
                        Frame = new CGRect(rect.X, centerY + 3, rect.Width, rect.Height / 2 - 5),
                        ForegroundColor = UIColor.Black.CGColor,
                        AlignmentMode = CATextLayer.AlignmentCenter,
                        FontSize = 13
                    };

                Layer.AddSublayer(stepLayer);
            }

            dateLayer.String = Element.DateString;
            percentLayer.String = string.Format("{0:p0}", Element.IndicatorPercentage);
            stepLayer.String = String.Format("{0:##,###}", Element.Steps);
        }

        /// <summary>
        /// A simple method for handling our drawing of the shape. This method is called differently for each type of shape
        /// </summary>
        /// <param name="currentContext">Current context.</param>
        /// <param name="rect">Rect.</param>
        /// <param name="createPathForShape">Create path for shape.</param>
        /// <param name="lineWidth">Line width.</param>
        protected virtual void HandleStandardDraw (CGContext currentContext, RectangleF rect, Action createPathForShape)
        {
            currentContext.SetLineWidth (Element.StrokeWidth);
            currentContext.SetFillColor (base.Element.Color.ToCGColor ());
            currentContext.SetLineCap(CGLineCap.Round);

            createPathForShape ();

            currentContext.DrawPath (CGPathDrawingMode.FillStroke);
        }
    }
}