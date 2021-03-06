using System;
using System.Collections.Generic;
using System.Text;

namespace T04.BorderControl
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            ID = id;
        }
        public string ID { get; set; }
        public string Model { get; set; }
    }
}
