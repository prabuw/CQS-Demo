﻿using System;

namespace CQSDemo.MediatrCore.Entities
{
    public class Worksheet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
    }
}