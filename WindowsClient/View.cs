﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EyePaint
{
    class ImageFactory
    {
        private Image image;
        private Pen pen;
        private Random rng;

        internal ImageFactory(int width, int height)
        {
            image = new Bitmap(width, height);
            pen = new Pen(Color.Black, 1);
            rng = new Random();
        }

        internal Image Rasterize(ref Stack<Cloud> clouds)
        {
            Graphics g = Graphics.FromImage(image);
            var top = clouds.Peek();
            var radius = top.GetRadius();

            pen.Color = Color.FromArgb(150, top.color.R, top.color.G, top.color.B);
            pen.Width = 2 * radius + rng.Next(10 * radius);

            foreach (var point in top.points)
                g.DrawEllipse(
                    pen,
                    point.X - (float)rng.NextDouble() * radius,
                    point.Y - (float)rng.NextDouble() * radius,
                    pen.Width + (float)rng.Next(-radius, radius),
                    pen.Width + (float)rng.Next(-radius, radius)
                  );

            g.Dispose(); // TODO Use using() {} instead.

            return image;
        }

        internal void Undo()
        {
            //TODO Don't clear the entire drawing, instead implement an undo history.
            Graphics g = Graphics.FromImage(image);
            Region r = new Region();
            r.MakeInfinite();
            g.FillRegion(Brushes.White, r);
        }
    }
}
