﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{Color} Seat {Model}");
            output.AppendLine(Start());
            output.AppendLine(Stop());
            return output.ToString().Trim();
        }
    }
}
