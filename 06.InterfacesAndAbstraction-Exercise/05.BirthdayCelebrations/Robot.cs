using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    class Robot : IIdentifiable
    {
        private string Model;
        public string Id { get; set; }

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
    }
}
