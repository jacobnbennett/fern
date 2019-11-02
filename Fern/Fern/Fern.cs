﻿using System;
using System.Drawing;

namespace FernNamespace
{
    /*
     * this class draws a fractal fern when the constructor is called.
     * Written as sample C# code for a CS 212 assignment -- October 2011.
     * 
     * Bugs: WPF and shape objects are the wrong tool for the task 
     */
    class Fern
    {

        private Graphics graphics;

        /* hadsjbg d7yusagfduyg
         * Fern constructor erases screen and draws a fern
         * 
         * Size: number of 3-pixel segments of tendrils
         * Redux: how much smaller children clusters are compared to parents
         * Turnbias: how likely to turn right vs. left (0=always left, 0.5 = 50/50, 1.0 = always right)
         * canvas: the canvas that the fern will be drawn on   rjwhreiu  e dsge 
         */
        public Fern(double size, double redux, double turnBias, Graphics graphics, int width, int height)
        {
            Rectangle r = new Rectangle(0, 0, 200, 100);
            graphics.DrawRectangle(new Pen(Color.Red, 2), r); 
            
            Random rnd = new Random();
            double angle = Convert.ToDouble(90 * Math.PI / 180);
            double length = Math.Sqrt(Math.Pow((300 - 300), 2) + (Math.Pow((200 - 600), 2)));
            branch(300, 600, 300, 200, length * size, redux, angle, graphics);
        }

        private void branch(int x1, int y1, int x2, int y2, double length, double redux, double theta, Graphics graphics) {
            Pen penny = (new Pen(Color.Green, 2));
            int x = x2;
            int y = y2;
            
            double nlength = length / 2;
            int nx = Convert.ToInt32(x1 + length * Math.Cos(theta));
            int ny = Convert.ToInt32(y1 - length * Math.Sin(theta));

            
            //double length = Math.Sqrt(Math.Pow((x2 - x1), 2) + (Math.Pow((y2 - y1), 2))); redtw
            
            graphics.DrawLine(penny, x1, y1, nx, ny);
           
            if (redux > 0.1){
                
                nx = Convert.ToInt32(x2 + nlength * Math.Cos(theta));
                ny = Convert.ToInt32(y2 + nlength * Math.Sin(theta));
                branch(x, y, nx, ny, nlength, redux - 0.1, theta + 10, graphics);
                branch(x, y, nx, ny, nlength, redux - 0.1, theta - 10, graphics);

                //branch();
            }
            //graphics.DrawCurve(penny, )
        }
    }
}


