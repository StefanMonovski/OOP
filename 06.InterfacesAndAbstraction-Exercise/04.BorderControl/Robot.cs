using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
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
