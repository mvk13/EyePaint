﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EyePaint
{
    class Cloud
    {
        internal readonly Color color;
        internal readonly List<Point> points;
        private int radius;

        internal Cloud(Point root, Color color)
        {
            this.points = new List<Point> { root };
            this.color = color;
            this.radius = 1;
        }

        internal void IncreaseRadius()
        {
            radius++;
        }

        internal int GetRadius()
        {
            return radius;
        }
    }

    class CloudFactory
    {
        internal readonly Stack<Cloud> clouds;
        private Queue<Point> renderQueue;
        private Random randomNumberGenerator;

        internal CloudFactory()
        {
            clouds = new Stack<Cloud>();
            renderQueue = new Queue<Point>(); //TODO Exchange for buffer. Will probably require restructuring of program.
            randomNumberGenerator = new Random();
        }

        internal void AddCloud(Point center, Color color)
        {
            Cloud c = new Cloud(center, color);
            clouds.Push(c);
        }

        internal void GrowCloud(Cloud c, int amount)
        {
            c.IncreaseRadius();
            int radius = c.GetRadius();

            for (int i = 0; i < amount; i++)
            {
                int x = randomNumberGenerator.Next(c.points[0].X - radius, c.points[0].X + radius);
                int y = randomNumberGenerator.Next(c.points[0].Y - radius, c.points[0].Y + radius);
                c.points.Add(new Point(x, y)); //TODO Memory management!
                renderQueue.Enqueue(new Point(x, y));
            }
        }

        internal void GrowCloudRandomAmount(Cloud c, int maximum)
        {
            GrowCloud(c, randomNumberGenerator.Next(maximum));
        }

        internal bool HasQueued()
        {
            if (renderQueue.Count > 0)
                return true;
            else
                return false;
        }

        internal Point GetQueued()
        {
            return renderQueue.Dequeue();
        }

        internal int GetQueueLength()
        {
            return renderQueue.Count;
        }
    }
}
